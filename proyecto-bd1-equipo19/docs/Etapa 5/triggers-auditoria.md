# Etapa 5 — Triggers y Automatización de Reglas de Negocio

## Introducción

En esta sección se documentan e investigan los **Triggers (Disparadores de Base de Datos)** implementados en **SQL Server Express** para el sistema **CineMaCtes**. Los triggers permiten ejecutar lógica procedimental de forma automática e imperceptible en respuesta a eventos de manipulación de datos (`INSERT`, `UPDATE`), garantizando la auditoría de cambios, la integridad de los datos y el cumplimiento estricto de las reglas de negocio directamente en el motor de base de datos.

---

## 1. Para qué se utiliza el mecanismo de Triggers

Un **Trigger** es un tipo especial de procedimiento almacenado que se ejecuta de manera automática e implícita cuando ocurre un evento DML (`INSERT`, `UPDATE`, `DELETE`) sobre una tabla o vista determinada.

### Objetivos Principales:
* **Auditoría de Cambios Sensibles:** Registrar automáticamente el historial de modificaciones en datos críticos (como el precio de las funciones), capturando valores anteriores, nuevos, fecha y usuario ejecutor.
* **Automatización de Reglas de Negocio Complejas:** Ejecutar validaciones y restricciones operativas que involucran múltiples tablas de forma previa o posterior a la persistencia.
* **Integridad Referencial y Lógica:** Impedir estados inconsistentes en el sistema (como la venta de boletos para funciones ya iniciadas o la acumulación indeseada de beneficios promocionales).
* **Actualización Automática de Estados Derivados:** Modificar estados de entidades asociadas (como actualizar automáticamente una función a estado "Entradas Agotadas") sin requerir lógica redundante en las aplicaciones clientes.
* **Atomicidad y Rollback:** Interrumpir la transacción y revertir los cambios (`ROLLBACK TRANSACTION`) cuando no se cumplen las condiciones operativas exigidas.

---

## 2. Por qué fue elegido para CineMaCtes

En el sistema de gestión cinematográfica **CineMaCtes**, delegar la auditoría y las validaciones de negocio únicamente en la capa de aplicación cliente (web o móvil) presenta graves vulnerabilidades de seguridad, inconsistencia y falta de trazabilidad.

### Justificación Técnica:
1. **Auditoría Transparente e Inviolable:** Al ejecutarse a nivel de motor SQL Server, ningún usuario o aplicación puede modificar precios de funciones sin dejar un registro de auditoría en la tabla `AUDITORIA_PRECIO_FUNCION`.
2. **Centralización en el Motor de BD:** Garantiza que cualquier inserción o actualización (ya sea desde la interfaz web, una API o una consulta manual en SQL Server Management Studio) respete invariablemente las reglas de negocio del cine.
3. **Prevención de Condiciones de Carrera (*Race Conditions*):** En eventos de alta concurrencia (como la venta simultánea del último boleto disponible), el trigger evalúa la capacidad dentro del contexto transaccional, evitando sobreventas.
4. **Eficiencia y Trazabilidad Operativa:** Las comprobaciones se efectúan directamente en la memoria caché del motor SQL, reduciendo latencias y llamadas innecesarias por red.

---

## 3. Integración al Sistema CineMaCtes

El sistema **CineMaCtes** integra **5 Triggers estratégicos** para auditar cambios de tarifas y controlar el flujo de compras y programación de cartelera:

| Trigger | Tabla Impactada | Evento | Regla de Negocio / Propósito |
| :--- | :--- | :--- | :--- |
| `trg_AuditoriaPrecioFuncion` | `FUNCION` | `AFTER UPDATE` | Auditar cambios de precio en funciones guardando valores previos, nuevos, usuario y fecha. |
| `trg_UnicoBeneficioPorUsuarioFecha` | `COMPRA` | `AFTER INSERT, UPDATE` | Limitar a un solo beneficio promocional diario por usuario. |
| `trg_ValidarHorarioFuncion` | `COMPRA_FUNCION` | `AFTER INSERT` | Bloquear la venta de boletos si la función ya inició. |
| `trg_ActualizarEstadoFuncionAgotada` | `COMPRA_FUNCION` | `AFTER INSERT` | Cambiar automáticamente el estado de la función a "Entradas Agotadas" (ID 3) al llenar la sala. |
| `trg_ValidarSuperposicionFunciones` | `FUNCION` | `AFTER INSERT, UPDATE` | Evitar solapamiento de funciones en una misma sala (+15 min de limpieza y mantenimiento). |

---

## 4. Detalle Técnico e Implementación de los Triggers

### 4.1. Auditoría de Cambios de Precio (`trg_AuditoriaPrecioFuncion`)

* **Ubicación:** Tabla `FUNCION`.
* **Descripción:** Controla las actualizaciones en la columna `precio`. Cuando detecta una modificación efectiva (`d.precio <> i.precio`), registra en la tabla `AUDITORIA_PRECIO_FUNCION` el ID de la función, el precio anterior (`deleted`), el precio nuevo (`inserted`), la fecha (`GETDATE()`), el usuario del sistema (`SYSTEM_USER`) y el tipo de operación (`UPDATE`).

```sql
USE CINEMA;
GO

CREATE OR ALTER TRIGGER trg_AuditoriaPrecioFuncion
ON FUNCION
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Registrar solo si hubo cambio en el precio
    IF UPDATE(precio)
    BEGIN
        INSERT INTO AUDITORIA_PRECIO_FUNCION (
            id_funcion, 
            precio_anterior, 
            precio_nuevo, 
            fecha_modificacion, 
            usuario, 
            tipo_operacion
        )
        SELECT 
            d.id_funcion,
            d.precio AS precio_anterior,
            i.precio AS precio_nuevo,
            GETDATE(),
            SYSTEM_USER,
            'UPDATE'
        FROM deleted d
        INNER JOIN inserted i ON d.id_funcion = i.id_funcion
        WHERE d.precio <> i.precio;
    END
END;
GO
```

---

### 4.2. Control de Beneficios Diarios por Usuario (`trg_UnicoBeneficioPorUsuarioFecha`)

* **Ubicación:** Tabla `COMPRA`.
* **Descripción:** Verifica que un cliente (identificado por su `dni`) no acumule más de una compra con beneficio promocional asignado en la misma fecha. Si detecta más de una compra con beneficio el mismo día, genera una excepción y revierte la transacción.

```sql
USE CINEMA;
GO

CREATE OR ALTER TRIGGER trg_UnicoBeneficioPorUsuarioFecha
ON COMPRA
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Solo evaluamos si en la inserción/actualización se está intentando aplicar un beneficio
    IF EXISTS (SELECT 1 FROM inserted WHERE id_beneficio IS NOT NULL)
    BEGIN
        -- Verificamos si el usuario ya acumuló más de una compra CON beneficio en el mismo día
        IF EXISTS (
            SELECT c.dni, c.fecha
            FROM COMPRA c
            INNER JOIN inserted i ON c.dni = i.dni AND c.fecha = i.fecha
            WHERE c.id_beneficio IS NOT NULL
            GROUP BY c.dni, c.fecha
            HAVING COUNT(c.id_compra) > 1
        )
        BEGIN
            RAISERROR ('DENEGADO: Se excede el limite de beneficios diarios', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
    END
END;
GO
```

---

### 4.3. Validación de Horario de Función (`trg_ValidarHorarioFuncion`)

* **Ubicación:** Tabla `COMPRA_FUNCION`.
* **Descripción:** Compara la fecha y hora combinada de la función con el horario actual del servidor (`GETDATE()`). Si la función ya dio inicio, interrumpe el proceso de venta arrojando un error.

```sql
USE CINEMA;
GO

CREATE OR ALTER TRIGGER [dbo].[trg_ValidarHorarioFuncion]
ON [dbo].[COMPRA_FUNCION]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Combinación limpia y segura de DATE y TIME a DATETIME usando DATEADD
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN FUNCION f ON i.id_funcion = f.id_funcion
        WHERE DATEADD(second, DATEDIFF(second, '00:00:00', f.hora), CAST(f.fecha AS DATETIME)) < GETDATE()
    )
    BEGIN
        RAISERROR ('RECHAZADO LA FUNCION YA COMENZÓ.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO
```

---

### 4.4. Actualización de Estado a "Entradas Agotadas" (`trg_ActualizarEstadoFuncionAgotada`)

* **Ubicación:** Tabla `COMPRA_FUNCION`.
* **Descripción:** Tras cada venta de entradas, computa el acumulado de butacas vendidas para la función. Si la cantidad vendida iguala o supera la capacidad máxima de la sala (`SALA.capacidad`), modifica de forma automática el estado de la función a `3` ("Entradas Agotadas").

```sql
USE CINEMA;
GO

CREATE OR ALTER TRIGGER [dbo].[trg_ActualizarEstadoFuncionAgotada]
ON [dbo].[COMPRA_FUNCION]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE f
    SET f.id_estado_funcion = 3 -- ID 3 = 'Entradas Agotadas'
    FROM FUNCION f
    INNER JOIN SALA s ON f.id_sala = s.id_sala
    WHERE f.id_funcion IN (SELECT DISTINCT id_funcion FROM inserted)
      AND f.id_estado_funcion <> 3
      AND (
          SELECT COALESCE(SUM(cf.cantidad), 0)
          FROM COMPRA_FUNCION cf
          WHERE cf.id_funcion = f.id_funcion
      ) >= s.capacidad;
END;
GO
```

---

### 4.5. Control de Superposición de Horarios en Salas (`trg_ValidarSuperposicionFunciones`)

* **Ubicación:** Tabla `FUNCION`.
* **Descripción:** Al programar o modificar una función, calcula la hora de finalización sumando la duración en minutos de la película proyectada más **15 minutos adicionales de limpieza y mantenimiento de la sala**. Si detecta solapamiento de horarios en la misma sala y fecha, rechaza la operación.

```sql
USE CINEMA;
GO

CREATE OR ALTER TRIGGER trg_ValidarSuperposicionFunciones
ON FUNCION
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Se detecta solapamiento en la misma sala y fecha
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN PELICULA p_new ON i.id_pelicula = p_new.id_pelicula
        JOIN FUNCION f_existente ON i.id_sala = f_existente.id_sala
                                AND i.fecha = f_existente.fecha
                                AND i.id_funcion <> f_existente.id_funcion
        JOIN PELICULA p_existente ON f_existente.id_pelicula = p_existente.id_pelicula
        CROSS APPLY (
            -- Extrae únicamente los dígitos de duracion (ej: '148 min' -> 148)
            SELECT COALESCE(
                TRY_CAST(LEFT(p_new.duracion, CHARINDEX(' ', p_new.duracion + ' ') - 1) AS INT),
                120
            ) AS duracion_min_nueva,
            COALESCE(
                TRY_CAST(LEFT(p_existente.duracion, CHARINDEX(' ', p_existente.duracion + ' ') - 1) AS INT),
                120
            ) AS duracion_min_existente
        ) AS mins
        CROSS APPLY (
            -- Inicio y fin de la nueva función (incluye 15 min de limpieza/mantenimiento)
            SELECT 
                DATEADD(second, DATEDIFF(second, '00:00:00', i.hora), CAST(i.fecha AS DATETIME)) AS inicio_nueva,
                DATEADD(MINUTE, mins.duracion_min_nueva + 15, DATEADD(second, DATEDIFF(second, '00:00:00', i.hora), CAST(i.fecha AS DATETIME))) AS fin_nueva
        ) AS t_nueva
        CROSS APPLY (
            -- Inicio y fin de la función existente (incluye 15 min de limpieza/mantenimiento)
            SELECT 
                DATEADD(second, DATEDIFF(second, '00:00:00', f_existente.hora), CAST(f_existente.fecha AS DATETIME)) AS inicio_existente,
                DATEADD(MINUTE, mins.duracion_min_existente + 15, DATEADD(second, DATEDIFF(second, '00:00:00', f_existente.hora), CAST(f_existente.fecha AS DATETIME))) AS fin_existente
        ) AS t_existente

        -- Condición matemática de superposición de rangos horarios: (InicioA < FinB) Y (FinA > InicioB)
        WHERE t_nueva.inicio_nueva < t_existente.fin_existente
          AND t_nueva.fin_nueva > t_existente.inicio_existente
    )
    BEGIN
        RAISERROR ('YA EXISTE UNA FUNCION PROGRAMADA DENTRO DEL HORARIO ELEGIDO.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO
```

---

## 5. Demostración y Script de Funcionamiento (Lotes de Prueba)

### 5.1. Demostración: Auditoría de Cambio de Precio
```sql
USE CINEMA;
GO

-- 1. CASO EXITOSO: Actualización del precio de una función existente (Función 201)
UPDATE FUNCION 
SET precio = 6000 
WHERE id_funcion = 201;

PRINT '-> Prueba 1 (Cambio de precio): ÉXITO - Debe registrar en auditoría.';
GO

-- 2. CASO CONTROL: Intento de actualización manteniendo el mismo precio
UPDATE FUNCION 
SET precio = 6000 
WHERE id_funcion = 201;

PRINT '-> Prueba 2 (Mismo precio): ÉXITO - NO debe agregar ningún registro nuevo.';
GO

-- 3. Verificación de Auditoría
SELECT * FROM AUDITORIA_PRECIO_FUNCION;
GO
```

---

### 5.2. Demostración: Control de Beneficio Diario
```sql
USE CINEMA;
GO

DELETE FROM COMPRA WHERE id_compra IN (101, 102, 103);

-- 1. CASO EXITOSO: Compra sin beneficio (id_beneficio = NULL)
INSERT INTO COMPRA (id_compra, fecha, dni, id_beneficio) 
VALUES (101, '2026-11-10', 30111222, NULL);
PRINT '-> Prueba 1 (Sin beneficio): ÉXITO';
GO

-- 2. CASO EXITOSO: Primera compra del día CON beneficio (id_beneficio = 2)
INSERT INTO COMPRA (id_compra, fecha, dni, id_beneficio) 
VALUES (102, '2026-11-10', 30111222, 2);
PRINT '-> Prueba 2 (Primer beneficio del día): ÉXITO';
GO

-- 3. CASO BLOQUEADO: Segunda compra del mismo usuario el mismo día con otro beneficio (id_beneficio = 3)
-- El trigger arroja excepción y cancela la transacción.
INSERT INTO COMPRA (id_compra, fecha, dni, id_beneficio) 
VALUES (103, '2026-11-10', 30111222, 3);
PRINT '-> Prueba 3 (Segundo beneficio el mismo día): Debería haber fallado arriba.';
GO
```

---

### 5.3. Demostración: Horario de Función Iniciada
```sql
USE CINEMA;
GO

-- 1. Crear función con fecha en el pasado
INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala) 
VALUES (99, '2026-10-28', '15:00:00', 4000, 1, 1, 1);

-- 2. Intentar registrar una compra para la función vencida
-- El trigger rechaza la operación con error 'RECHAZADO LA FUNCION YA COMENZÓ.'
INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion, id_butaca) 
VALUES (1, 1, 99, 1);
GO
```

---

### 5.4. Demostración: Actualización Automática a "Agotada"
```sql
USE CINEMA;
GO

-- 1. Crear sala pequeña de capacidad 2 y una función programada (Estado 1)
INSERT INTO SALA (id_sala, capacidad) VALUES (99, 2);

INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala) 
VALUES (98, '2026-11-20', '20:00:00', 4500, 1, 1, 99);

-- 2. Vender 2 tickets para llenar la capacidad de la sala
INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion, id_butaca) VALUES (1, 1, 98, 1);
INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion, id_butaca) VALUES (1, 2, 98, 2);

-- 3. Verificación del estado de la función (debe ser 3 = 'Entradas Agotadas')
SELECT id_funcion, id_estado_funcion 
FROM FUNCION 
WHERE id_funcion = 98;
GO
```

---

### 5.5. Demostración: Prevención de Superposición de Horarios
```sql
USE CINEMA;
GO

-- 1. Insertar primera función en Sala 1 de 18:00 a 20:43 (148 min + 15 min de margen)
INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala)
VALUES (201, '2026-12-01', '18:00:00', 5000, 1, 1, 1);

-- 2. Intentar programar otra función en Sala 1 a las 19:30 (Conflicto de horario)
-- El trigger bloquea la inserción con mensaje 'YA EXISTE UNA FUNCION PROGRAMADA DENTRO DEL HORARIO ELEGIDO.'
INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala)
VALUES (202, '2026-12-01', '19:30:00', 5000, 2, 1, 1);
GO
```

---

## 6. Conclusión

Con la inclusión de los **5 triggers** (`trg_AuditoriaPrecioFuncion`, `trg_UnicoBeneficioPorUsuarioFecha`, `trg_ValidarHorarioFuncion`, `trg_ActualizarEstadoFuncionAgotada` y `trg_ValidarSuperposicionFunciones`), la base de datos de **CineMaCtes** logra un nivel integral de **auditoría automática, control transaccional y protección de reglas de negocio**. El motor **SQL Server Express** asume el control directo sobre la integridad de las tarifas, salas y ventas, garantizando un funcionamiento robusto e incorruptible.
