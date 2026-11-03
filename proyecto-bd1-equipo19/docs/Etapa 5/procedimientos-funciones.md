# Etapa 5: Procedimientos y Funciones Almacenadas

## 1. Definición y Objetivo

En la arquitectura de bases de datos relacionales, los **Procedimientos Almacenados** (*Stored Procedures*) y las **Funciones Almacenadas** (*Functions*) son módulos de código T-SQL compilados y guardados directamente dentro del motor SQL Server Express.

* **Funciones Almacenadas (*Functions*):** Son rutinas de programación relacional diseñadas para recibir parámetros de entrada y retornar un valor escalar o un conjunto estructurado en forma de tabla (*Table-Valued Function*). Su objetivo principal es encapsular cálculos computacionales reutilizables, transformaciones de datos o construcciones de consultas complejas sin alterar el estado físico de la base de datos.
* **Procedimientos Almacenados (*Stored Procedures*):** Son programas SQL ejecutables mediante la sentencia `EXEC` que encapsulan secuencias complejas de operaciones DML (`INSERT`, `UPDATE`, `DELETE`) y reglas de negocio. Su objetivo es coordinar flujos de trabajo completos, administrar transacciones y responder a solicitudes directas de la aplicación cliente.

---

## 2. Ventajas y Aplicaciones (Por qué fue elegido)

La adopción de procedimientos y funciones en el sistema **CineMaCtes** responde a criterios de arquitectura empresarial y optimización del motor de base de datos:

1. **Centralización y Reutilización de la Lógica de Negocio:** Evita duplicar lógica (como el cálculo de porcentajes de ocupación de salas o el cómputo de descuentos por beneficios) en múltiples capas de software clientelar.
2. **Reducción del Tráfico en Red:** En lugar de enviar múltiples sentencias SQL individuales desde la aplicación al servidor (por ejemplo, verificar disponibilidad de sala, insertar compra y registrar detalle), la aplicación ejecuta una sola llamada `EXEC` o `SELECT`, disminuyendo la latencia de red.
3. **Planes de Ejecución Precompilados:** SQL Server compila y optimiza el plan de ejecución de procedimientos y funciones en su memoria caché (*buffer pool*), mejorando significativamente los tiempos de respuesta ante llamadas frecuentes.
4. **Seguridad y Control de Acceso Granular:** Permite otorgar permisos de ejecución (`GRANT EXECUTE`) a los usuarios del sistema sin necesidad de darles acceso directo de lectura o escritura sobre las tablas subyacentes (`COMPRA`, `FUNCION`, `BUTACA`), protegiendo la integridad física de los datos.

---

## 3. Implementación en SQL Server Express

En **SQL Server Express**, las funciones y procedimientos se definen utilizando las instrucciones `CREATE FUNCTION` y `CREATE PROCEDURE` dentro del esquema correspondiente (`dbo`):

* **Funciones Escalares (`RETURNS DECIMAL` / `INT`):** Utilizan un bloque `BEGIN ... END` para calcular y devolver un valor único mediante la sentencia `RETURN`. Se invocan directamente en la cláusula `SELECT` utilizando el prefijo obligatorio del esquema (`dbo.nombre_funcion`).
* **Funciones de Tabla en Línea (`RETURNS TABLE`):** Encapsulan una única instrucción `RETURN (SELECT ...)` sin necesidad de bloques `BEGIN ... END`. SQL Server las trata como vistas parametrizadas, permitiendo combinarlas mediante `JOIN` o consultarlas en la cláusula `FROM`.
* **Procedimientos Almacenados (`CREATE PROCEDURE`):** Admiten parámetros con valores por defecto, manejo de excepciones estructurado con `BEGIN TRY ... BEGIN CATCH` y control transaccional implícito o explícito.

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
* **Necesidad de Negocio:** Centralizar la compra de entradas validando restricciones temporales y disponibilidad de asiento.
* **Funcionamiento:** Recibe los datos del usuario, función, butaca y beneficio. Verifica que la función no haya iniciado hace más de 15 minutos. Inicia una transacción atómica `BEGIN TRANSACTION`, valida que la butaca no esté ocupada en `COMPRA_FUNCION`, genera el `id_compra` correlativo, inserta la cabecera en `COMPRA` y el detalle en `COMPRA_FUNCION`, confirmando con `COMMIT TRANSACTION` o revirtiendo con `ROLLBACK` en caso de error.

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

---

### 5.2. Lote de Pruebas y Evidencias de Ejecución

#### Prueba 1: Cálculo de Ocupación por Función
Se ejecuta la consulta integrando la función escalar `dbo.fn_CalcularOcupacionFuncion`:

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

#### Prueba 2: Generación de Comprobantes de Compra (Individual y Global)

**a) Consulta de comprobante específico (ID Compra = 1):**
```sql
SELECT * 
FROM dbo.fn_ObtenerComprobanteCompra(1);
```
**Resultado Obtenido:** Retorna la fila correspondiente a la compra del usuario Juan Pérez para la película *"Inception"*, precio unitario `$4500.00`, Subtotal `$4500.00`, beneficio `'Sin beneficio'`, Total Bruto `$4500.00` y Total Final con Descuento `$4500.00`.

**b) Consulta consolidada de todos los comprobantes (Parametro NULL):**
```sql
SELECT * 
FROM dbo.fn_ObtenerComprobanteCompra(NULL);
```
**Resultado Obtenido:** Retorna la totalidad del registro de facturación del sistema (compras 1 a 11). Se constata la correcta aplicación de descuentos parametrizados según los beneficios asociados a cada usuario:
* **Compra 2:** Beneficio *Estudiante Universitario* (20% descuento), reduciendo un Subtotal/Bruto de `$5000.00` a un Total Final de `$4000.00`.
* **Compra 6:** Beneficio *Socio Cine Club* (15% descuento), reduciendo `$9600.00` (2 entradas) a `$8160.00`.
* **Compra 7:** Beneficio *Descuento Banco Galicia* (25% descuento), reduciendo `$4500.00` a `$3375.00`.
* **Compra 9:** Beneficio *Cumpleañero* (50% descuento), reduciendo `$4000.00` a `$2000.00`.

---

## 6. Conclusión

La implementación de funciones y procedimientos almacenados en **CineMaCtes** permite abstraer la complejidad computacional y las reglas de negocio del sistema. A través de `dbo.fn_CalcularOcupacionFuncion` y `dbo.fn_ObtenerComprobanteCompra`, el motor procesa dinámicamente indicadores clave y cálculos financieros con un rendimiento óptimo, garantizando consistencia y mantenibilidad técnica en las etapas de explotación del sistema.
