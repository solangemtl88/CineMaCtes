# Etapa V: Procedimientos y Funciones Almacenadas

## 1. Definición y Objetivo

En la arquitectura de bases de datos relacionales, los **Procedimientos Almacenados** (*Stored Procedures*) y las **Funciones Almacenadas** (*Functions*) son módulos de código T-SQL compilados y guardados directamente dentro del motor SQL Server Express.

* **Funciones Almacenadas (*Functions*):** Son rutinas de programación relacional diseñadas para recibir parámetros de entrada y retornar un valor escalar o un conjunto estructurado en forma de tabla (*Table-Valued Function*). Su objetivo principal es encapsular cálculos computacionales reutilizables, transformaciones de datos o construcciones de consultas complejas sin alterar el estado físico de la base de datos.
* **Procedimientos Almacenados (*Stored Procedures*):** Son programas SQL ejecutables mediante la sentencia `EXEC` que encapsulan secuencias complejas de operaciones DML (`INSERT`, `UPDATE`, `DELETE`) y reglas de negocio. Su objetivo es coordinar flujos de trabajo completos, administrar transacciones y responder a solicitudes directas de la aplicación cliente.

---

## 2. Ventajas y Aplicaciones (Por qué fue elegido)

La adopción de procedimientos y funciones en el sistema **CineMaCtes** responde a criterios de arquitectura empresarial y optimización del motor de base de datos:

1. **Centralización y Reutilización de la Lógica de Negocio:** Evita duplicar lógica (como el cálculo de porcentajes de ocupación de salas, emisión de comprobantes o el registro seguro de ventas) en múltiples capas de software clientelar.
2. **Reducción del Tráfico en Red:** En lugar de enviar múltiples sentencias SQL individuales desde la aplicación al servidor (por ejemplo, verificar disponibilidad de sala, verificar horario de función, insertar compra y registrar detalle), la aplicación ejecuta una sola llamada `EXEC` o `SELECT`, disminuyendo la latencia de red.
3. **Planes de Ejecución Precompilados:** SQL Server compila y optimiza el plan de ejecución de procedimientos y funciones en su memoria caché (*buffer pool*), mejorando significativamente los tiempos de respuesta ante llamadas frecuentes.
4. **Seguridad y Control de Acceso Granular:** Permite otorgar permisos de ejecución (`GRANT EXECUTE`) a los usuarios del sistema sin necesidad de darles acceso directo de lectura o escritura sobre las tablas subyacentes (`COMPRA`, `FUNCION`, `BUTACA`), protegiendo la integridad física de los datos.

---

## 3. Implementación en SQL Server Express

En **SQL Server Express**, las funciones y procedimientos se definen utilizando las instrucciones `CREATE FUNCTION` y `CREATE PROCEDURE` dentro del esquema correspondiente (`dbo`):

* **Funciones Escalares (`RETURNS DECIMAL` / `INT`):** Utilizan un bloque `BEGIN ... END` para calcular y devolver un valor único mediante la sentencia `RETURN`. Se invocan directamente en la cláusula `SELECT` utilizando el prefijo obligatorio del esquema (`dbo.nombre_funcion`).
* **Funciones de Tabla en Línea (`RETURNS TABLE`):** Encapsulan una única instrucción `RETURN (SELECT ...)` sin necesidad de bloques `BEGIN ... END`. SQL Server las trata como vistas parametrizadas, permitiendo combinarlas mediante `JOIN` o consultarlas en la cláusula `FROM`.
* **Procedimientos Almacenados (`CREATE PROCEDURE`):** Admiten parámetros con valores por defecto, manejo de excepciones estructurado con `BEGIN TRY ... BEGIN CATCH` y control transaccional implícito o explícito (`BEGIN TRANSACTION`, `COMMIT`, `ROLLBACK`).

---

## 4. Caso Concreto Aplicado al Sistema CineMaCtes

Para responder a los requerimientos operativos de **CineMaCtes**, se implementaron dos funciones almacenadas y un procedimiento almacenado específico:

### 4.1. Función Escalar: `dbo.fn_CalcularOcupacionFuncion`
* **Necesidad de Negocio:** Conocer en tiempo real el porcentaje de ocupación de la sala asignada a una función de cine específica.
* **Funcionamiento:** Recibe el parámetro `@id_funcion INT`. Consulta la capacidad total de la sala mediante `JOIN SALA`. Luego cuenta las entradas/butacas efectivamente vendidas en `COMPRA_FUNCION`. Previene errores de división por cero y retorna el porcentaje redondeado a dos decimales (`DECIMAL(5,2)`).

### 4.2. Función Tabulada: `dbo.fn_ObtenerComprobanteCompra`
* **Necesidad de Negocio:** Generar la factura/comprobante de compra de entradas para un cliente en particular o el listado consolidado de comprobantes del sistema.
* **Funcionamiento:** Recibe `@id_compra INT = NULL`. Si se pasa un ID, filtra dicho comprobante; si se pasa `NULL`, retorna todas las compras. Vincula las tablas `COMPRA`, `USUARIO`, `COMPRA_FUNCION`, `FUNCION`, `PELICULA` y `BENEFICIO`. Utiliza una función de ventana `SUM(f.precio * cf.cantidad) OVER (PARTITION BY c.id_compra)` para calcular el total bruto y aplica expresiones `CASE` con `ISNULL` para computar el descuento porcentual de fidelización y el total final neto.

### 4.3. Procedimiento Almacenado: `dbo.sp_RegistrarCompraBoleto`
* **Necesidad de Negocio:** Centralizar el proceso de venta de entradas garantizando la validación estricta de las reglas de negocio (límite horario de 15 minutos e imposibilidad de sobreventa de butacas).
* **Funcionamiento:** Recibe los parámetros `@dni`, `@id_funcion`, `@id_butaca` y opcionalmente `@id_beneficio`. Valida la existencia de la función e impide la compra si la función inició hace más de 15 minutos. Dentro de un bloque transaccional `BEGIN TRANSACTION`, verifica la disponibilidad de la butaca en `COMPRA_FUNCION`, calcula el `id_compra` correlativo, inserta la cabecera en `COMPRA` y el detalle en `COMPRA_FUNCION`, asegurando atomicidad mediante `COMMIT` o `ROLLBACK` en el bloque `CATCH`.

---

## 5. Scripts de Demostración y Resultados Obtenidos

### 5.1. Código SQL de Implementación

#### a) Función `dbo.fn_CalcularOcupacionFuncion`
```sql
USE CINEMA;
GO

CREATE FUNCTION dbo.fn_CalcularOcupacionFuncion (@id_funcion INT)
RETURNS DECIMAL(5,2)
AS
BEGIN
    DECLARE @porcentaje_ocupacion DECIMAL(5,2);
    DECLARE @capacidad_sala INT;
    DECLARE @butacas_ocupadas INT;

    -- 1. Obtener la capacidad total de la sala para la función
    SELECT @capacidad_sala = s.capacidad
    FROM FUNCION f
    JOIN SALA s ON f.id_sala = s.id_sala
    WHERE f.id_funcion = @id_funcion;

    -- Prevenir división por cero si la función no existe
    IF @capacidad_sala IS NULL OR @capacidad_sala = 0
        RETURN 0;

    -- 2. Contar las butacas ya ocupadas en el detalle
    SELECT @butacas_ocupadas = COUNT(cd.id_butaca)
    FROM COMPRA_FUNCION cd
    WHERE cd.id_funcion = @id_funcion;

    -- 3. Calcular el porcentaje
    SET @porcentaje_ocupacion = (CAST(@butacas_ocupadas AS DECIMAL(5,2)) / CAST(@capacidad_sala AS DECIMAL(5,2))) * 100.0;

    RETURN @porcentaje_ocupacion;
END;
GO
```

#### b) Función `dbo.fn_ObtenerComprobanteCompra`
```sql
USE CINEMA;
GO

IF OBJECT_ID(N'dbo.fn_ObtenerComprobanteCompra') IS NOT NULL
    DROP FUNCTION dbo.fn_ObtenerComprobanteCompra;
GO

CREATE FUNCTION dbo.fn_ObtenerComprobanteCompra (@id_compra INT = NULL)
RETURNS TABLE
AS
RETURN(
    SELECT 
        c.id_compra, 
        c.fecha, 
        u.dni, 
        u.nombre, 
        u.apellido, 
        p.titulo,
        f.fecha AS fecha_funcion,
        f.hora AS hora_funcion,
        cf.cantidad,
        f.precio,        
        (f.precio * cf.cantidad) AS [Subtotal],
        
        ISNULL(b.descripcion_, 'Sin beneficio') AS beneficio_aplicado,
        ISNULL(b.descuento, 0) AS porcentaje_descuento,
        
        SUM(f.precio * cf.cantidad) OVER (PARTITION BY c.id_compra) AS [Total Bruto],
        
        CASE 
            WHEN b.descuento IS NOT NULL THEN 
                SUM(f.precio * cf.cantidad) OVER (PARTITION BY c.id_compra) * (1 - CAST(b.descuento AS DECIMAL(5,2)) / 100.0)
            ELSE 
                SUM(f.precio * cf.cantidad) OVER (PARTITION BY c.id_compra)
        END AS [Total Final Con Descuento]

    FROM COMPRA AS c
    JOIN USUARIO AS u ON c.dni = u.dni
    JOIN COMPRA_FUNCION AS cf ON c.id_compra = cf.id_compra
    JOIN FUNCION AS f ON cf.id_funcion = f.id_funcion
    JOIN PELICULA AS p ON f.id_pelicula = p.id_pelicula
    LEFT JOIN BENEFICIO AS b ON c.id_beneficio = b.id_beneficio
    
    WHERE c.id_compra = ISNULL(@id_compra, c.id_compra)
);
GO
```

#### c) Procedimiento `dbo.sp_RegistrarCompraBoleto`
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

        -- B. Obtener el siguiente id_compra correlativo para tu esquema actual
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

### 5.2. Lote de Pruebas y Evidencias de Ejecución

#### Prueba 1: Cálculo de Ocupación por Función (`dbo.fn_CalcularOcupacionFuncion`)
Se ejecuta la consulta integrando la función escalar:

```sql
SELECT 
    f.id_funcion, 
    p.titulo AS [Pelicula], 
    f.fecha, 
    f.hora, 
    s.capacidad AS [Capacidad_Total_Sala],
    dbo.fn_CalcularOcupacionFuncion(f.id_funcion) AS [Porcentaje_Ocupacion_%]
FROM FUNCION f
JOIN PELICULA p ON f.id_pelicula = p.id_pelicula
JOIN SALA s ON f.id_sala = s.id_sala;
```

**Resultado Obtenido:**
* Para la **Función ID 1** (Película *"Interstellar"*, fecha `2026-11-05`, hora `18:00`, Sala capacidad `120`), la función computa exactamente **0.83%** de ocupación (1 butaca vendida sobre 120 de capacidad).
* Para las funciones 2 a 10 (*"Inception"*, *"The Dark Knight"*, *"Oppenheimer"*, *"Avatar"*, etc.), el resultado retorna **0.00%** al no registrar entradas vendidas aún.

#### Prueba 2: Generación de Comprobantes de Compra (`dbo.fn_ObtenerComprobanteCompra`)

**a) Consulta de comprobante específico (ID Compra = 1):**
```sql
SELECT * 
FROM dbo.fn_ObtenerComprobanteCompra(1);
```
**Resultado Obtenido:** Retorna la fila correspondiente a la compra del usuario Juan Pérez para la película *"Inception"*, precio unitario `$4500.00`, Subtotal `$4500.00`, beneficio `'Sin beneficio'`, Total Bruto `$4500.00` y Total Final con Descuento `$4500.00`.

**b) Consulta consolidada de todos los comprobantes (Parámetro NULL):**
```sql
SELECT * 
FROM dbo.fn_ObtenerComprobanteCompra(NULL);
```
**Resultado Obtenido:** Retorna la totalidad del registro de facturación del sistema (compras 1 a 11). Se constata la correcta aplicación de descuentos parametrizados según los beneficios asociados a cada usuario:
* **Compra 2:** Beneficio *Estudiante Universitario* (20% descuento), reduciendo un Subtotal/Bruto de `$5000.00` a un Total Final de `$4000.00`.
* **Compra 6:** Beneficio *Socio Cine Club* (15% descuento), reduciendo `$9600.00` (2 entradas) a `$8160.00`.
* **Compra 7:** Beneficio *Descuento Banco Galicia* (25% descuento), reduciendo `$4500.00` a `$3375.00`.
* **Compra 9:** Beneficio *Cumpleañero* (50% descuento), reduciendo `$4000.00` a `$2000.00`.

#### Prueba 3: Ejecución de Procedimiento Almacenado (`dbo.sp_RegistrarCompraBoleto`)

**Caso 1: Compra Exitosa**
```sql
EXEC dbo.sp_RegistrarCompraBoleto
    @dni = 30111222,
    @id_funcion = 1,
    @id_butaca = 2,
    @id_beneficio = NULL;
```
* **Resultado Obtenido:** Impresión del mensaje `'¡Boleto registrado y butaca asignada con éxito!'` Verificación en `COMPRA` (id_compra 1, fecha actual, DNI 30111222) y `COMPRA_FUNCION` (id_compra 1, id_funcion 1, id_butaca 2).

**Caso 2: Validación de Butaca Ocupada (Conflicto / Concurrencia)**
```sql
EXEC dbo.sp_RegistrarCompraBoleto
    @dni = 31222333,
    @id_funcion = 1,
    @id_butaca = 2, -- Misma butaca reservada en Caso 1
    @id_beneficio = NULL;
```
* **Resultado Obtenido:** Excepción capturada en bloque `CATCH` con error nivel 16: `'La butaca seleccionada ya no se encuentra disponible.'` y rollback de la transacción.

**Caso 3: Regla de Negocio - Función Iniciada (> 15 minutos)**
```sql
-- Función creada en el pasado (ayer)
EXEC dbo.sp_RegistrarCompraBoleto
    @dni = 30111222,
    @id_funcion = 99, -- Función de ayer
    @id_butaca = 3,
    @id_beneficio = NULL;
```
* **Resultado Obtenido:** Rechazo previo al inicio transaccional con mensaje: `'No se pueden vender entradas. La función ya comenzó hace más de 15 minutos.'`.

**Caso 4: Control de Errores - Función Inexistente**
```sql
EXEC dbo.sp_RegistrarCompraBoleto
    @dni = 33444555,
    @id_funcion = 99999, -- ID inexistente
    @id_butaca = 1,
    @id_beneficio = NULL;
```
* **Resultado Obtenido:** Interrupción controlada con mensaje: `'La función especificada no existe en el sistema.'`.

---

## 6. Conclusión

La implementación de funciones y procedimientos almacenados en **CineMaCtes** permite abstraer la complejidad computacional y las reglas de negocio del sistema. A través de `dbo.fn_CalcularOcupacionFuncion`, `dbo.fn_ObtenerComprobanteCompra` y `dbo.sp_RegistrarCompraBoleto`, el motor procesa dinámicamente indicadores clave, cálculos financieros y transacciones de venta con un rendimiento óptimo, garantizando la consistencia y mantenibilidad técnica en todas las operaciones del sistema.
