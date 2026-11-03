# Etapa 5: Manejo de Transacciones en SQL Server Express

## 1. Definición y Objetivo

En sistemas de gestión de bases de datos relacionales como **SQL Server Express**, una **Transacción** es una unidad lógica de trabajo (*Logical Unit of Work*) que agrupa una o más sentencias SQL (`INSERT`, `UPDATE`, `DELETE`) para que se ejecuten en forma de un conjunto indivisible.

El objetivo fundamental del manejo transaccional en el sistema **CineMaCtes** es garantizar las cuatro propiedades fundamentales **ACID**:
* **Atomicidad (*Atomicity*):** Garantiza que todas las operaciones dentro de la transacción se completen con éxito (`COMMIT`), o bien que ninguna de ellas tenga efecto en la base de datos (`ROLLBACK`), evitando registros incompletos o inconsistentes.
* **Consistencia (*Consistency*):** Asegura que la base de datos pase de un estado válido a otro estado válido, respetando todas las restricciones de integridad, claves foráneas y reglas de negocio.
* **Aislamiento (*Isolation*):** Garantiza que la ejecución concurrente de múltiples transacciones no genere interferencias ni lecturas/escrituras sucias entre usuarios simultáneos .
* **Durabilidad (*Durability*):** Asegura que una vez que una transacción ha sido confirmada (`COMMIT`), los cambios persistan de forma permanente en el almacenamiento físico, incluso ante fallos de energía o caídas del servidor.

---

## 2. Ventajas y Aplicaciones (Por qué fue elegido)

La venta de boletos en **CineMaCtes** involucra operaciones complejas que modifican múltiples tablas simultáneamente (`COMPRA` y `COMPRA_FUNCION`). La adopción del control transaccional explícito se justifica por:

1. **Prevención de Venta Incompleta / Asiento Fantasma:** Si se registra la cabecera de la compra en la tabla `COMPRA` pero la asignación de la butaca en `COMPRA_FUNCION` falla (por ejemplo, porque otro cliente reservó la misma butaca un milisegundo antes), la transacción deshace automáticamente la cabecera mediante `ROLLBACK`, impidiendo que existan facturas sin boletos asignados.
2. **Protección ante Concurrencia de Usuarios:** Evita la sobreventa o doble reserva del mismo asiento durante horas pico de alta demanda en taquilla o venta web.
3. **Manejo Estructurado de Errores con `TRY...CATCH`:** Captura cualquier anomalía de ejecución o violación de reglas de negocio en el bloque `TRY` y delega la revocación atómica al bloque `CATCH` mediante `@@TRANCOUNT > 0`.

---

## 3. Implementación en SQL Server Express

En **SQL Server Express**, el control transaccional explícito se implementa mediante las siguientes sentencias T-SQL:

* **`BEGIN TRANSACTION`:** Marca el punto de inicio de la unidad de trabajo atómica y activa el seguimiento de operaciones en el log de transacciones (`sys.sysprocesses` / `sys.dm_tran_active_transactions`).
* **`COMMIT TRANSACTION`:** Confirma de forma definitiva todos los cambios realizados durante la transacción y libera los bloqueos de filas/tablas retenidos en memoria.
* **`ROLLBACK TRANSACTION`:** Revierte la totalidad de los cambios efectuados desde el último `BEGIN TRANSACTION`, dejando la base de datos en su estado previo original.
* **`BEGIN TRY ... BEGIN CATCH`:** Estructura de control de errores donde se evalúa `IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;` para asegurar la anulación inmediata ante cualquier excepción.

---

## 4. Caso Concreto Aplicado al Sistema CineMaCtes

El manejo transaccional se integró directamente en el procedimiento almacenado principal de ventas: **`dbo.sp_RegistrarCompraBoleto`**.

### Flujo Operativo y Reglas de Negocio Integradas:
1. **Validación Previa:** Se verifica que la función exista y que no haya comenzado hace más de 15 minutos.
2. **Apertura de Transacción (`BEGIN TRANSACTION`):** Se inicia el bloque atómico.
3. **Verificación de Butaca Ocupada:** Se consulta `COMPRA_FUNCION` para el `@id_funcion` e `@id_butaca`. Si la butaca ya está ocupada, se dispara `RAISERROR`, se ejecuta `ROLLBACK TRANSACTION` y se detiene el flujo.
4. **Inserción de Cabecera:** Se calcula el id correlativo y se inserta en `COMPRA`.
5. **Inserción de Detalle:** Se inserta el registro en `COMPRA_FUNCION`.
6. **Confirmación (`COMMIT TRANSACTION`):** Si todas las inserciones fueron exitosas, se consolida la operación de venta.

---

## 5. Scripts de Demostración y Resultados Obtenidos

### 5.1. Código SQL del Procedimiento Transaccional

```sql
USE CINEMA;
GO

IF OBJECT_ID(N'dbo.sp_RegistrarCompraBoleto') IS NOT NULL
    DROP PROCEDURE dbo.sp_RegistrarCompraBoleto;
GO

CREATE PROCEDURE dbo.sp_RegistrarCompraBoleto
    @dni INT,
    @id_funcion INT,
    @id_butaca INT,
    @id_beneficio INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @fecha_funcion DATETIME;
    DECLARE @minutos_diferencia INT;

    -- 1. Unir fecha y hora de la función sin errores de tipo o conversión regional
    SELECT @fecha_funcion = DATEADD(SECOND, DATEDIFF(SECOND, '00:00:00', CAST(f.hora AS TIME)), CAST(f.fecha AS DATETIME))
    FROM FUNCION f
    WHERE f.id_funcion = @id_funcion;

    -- Validar existencia de la función
    IF @fecha_funcion IS NULL
    BEGIN
        RAISERROR('La función especificada no existe en el sistema.', 16, 1);
        RETURN;
    END

    -- 2. VALIDACIÓN DE NEGOCIO: Límite de 15 minutos desde el inicio
    SET @minutos_diferencia = DATEDIFF(MINUTE, @fecha_funcion, GETDATE());

    IF @minutos_diferencia > 15
    BEGIN
        RAISERROR('No se pueden vender entradas. La función ya comenzó hace más de 15 minutos.', 16, 1);
        RETURN;
    END

    -- 3. INICIO DE TRANSACCIÓN (Garantía ACID)
    BEGIN TRANSACTION;

    BEGIN TRY
        -- A. Verificar si la butaca ya fue ocupada para esta función
        IF EXISTS (SELECT 1 FROM COMPRA_FUNCION WHERE id_funcion = @id_funcion AND id_butaca = @id_butaca)
        BEGIN
            RAISERROR('La butaca seleccionada ya no se encuentra disponible.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- B. Obtener el siguiente id_compra correlativo para el esquema actual
        DECLARE @nuevo_id_compra INT;
        SELECT @nuevo_id_compra = ISNULL(MAX(id_compra), 0) + 1 FROM COMPRA;

        -- C. Registrar la cabecera de la compra
        INSERT INTO COMPRA (id_compra, fecha, dni, id_beneficio) 
        VALUES (@nuevo_id_compra, CAST(GETDATE() AS DATE), @dni, @id_beneficio);

        -- D. Registrar el detalle en COMPRA_FUNCION
        INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion, id_butaca)
        VALUES (1, @nuevo_id_compra, @id_funcion, @id_butaca);

        -- Confirmar cambios atómicamente
        COMMIT TRANSACTION;
        PRINT '¡Boleto registrado y butaca asignada con éxito!';

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
```

---

### 5.2. Lote de Pruebas de Atomicidad y Manejo de Concurrencia

#### Caso 1: Compra Exitosa (Confirmación con `COMMIT TRANSACTION`)
```sql
PRINT '--- EJECUTANDO CASO 1: Compra Exitosa ---';
EXEC dbo.sp_RegistrarCompraBoleto
    @dni = 30111222,
    @id_funcion = 1,
    @id_butaca = 2,
    @id_beneficio = NULL;
GO

-- Consultas de verificación posterior al Caso 1:
SELECT * FROM COMPRA WHERE dni = 30111222;
SELECT * FROM COMPRA_FUNCION WHERE id_funcion = 1 AND id_butaca = 2;
GO
```
* **Resultado Obtenido:** Impresión del mensaje `'¡Boleto registrado y butaca asignada con éxito!'`. Tanto la cabecera en `COMPRA` como el detalle en `COMPRA_FUNCION` se persisten atómicamente.

#### Caso 2: Intento de Sobreventa de Butaca (Reversión con `ROLLBACK TRANSACTION`)
```sql
PRINT '--- EJECUTANDO CASO 2: Butaca ya ocupada ---';
EXEC dbo.sp_RegistrarCompraBoleto
    @dni = 31222333,
    @id_funcion = 1,
    @id_butaca = 2, -- Butaca asignada en el Caso 1
    @id_beneficio = NULL;
GO
```
* **Resultado Obtenido:** El motor detecta la duplicidad en `COMPRA_FUNCION`, ejecuta el bloque de reversión `ROLLBACK TRANSACTION` y muestra el mensaje controlado:  
  `Mensaje 50000, Nivel 16, Estado 1, Procedimiento dbo.sp_RegistrarCompraBoleto: La butaca seleccionada ya no se encuentra disponible.`. No queda ningún registro huérfano en `COMPRA`.

#### Caso 3: Regla de Negocio - Función Iniciada (> 15 Minutos)
```sql
PRINT '--- EJECUTANDO CASO 3: Intento de compra para función ya iniciada ---';
EXEC dbo.sp_RegistrarCompraBoleto
    @dni = 30111222,
    @id_funcion = 99, -- Función del día anterior
    @id_butaca = 3,
    @id_beneficio = NULL;
GO
```
* **Resultado Obtenido:** El procedimiento interrumpe la ejecución antes de iniciar la transacción devolviendo:  
  `Mensaje 50000, Nivel 16, Estado 1: No se pueden vender entradas. La función ya comenzó hace más de 15 minutos.`.

#### Caso 4: Control de Errores - Función Inexistente
```sql
PRINT '--- EJECUTANDO CASO 4: Función inexistente ---';
EXEC dbo.sp_RegistrarCompraBoleto
    @dni = 33444555,
    @id_funcion = 99999, -- ID que no existe en el sistema
    @id_butaca = 1,
    @id_beneficio = NULL;
GO
```
* **Resultado Obtenido:** Cancelación limpia con el mensaje: `'La función especificada no existe en el sistema.'`.

---

## 6. Conclusión

El uso de transacciones explícitas con `BEGIN TRANSACTION`, `COMMIT` y `ROLLBACK` en **CineMaCtes** asegura el cumplimiento irrestricto de las propiedades ACID. Esto garantiza que cada proceso de venta sea 100% atómico, protegiendo la base de datos contra la sobreventa de asientos, inconsistencias por cierres inesperados o lecturas concurrentes conflictivas.
