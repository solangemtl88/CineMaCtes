USE CINEMA
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