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


