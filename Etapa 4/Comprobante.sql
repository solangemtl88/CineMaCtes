USE CINEMA
GO

SELECT c.id_compra, c.fecha, u.dni, u.nombre, u.apellido, p.titulo,
f.fecha AS fecha_funcion,
f.hora AS hora_funcion,
cf.cantidad,
f.precio,
(f.precio*cf.cantidad) AS [Subtotal], --Calculamos subtotal por cada renglon
SUM(f.precio * cf.cantidad) OVER (PARTITION BY c.id_compra) AS [Total General]
FROM COMPRA AS c
JOIN USUARIO AS u ON c.dni = u.dni
JOIN COMPRA_FUNCION AS cf ON c.id_compra = cf.id_compra
JOIN FUNCION AS f ON cf.id_funcion = f.id_funcion
JOIN PELICULA AS p ON f.id_pelicula = p.id_pelicula;


-- -----------------------------------------------------------------------------
-- 2. REPORTE AGREGADO
-- -----------------------------------------------------------------------------

SELECT 
    e.id_etiqueta,
    e.descripcion AS categoria_producto,
    COUNT(DISTINCT c.id_compra) AS cantidad_ventas_realizadas,
    SUM(cf.cantidad) AS cantidad_boletos_vendidos,
    SUM(cf.cantidad * f.precio) AS total_recaudado
FROM ETIQUETA e
INNER JOIN PELICULA_ETIQUETA pe ON e.id_etiqueta = pe.id_etiqueta
INNER JOIN PELICULA p ON pe.id_pelicula = p.id_pelicula
INNER JOIN FUNCION f ON p.id_pelicula = f.id_pelicula
INNER JOIN COMPRA_FUNCION cf ON f.id_funcion = cf.id_funcion
INNER JOIN COMPRA c ON cf.id_compra = c.id_compra
WHERE c.fecha BETWEEN '2024-01-01' AND '2026-12-31'
GROUP BY e.id_etiqueta, e.descripcion
ORDER BY total_recaudado DESC;




