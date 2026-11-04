-- indices de optimizacion del sistema CINEMA
-- Aceleran consultas frecuentes: cartelera, compras por cliente, butacas, generos.
 
USE CINEMA;
GO
 
-- 1. Cartelera por fecha (incluye las columnas que muestra el listado)
CREATE NONCLUSTERED INDEX IX_FUNCION_Fecha_Cobertura
ON dbo.FUNCION (fecha)
INCLUDE (hora, precio, id_pelicula, id_sala, id_estado_funcion);
GO
 
-- 2. Funciones de una pelicula en un rango de fechas
CREATE NONCLUSTERED INDEX IX_FUNCION_Pelicula_Fecha
ON dbo.FUNCION (id_pelicula, fecha);
GO
 
-- 3. Compras de un cliente (por DNI)
CREATE NONCLUSTERED INDEX IX_COMPRA_Dni
ON dbo.COMPRA (dni)
INCLUDE (fecha, id_beneficio);
GO
 
-- 4. Ventas por periodo (reportes)
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
 
-- 7. Peliculas de un género
CREATE NONCLUSTERED INDEX IX_PELICULA_ETIQUETA_Etiqueta
ON dbo.PELICULA_ETIQUETA (id_etiqueta, id_pelicula);
GO
 

-- Verificacion: lista los indices creados
SELECT t.name AS tabla,
       i.name AS indice,
       i.type_desc AS tipo
FROM sys.indexes i
JOIN sys.tables t ON t.object_id = i.object_id
WHERE i.name LIKE 'IX[_]%'
ORDER BY t.name, i.name;
GO
