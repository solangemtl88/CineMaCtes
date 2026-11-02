

-- Restriccion de un solo beneficio por transaccion de compra
-- Asegura que para un mismo id_compra no pueda existir más de un registro de beneficio aplicado,
-- rechazando cualquier intento posterior de asociarle


USE CINEMA;
GO

CREATE OR ALTER TRIGGER trg_UnicoBeneficioPorUsuarioFecha
ON COMPRA
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Solo evaluamos si en la inserción/actualización se está intentando aplicar un beneficio
    IF EXISTS (SELECT 1 FROM inserted WHERE id_beneficio IS NOT NULL)
    BEGIN
        -- Verificamos si el usuario ya acumuló más de una compra CON beneficio en el mismo día
        IF EXISTS (
            SELECT c.dni, c.fecha
            FROM COMPRA c
            INNER JOIN inserted i ON c.dni = i.dni AND c.fecha = i.fecha
            WHERE c.id_beneficio IS NOT NULL
            GROUP BY c.dni, c.fecha
            HAVING COUNT(c.id_compra) > 1
        )
        BEGIN
            RAISERROR ('DENEGADO: Se excede el limite de beneficios diarios', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END
    END
END;
GO
-- LOTE DE PRUEBAS PARA APLICAR BENEFICIO

USE CINEMA;
GO

-- 1. CASO EXITOSO: Compra sin beneficio (id_beneficio = NULL)
-- Debe insertarse correctamente.
INSERT INTO COMPRA (id_compra, fecha, dni, id_beneficio) 
VALUES (101, '2026-11-10', 30111222, NULL);

PRINT '-> Prueba 1 (Sin beneficio): ÉXITO';
GO

-- 2. CASO EXITOSO: Primera compra del día CON beneficio (Ejemplo: id_beneficio = 2)
-- Debe insertarse correctamente.
INSERT INTO COMPRA (id_compra, fecha, dni, id_beneficio) 
VALUES (102, '2026-11-10', 30111222, 2);

PRINT '-> Prueba 2 (Primer beneficio del día): ÉXITO';
GO

-- 3. CASO BLOQUEADO: Segunda compra del mismo usuario el mismo día INTENTANDO USAR OTRO BENEFICIO (Ejemplo: id_beneficio = 3)
-- El trigger debe saltar, mostrar el error en rojo y cancelar la inserción.
INSERT INTO COMPRA (id_compra, fecha, dni, id_beneficio) 
VALUES (103, '2026-11-10', 30111222, 3);

PRINT '-> Prueba 3 (Segundo beneficio el mismo día): Debería haber fallado arriba.';
GO




-- Objeto: Trigger [dbo].[trg_ValidarHorarioFuncion] Fecha de script: 28/10/2026 15:06:26 --

-- Se encarga de validar el horario que tiene el sistema al momento que se quiere realizar la compra,
-- con el horario en qeu comienza la funcion, ya la funcion ya inicio no se permitirá realizar la compra.

CREATE OR ALTER TRIGGER [dbo].[trg_ValidarHorarioFuncion]
ON [dbo].[COMPRA_FUNCION]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Combinación limpia y segura de DATE y TIME a DATETIME usando DATEADD
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN FUNCION f ON i.id_funcion = f.id_funcion
        WHERE DATEADD(second, DATEDIFF(second, '00:00:00', f.hora), CAST(f.fecha AS DATETIME)) < GETDATE()
    )
    BEGIN
        RAISERROR ('RECHAZADO LA FUNCION YA COMENZÓ.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

--LOTE DE PRUEBAS PARA HORARIO FUNCION

-- 1. Creamos una función ficticia que comenzó ayer
INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala) 
VALUES (99, '2026-10-28', '15:00:00', 4000, 1, 1, 1);

-- 2. Intentamos vender un ticket para esa función del pasado (debe fallar y saltar el error en rojo)
INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion, id_butaca) 
VALUES (1, 1, 99, 1);
GO




-- Suma las entradas vendidas para la función recién comprada; si alcanza o supera la capacidad de la SALA.
-- Se encarga de actualizar automaticamente el estado en que se encuentra la sala, cuando la capacidad de butacass sea 
--  vendida se marcara como "AGOTADA"

CREATE OR ALTER TRIGGER [dbo].[trg_ActualizarEstadoFuncionAgotada]
ON [dbo].[COMPRA_FUNCION]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE f
    SET f.id_estado_funcion = 3 -- ID 3 = 'Entradas Agotadas'
    FROM FUNCION f
    INNER JOIN SALA s ON f.id_sala = s.id_sala
    WHERE f.id_funcion IN (SELECT DISTINCT id_funcion FROM inserted)
      AND f.id_estado_funcion <> 3
      AND (
          SELECT COALESCE(SUM(cf.cantidad), 0)
          FROM COMPRA_FUNCION cf
          WHERE cf.id_funcion = f.id_funcion
      ) >= s.capacidad;
END;
GO

--LOTE DE DATOS DE PRUEBA PARA FUNCION AGOTADA
    
-- 1. Creamos una sala pequeña de capacidad 2 y una función para esa sala
INSERT INTO SALA (id_sala, capacidad) VALUES (99, 2);

INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala) 
VALUES (98, '2026-11-20', '20:00:00', 4500, 1, 1, 99); -- Estado 1 = 'Programada'

-- 2. Vendemos 2 tickets para llenar la capacidad de la sala (capacidad = 2)
INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion, id_butaca) VALUES (1, 1, 98, 1);
INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion, id_butaca) VALUES (1, 2, 98, 2);

-- 3. Verificamos si el estado de la función cambió automáticamente a 3 ('Entradas Agotadas')
SELECT id_funcion, id_estado_funcion 
FROM FUNCION 
WHERE id_funcion = 98;
GO




--  Toma la fecha y hora de inicio de la función entrante, le suma la duración en minutos de la película proyectada

CREATE OR ALTER TRIGGER trg_ValidarSuperposicionFunciones
ON FUNCION
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Se detecta solapamiento en la misma sala y fecha
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN PELICULA p_new ON i.id_pelicula = p_new.id_pelicula
        JOIN FUNCION f_existente ON i.id_sala = f_existente.id_sala
                                AND i.fecha = f_existente.fecha
                                AND i.id_funcion <> f_existente.id_funcion
        JOIN PELICULA p_existente ON f_existente.id_pelicula = p_existente.id_pelicula
        CROSS APPLY (
            -- Extrae únicamente los dígitos de duracion (ej: '148 min' -> 148)
            SELECT COALESCE(
                TRY_CAST(LEFT(p_new.duracion, CHARINDEX(' ', p_new.duracion + ' ') - 1) AS INT),
                120
            ) AS duracion_min_nueva,
            COALESCE(
                TRY_CAST(LEFT(p_existente.duracion, CHARINDEX(' ', p_existente.duracion + ' ') - 1) AS INT),
                120
            ) AS duracion_min_existente
        ) AS mins
        CROSS APPLY (
            -- Inicio y fin de la nueva función (incluye 15 min de limpieza/mantenimiento)
            SELECT 
                DATEADD(second, DATEDIFF(second, '00:00:00', i.hora), CAST(i.fecha AS DATETIME)) AS inicio_nueva,
                DATEADD(MINUTE, mins.duracion_min_nueva + 15, DATEADD(second, DATEDIFF(second, '00:00:00', i.hora), CAST(i.fecha AS DATETIME))) AS fin_nueva
        ) AS t_nueva
        CROSS APPLY (
            -- Inicio y fin de la función existente (incluye 15 min de limpieza/mantenimiento)
            SELECT 
                DATEADD(second, DATEDIFF(second, '00:00:00', f_existente.hora), CAST(f_existente.fecha AS DATETIME)) AS inicio_existente,
                DATEADD(MINUTE, mins.duracion_min_existente + 15, DATEADD(second, DATEDIFF(second, '00:00:00', f_existente.hora), CAST(f_existente.fecha AS DATETIME))) AS fin_existente
        ) AS t_existente

        -- Condición matemática de superposición de rangos horarios: (InicioA < FinB) Y (FinA > InicioB)
        WHERE t_nueva.inicio_nueva < t_existente.fin_existente
          AND t_nueva.fin_nueva > t_existente.inicio_existente
    )
    BEGIN
        RAISERROR ('YA EXISTE UNA FUNCION PROGRAMADA DENTRO DEL HORARIO ELEGIDO.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END
END;
GO

--- LOTE DE PRUEBA PARA SUPERPOSICION DE FUNCIONES

-- 1. Insertamos una primera función en Sala 1 de 18:00 a 20:43 (148 min + 15 min de margen)
INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala)
VALUES (201, '2026-12-01', '18:00:00', 5000, 1, 1, 1);

-- 2. Intentamos programar otra función en la misma Sala 1 a las 19:30 (Superpuesta)
-- El trigger debe bloquearla y mostrar el mensaje de conflicto en rojo.
INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala)
VALUES (202, '2026-12-01', '19:30:00', 5000, 2, 1, 1);




