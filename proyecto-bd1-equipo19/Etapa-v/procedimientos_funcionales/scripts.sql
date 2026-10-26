CREATE FUNCTION dbo.fn_ObtenerComprobanteCompra (@id_compra INT = NULL)
RETURNS TABLE
AS
RETURN
(
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
    LEFT JOIN USUARIO_BENEFICIO AS ub ON c.id_compra = ub.id_compra
    LEFT JOIN BENEFICIO AS b ON ub.id_beneficio = b.id_beneficio
    
    -- Filtro flexible: si se manda un ID específico lo filtra, si manda NULL trae todo
    WHERE (@id_compra IS NULL OR c.id_compra = @id_compra)
);
GO

--Consulta para ver el comprobante de una compra especifica:

SELECT * FROM dbo.fn_ObtenerComprobanteCompra(5);

--Consulta para ver todos los comprobantes juntos:

SELECT * FROM dbo.fn_ObtenerComprobanteCompra(NULL);