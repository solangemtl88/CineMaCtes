# Etapa 5 — Optimización de Consultas e Índices

## 1. Definición y Objetivo

En bases de datos relacionales como **SQL Server Express**, los **Índices** son estructuras en árbol B (*B-Tree*) asociadas a una tabla o vista que aceleran la localización y recuperación de registros sin necesidad de realizar una lectura secuencial completa [13].

* **Índices Agrupados (*Clustered Indexes*):** Definen el orden físico en el que se almacenan y organizan las filas en el disco. En SQL Server se generan automáticamente sobre la Clave Primaria (*Primary Key*) de cada tabla.
* **Índices No Agrupados (*Non-Clustered Indexes*):** Mantienen una estructura de índice separada de las filas de datos reales, conteniendo punteros hacia las filas físicas.
* **Índices de Cobertura (*Covering Indexes* con `INCLUDE`):** Son índices no agrupados a los que se les añaden columnas adicionales no clave dentro de sus hojas. Esto permite que el motor responda consultas completas directamente desde la estructura del índice (*Index Seek* / *Scan*), evitando el salto costoso a las páginas de la tabla (*Key Lookup* o *Bookmark Lookup*).

**Objetivo principal:** Minimizar las lecturas de páginas en disco (E/S - Input/Output), reducir el uso de CPU y acelerar significativamente la velocidad de ejecución de las consultas más frecuentes de la base de datos.

---

## 2. Ventajas y Aplicaciones (Por qué fue elegido)

En el sistema **CineMaCtes**, a medida que se acumulan transacciones de compra, funciones y clientes, el escaneo completo de tablas (*Table Scan*) afectaría el rendimiento general del sistema.

### Ventajas clave para CineMaCtes:
1. **Reducción del Tiempo de Búsqueda:** Transforma escaneos lineales (complejidad $O(N)$) en búsquedas en árbol (complejidad $O(\log N)$).
2. **Eliminación de *Key Lookups* mediante `INCLUDE`:** Al incluir columnas como `hora`, `precio`, `id_pelicula` o `id_sala` en las hojas del índice, las consultas de cartelera se resuelven completamente en el índice.
3. **Agilidad en Reportes y Filtros:** Acelera los filtrados por rangos de fechas (`WHERE fecha ...`), búsquedas por DNI de usuario y agrupamientos por categorías.
4. **Optimización del Mapa de Asientos:** Permite consultar la disponibilidad de butacas por función instantáneamente.

---

## 3. Implementación en SQL Server Express

En **SQL Server Express**, los índices no agrupados con cobertura se crean utilizando la instrucción `CREATE NONCLUSTERED INDEX` junto con la cláusula `INCLUDE`:

```sql
CREATE NONCLUSTERED INDEX IX_NombreIndice
ON dbo.Tabla (ColumnaBusqueda1, ColumnaBusqueda2)
INCLUDE (ColumnaDato1, ColumnaDato2);
GO
```

### Elementos Técnicos:
* **Columnas Clave (en `ON`):** Columnas utilizadas para filtrar (`WHERE`), unir (`JOIN`) u ordenar (`ORDER BY`).
* **Columnas Incluidas (en `INCLUDE`):** Columnas requeridas en el `SELECT` que se almacenan en las hojas del índice para evitar lecturas adicionales a la tabla base.
* **Catálogo `sys.indexes`:** Permite consultar metadatos sobre los índices existentes en el sistema.

---

## 4. Caso Concreto Aplicado al Sistema CineMaCtes

El equipo implementó **7 Índices No Agrupados Estratégicos** para optimizar los principales flujos de consulta del sistema **CineMaCtes**:

| N° | Nombre del Índice | Tabla Impactada | Columnas Clave | Columnas en `INCLUDE` | Caso de Uso / Consulta Optimizada |
| :--- | :--- | :--- | :--- | :--- | :--- |
| 1 | `IX_FUNCION_Fecha_Cobertura` | `FUNCION` | `fecha` | `hora`, `precio`, `id_pelicula`, `id_sala`, `id_estado_funcion` | Cartelera por fecha con cobertura total. |
| 2 | `IX_FUNCION_Pelicula_Fecha` | `FUNCION` | `id_pelicula`, `fecha` | *(N/A)* | Listado de funciones de una película en una fecha específica. |
| 3 | `IX_COMPRA_Dni` | `COMPRA` | `dni` | `fecha`, `id_beneficio` | Historial de compras realizado por un cliente (por DNI). |
| 4 | `IX_COMPRA_Fecha` | `COMPRA` | `fecha` | `dni`, `id_beneficio` | Reportes de ventas y facturación por rango de fechas. |
| 5 | `IX_COMPRA_FUNCION_Funcion` | `COMPRA_FUNCION` | `id_funcion` | `id_butaca`, `cantidad`, `id_compra` | Mapa de asientos ocupados y cálculo de porcentaje de ocupación. |
| 6 | `IX_BUTACA_Sala` | `BUTACA` | `id_sala` | `codigo_butaca` | Listado de butacas pertenecientes a una sala. |
| 7 | `IX_PELICULA_ETIQUETA_Etiqueta` | `PELICULA_ETIQUETA` | `id_etiqueta`, `id_pelicula` | *(N/A)* | Filtrado de catálogo de películas por género o categoría. |

---

## 5. Scripts de Demostración y Resultados Obtenidos

### 5.1. Código SQL de Creación de Índices

```sql
-- Índices de optimización del sistema CINEMA
USE CINEMA;
GO

-- 1. Cartelera por fecha (incluye las columnas que muestra el listado)
CREATE NONCLUSTERED INDEX IX_FUNCION_Fecha_Cobertura
ON dbo.FUNCION (fecha)
INCLUDE (hora, precio, id_pelicula, id_sala, id_estado_funcion);
GO

-- 2. Funciones de una película en un rango de fechas
CREATE NONCLUSTERED INDEX IX_FUNCION_Pelicula_Fecha
ON dbo.FUNCION (id_pelicula, fecha);
GO

-- 3. Compras de un cliente (por DNI)
CREATE NONCLUSTERED INDEX IX_COMPRA_Dni
ON dbo.COMPRA (dni)
INCLUDE (fecha, id_beneficio);
GO

-- 4. Ventas por período (reportes)
CREATE NONCLUSTERED INDEX IX_COMPRA_Fecha
ON dbo.COMPRA (fecha)
INCLUDE (dni, id_beneficio);
GO

-- 5. Butacas vendidas en una función (mapa de asientos)
CREATE NONCLUSTERED INDEX IX_COMPRA_FUNCION_Funcion
ON dbo.COMPRA_FUNCION (id_funcion)
INCLUDE (id_butaca, cantidad, id_compra);
GO

-- 6. Butacas de una sala
CREATE NONCLUSTERED INDEX IX_BUTACA_Sala
ON dbo.BUTACA (id_sala)
INCLUDE (codigo_butaca);
GO

-- 7. Películas de un género
CREATE NONCLUSTERED INDEX IX_PELICULA_ETIQUETA_Etiqueta
ON dbo.PELICULA_ETIQUETA (id_etiqueta, id_pelicula);
GO
```

---

### 5.2. Verificación de Índices Creados en el Motor

Para validar la correcta creación de los 7 índices no agrupados en el catálogo de SQL Server Express, se ejecuta la siguiente consulta de comprobación:

```sql
-- Verificación: lista los índices creados
SELECT t.name AS tabla,
       i.name AS indice,
       i.type_desc AS tipo
FROM sys.indexes i
JOIN sys.tables t ON t.object_id = i.object_id
WHERE i.name LIKE 'IX[_]%'
ORDER BY t.name, i.name;
GO
```

**Resultado Obtenido de la Ejecución:**

| tabla | indice | tipo |
| :--- | :--- | :--- |
| `BUTACA` | `IX_BUTACA_Sala` | `NONCLUSTERED` |
| `COMPRA` | `IX_COMPRA_Dni` | `NONCLUSTERED` |
| `COMPRA` | `IX_COMPRA_Fecha` | `NONCLUSTERED` |
| `COMPRA_FUNCION` | `IX_COMPRA_FUNCION_Funcion` | `NONCLUSTERED` |
| `FUNCION` | `IX_FUNCION_Fecha_Cobertura` | `NONCLUSTERED` |
| `FUNCION` | `IX_FUNCION_Pelicula_Fecha` | `NONCLUSTERED` |
| `PELICULA_ETIQUETA` | `IX_PELICULA_ETIQUETA_Etiqueta` | `NONCLUSTERED` |

---

## 6. Conclusión

La implementación de índices no agrupados con cláusula `INCLUDE` garantiza que el sistema **CineMaCtes** resuelva sus búsquedas más frecuentes directamente en la memoria del índice, minimizando los accesos al disco y asegurando la escalabilidad del sistema de ventas.
