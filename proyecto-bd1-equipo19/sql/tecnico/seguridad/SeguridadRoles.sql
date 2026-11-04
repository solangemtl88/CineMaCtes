-- ===================================================================
-- PARTE 1: CREACIÓN DE LOGINS Y USUARIOS
-- ===================================================================
USE CINEMA;
GO

-- 1. Inicios de Sesión (Logins a nivel Servidor)
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'AdminCtes')
    CREATE LOGIN AdminCtes WITH PASSWORD = 'AdminCine26*';

IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'Cajero26')
    CREATE LOGIN Cajero26 WITH PASSWORD = 'CajeroCine2026*';
GO

-- 2. Usuarios dentro de la Base de Datos CINEMA
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'AdminCtes')
    CREATE USER AdminCtes FOR LOGIN AdminCtes;

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'Cajero26')
    CREATE USER Cajero26 FOR LOGIN Cajero26;
GO

-- ===================================================================
-- PARTE 2: ROLES Y ASIGNACIÓN DE PERMISOS REALES
-- ===================================================================

-- 1. Asignar el Administrador como propietario de la BD
ALTER ROLE db_owner ADD MEMBER AdminCtes;
GO

-- 2. Crear Rol personalizado para Cajeros (con verificación de existencia)
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'cajero' AND type = 'R')
BEGIN
    CREATE ROLE cajero;
END;
GO

-- 3. Permisos de LECTURA (SELECT) sobre las tablas del sistema
GRANT SELECT ON dbo.FUNCION TO cajero;
GRANT SELECT ON dbo.PELICULA TO cajero;
GRANT SELECT ON dbo.SALA TO cajero;
GRANT SELECT ON dbo.BUTACA TO cajero;
GRANT SELECT ON dbo.COMPRA TO cajero;
GRANT SELECT ON dbo.COMPRA_FUNCION TO cajero;
GO

-- 4. Permiso de EJECUCIÓN sobre el Procedimiento Almacenado de Venta Real
GRANT EXECUTE ON dbo.sp_RegistrarCompraBoleto TO cajero;
GO

-- 5. Asignar el usuario Cajero26 al rol cajero
ALTER ROLE cajero ADD MEMBER Cajero26;
GO



-- ===================================================================
-- SECCIÓN LOTE DE PRUEBAS DE SEGURIDAD (EVIDENCIAS DE CAPTURA)
-- ===================================================================

-- Simular la sesión como Cajero26
EXECUTE AS USER = 'Cajero26';
GO

-- PRUEBA 1: LECTURA PERMITIDA (SELECT)
SELECT * FROM dbo.FUNCION;
GO

-- PRUEBA 2: BLOQUEO DE SEGURIDAD (INSERT DIRECTO DENEGADO)
-- Nota: En SSMS esta línea devolverá el error esperado en rojo (Mens. 229)
INSERT INTO dbo.COMPRA (id_compra, fecha, dni, id_beneficio) 
VALUES (999, GETDATE(), 30111222, NULL);
GO

-- PRUEBA 3: VENTA AUTORIZADA POR PROCEDIMIENTO ALMACENADO
EXEC dbo.sp_RegistrarCompraBoleto 
    @dni = 30111222, --se consulta a un usuario cargado en la base de datos
    @id_funcion = 1, 
    @id_butaca = 1, 
    @id_beneficio = NULL;
GO


-- Restablecer la sesión al perfil de Administrador
REVERT;
GO
