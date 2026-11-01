USE CINEMA;
GO

IF OBJECT_ID(N'dbo.sp_RegistrarCompraBoleto') IS NOT NULL
    DROP PROCEDURE dbo.sp_RegistrarCompraBoleto;
GO

CREATE PROCEDURE dbo.sp_RegistrarCompraBoleto
    @dni INT,
    @id_funcion INT,
    @id_butaca INT,
    @id_beneficio INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @fecha_funcion DATETIME;
    DECLARE @minutos_diferencia INT;

    -- 1. Unir fecha y hora de la función sin errores de tipo o conversión regional
    SELECT @fecha_funcion = DATEADD(SECOND, DATEDIFF(SECOND, '00:00:00', CAST(f.hora AS TIME)), CAST(f.fecha AS DATETIME))
    FROM FUNCION f
    WHERE f.id_funcion = @id_funcion;

    -- Validar existencia de la función
    IF @fecha_funcion IS NULL
    BEGIN
        RAISERROR('La función especificada no existe en el sistema.', 16, 1);
        RETURN;
    END

    -- 2. VALIDACIÓN DE NEGOCIO: Límite de 15 minutos desde el inicio
    SET @minutos_diferencia = DATEDIFF(MINUTE, @fecha_funcion, GETDATE());

    IF @minutos_diferencia > 15
    BEGIN
        RAISERROR('No se pueden vender entradas. La función ya comenzó hace más de 15 minutos.', 16, 1);
        RETURN;
    END

    -- 3. INICIO DE TRANSACCIÓN (Garantía ACID)
    BEGIN TRANSACTION;

    BEGIN TRY
        -- A. Verificar si la butaca ya fue ocupada para esta función
        IF EXISTS (SELECT 1 FROM COMPRA_FUNCION WHERE id_funcion = @id_funcion AND id_butaca = @id_butaca)
        BEGIN
            RAISERROR('La butaca seleccionada ya no se encuentra disponible.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- B. Obtener el siguiente id_compra correlativo para tu esquema actual
        DECLARE @nuevo_id_compra INT;
        SELECT @nuevo_id_compra = ISNULL(MAX(id_compra), 0) + 1 FROM COMPRA;

        -- C. Registrar la cabecera de la compra
        INSERT INTO COMPRA (id_compra, fecha, dni, id_beneficio) 
        VALUES (@nuevo_id_compra, CAST(GETDATE() AS DATE), @dni, @id_beneficio);

        -- D. Registrar el detalle en COMPRA_FUNCION
        INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion, id_butaca)
        VALUES (1, @nuevo_id_compra, @id_funcion, @id_butaca);

        -- Confirmar cambios atómicamente
        COMMIT TRANSACTION;
        PRINT '¡Boleto registrado y butaca asignada con éxito!';

    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO
