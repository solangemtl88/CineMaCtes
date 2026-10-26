USE CINEMA
GO
--Comprobante--
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
    -- Datos del beneficio (si no usó, se muestra como 'Sin beneficio')
    ISNULL(b.descripcion_, 'Sin beneficio') AS beneficio_aplicado,
    ISNULL(b.descuento, 0) AS porcentaje_descuento,
    
    -- Total general bruto (sin descuento)
    SUM(f.precio * cf.cantidad) OVER (PARTITION BY c.id_compra) AS [Total Bruto],
    
    -- Total general aplicando el descuento si lo tuviera
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
-- Usamos LEFT JOIN porque la compra puede o no tener un beneficio asociado
LEFT JOIN USUARIO_BENEFICIO AS ub ON c.id_compra = ub.id_compra
LEFT JOIN BENEFICIO AS b ON ub.id_beneficio = b.id_beneficio;

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


-- Consultas para verificar datos


-- Ver contenido completo de cada tabla

SELECT * FROM USUARIO;
SELECT * FROM BENEFICIO;
SELECT * FROM SALA;
SELECT * FROM ESTADO_FUNCION;
SELECT * FROM PELICULA;
SELECT * FROM ETIQUETA;
SELECT * FROM COMPRA;
SELECT * FROM FUNCION;
SELECT * FROM BUTACA;
SELECT * FROM PELICULA_ETIQUETA;
SELECT * FROM COMPRA_FUNCION;
SELECT * FROM USUARIO_BENEFICIO;

-- Contar registros de cada tabla por separado

SELECT COUNT(*) AS registros_USUARIO FROM USUARIO;
SELECT COUNT(*) AS registros_BENEFICIO FROM BENEFICIO;
SELECT COUNT(*) AS registros_SALA FROM SALA;
SELECT COUNT(*) AS registros_ESTADO_FUNCION FROM ESTADO_FUNCION;
SELECT COUNT(*) AS registros_PELICULA FROM PELICULA;
SELECT COUNT(*) AS registros_ETIQUETA FROM ETIQUETA;
SELECT COUNT(*) AS registros_COMPRA FROM COMPRA;
SELECT COUNT(*) AS registros_FUNCION FROM FUNCION;
SELECT COUNT(*) AS registros_BUTACA FROM BUTACA;
SELECT COUNT(*) AS registros_PELICULA_ETIQUETA FROM PELICULA_ETIQUETA;
SELECT COUNT(*) AS registros_COMPRA_FUNCION FROM COMPRA_FUNCION;
SELECT COUNT(*) AS registros_USUARIO_BENEFICIO FROM USUARIO_BENEFICIO;


--Pel�culas con recaudaci�n total mayor a 4000
SELECT 
    p.titulo AS Pelicula, 
    SUM(f.precio * cf.cantidad) AS Recaudacion_Total
FROM PELICULA p
JOIN FUNCION f ON p.id_pelicula = f.id_pelicula
JOIN COMPRA_FUNCION cf ON f.id_funcion = cf.id_funcion
GROUP BY p.titulo
HAVING SUM(f.precio * cf.cantidad) > 4000;


--Usuarios que compraron entradas para funciones (con Subconsulta)
SELECT 
    u.dni, 
    u.nombre, 
    u.apellido, 
    u.correo
FROM USUARIO u
WHERE u.dni IN (
    SELECT c.dni 
    FROM COMPRA c
    JOIN COMPRA_FUNCION cf ON c.id_compra = cf.id_compra
);


--Funciones con compras mayores a 1 entrada
SELECT 
    f.id_funcion, 
    p.titulo AS Pelicula, 
    f.fecha, 
    f.hora, 
    cf.cantidad AS Entradas_En_Compra
FROM FUNCION f
JOIN PELICULA p ON f.id_pelicula = p.id_pelicula
JOIN COMPRA_FUNCION cf ON f.id_funcion = cf.id_funcion
GROUP BY f.id_funcion, p.titulo, f.fecha, f.hora, cf.cantidad
HAVING cf.cantidad >= 2;