
-- Consultas para verificar datos


USE CINEMA;

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


--Películas con recaudación total mayor a 4000
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