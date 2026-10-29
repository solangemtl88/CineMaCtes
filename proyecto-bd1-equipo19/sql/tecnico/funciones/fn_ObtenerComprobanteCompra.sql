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
    
    WHERE (@id_compra IS NULL OR c.id_compra = @id_compra)
);
GO


SELECT * 
FROM dbo.fn_ObtenerComprobanteCompra(1);
GO

SELECT * 
FROM dbo.fn_ObtenerComprobanteCompra(NULL);
GO