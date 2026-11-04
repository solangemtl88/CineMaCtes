# Etapa 5: Seguridad (Manejo de Permisos y Roles)

## 1. Definición y Objetivo

La **seguridad en bases de datos relacionales** abarca el conjunto de mecanismos y políticas implementadas dentro del motor SQL Server Express para controlar qué usuarios o aplicaciones pueden autenticarse y qué operaciones específicas (`SELECT`, `INSERT`, `UPDATE`, `DELETE`, `EXECUTE`) están autorizados a realizar sobre los objetos del esquema [65, 72].

* **Logins e Inicios de Sesión:** Mecanismos de autenticación a nivel de servidor que validan las credenciales de acceso [74, 89].
* **Usuarios de Base de Datos:** Entidades dentro del catálogo `CINEMA` vinculadas a un login del servidor para otorgar permisos dentro del contexto de la base de datos [74, 90].
* **Roles de Aplicación y Base de Datos:** Contenedores de permisos reutilizables que agrupan privilegios operativos según la función o el perfil del usuario [72, 78, 91].

**Objetivo Principal:** Aplicar el **Principio de Mínimo Privilegio**, garantizando que cada perfil de usuario acceda únicamente a los datos e instrucciones estrictamente necesarios para cumplir su función, protegiendo la base de datos contra modificaciones no autorizadas, accesos indebidos o manipulación directa de tablas críticas [72, 73].

---

## 2. Ventajas y Aplicaciones (Por qué fue elegido)

La implementación de seguridad basada en roles y permisos encubiertos en el sistema **CineMaCtes** responde a los siguientes motivos de arquitectura y control [73, 77]:

1. **Protección de Tablas Sensibles:** Evita que usuarios operativos (como los cajeros de taquilla) realicen modificaciones o inserciones directas sobre tablas críticas como `COMPRA`, `COMPRA_FUNCION` o `FUNCION` [73, 76].
2. **Encapsulamiento de Lógica de Negocio mediante Stored Procedures:** Se revoca el permiso de inserción directa sobre tablas, pero se concede el permiso `GRANT EXECUTE` sobre el procedimiento almacenado `sp_RegistrarCompraBoleto` [75, 92]. De este modo, la venta se realiza obligatoriamente pasando por las validaciones de negocio (horario, butaca vacía, atomicidad transaccional) [50, 76, 92].
3. **Administración Escalable basada en Roles:** En lugar de asignar permisos individualmente a cada empleado, se crea el rol personalizado `cajero` [78, 91]. Cuando ingresa un nuevo operador de venta, basta con añadirlo como miembro del rol (`ALTER ROLE cajero ADD MEMBER`) [78, 92].
4. **Defensa en Profundidad:** Incluso si una aplicación cliente es vulnerada, el motor SQL Server deniega cualquier intento de manipulación SQL maliciosa que no esté expresamente concedida al usuario autenticado [73, 76].

---

## 3. Implementación en SQL Server Express

En **SQL Server Express**, la seguridad se gestiona mediante sentencias DCL (*Data Control Language*) organizadas en tres niveles [74, 75, 78, 89-92]:

1. **Autenticación (Servidor y BD):**
   * `CREATE LOGIN [nombre] WITH PASSWORD = '...'` (a nivel servidor) [74, 89].
   * `CREATE USER [nombre] FOR LOGIN [nombre]` (a nivel de la base de datos `CINEMA`) [74, 90].

2. **Creación de Roles y Membresías:**
   * `CREATE ROLE [nombre_rol]` [78, 91].
   * `ALTER ROLE [nombre_rol] ADD MEMBER [usuario]` [75, 78, 91, 92].
   * Asignación del administrador al rol propietario del sistema: `ALTER ROLE db_owner ADD MEMBER AdminCtes` [75, 91].

3. **Concesión Granular de Permisos:**
   * `GRANT SELECT ON dbo.[tabla] TO [rol/usuario]` [75, 78, 91, 92].
   * `GRANT EXECUTE ON dbo.[procedimiento] TO [rol/usuario]` [75, 92].

---

## 4. Caso Concreto Aplicado al Sistema CineMaCtes

Para responder a las necesidades de seguridad y operativas del cine [6, 9], se definieron dos perfiles de usuario diferenciados [89-92]:

### 4.1. Perfil Administrador (`AdminCtes`)
* **Login y Usuario:** `AdminCtes` [89, 90].
* **Asignación:** Miembro del rol predefinido `db_owner` [91].
* **Alcance:** Control total sobre el esquema `CINEMA`, administración de cartelera, precios, salas, usuarios y permisos globales [9, 75, 91].

### 4.2. Perfil Cajero / Taquilla (`Cajero26` y Rol `cajero`)
* **Login y Usuario:** `Cajero26` [89, 90].
* **Rol Personalizado:** `cajero` [91].
* **Permisos Otorgados:**
  * `GRANT SELECT` sobre las tablas de consulta de cartelera y disponibilidad: `FUNCION`, `PELICULA`, `SALA`, `BUTACA`, `COMPRA` y `COMPRA_FUNCION` [91, 92].
  * `GRANT EXECUTE` sobre `dbo.sp_RegistrarCompraBoleto` [92].
* **Restricción Clave:** Se deniega implícitamente cualquier operación `INSERT`, `UPDATE` o `DELETE` directa sobre las tablas [45, 93]. La única vía autorizada para registrar una venta es invocando el Stored Procedure oficial [46, 93, 94].

---

## 5. Scripts de Demostración y Resultados Obtenidos

### 5.1. Código SQL de Configuración de Seguridad

```sql
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

-- 3. Asignar Administrador como db_owner
ALTER ROLE db_owner ADD MEMBER AdminCtes;
GO

-- 4. Crear Rol personalizado para Cajeros
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'cajero' AND type = 'R')
BEGIN
    CREATE ROLE cajero;
END;
GO

-- 5. Otorgar permisos de LECTURA (SELECT) sobre el catálogo y ventas
GRANT SELECT ON dbo.FUNCION TO cajero;
GRANT SELECT ON dbo.PELICULA TO cajero;
GRANT SELECT ON dbo.SALA TO cajero;
GRANT SELECT ON dbo.BUTACA TO cajero;
GRANT SELECT ON dbo.COMPRA TO cajero;
GRANT SELECT ON dbo.COMPRA_FUNCION TO cajero;
GO

-- 6. Otorgar permiso de EJECUCIÓN sobre el Stored Procedure de Venta
GRANT EXECUTE ON dbo.sp_RegistrarCompraBoleto TO cajero;
GO

-- 7. Asignar el usuario Cajero26 al rol cajero
ALTER ROLE cajero ADD MEMBER Cajero26;
GO
```

---

### 5.2. Lote de Pruebas y Evidencias de Ejecución (Sesión `Cajero26`)

Para evaluar la efectividad del esquema de seguridad, se simula la sesión como el usuario `Cajero26` mediante la instrucción `EXECUTE AS USER = 'Cajero26'` [93].

```sql
EXECUTE AS USER = 'Cajero26';
GO
```

#### Prueba 1: Lectura Permitida (`SELECT`)
Se comprueba que el rol `cajero` posee permisos de lectura para consultar la cartelera y la disponibilidad de funciones [45, 93]:

```sql
SELECT * FROM dbo.FUNCION;
GO
```
**Resultado Obtenido (Evidencia):** La consulta se ejecuta de forma exitosa, retornando el listado completo de funciones programadas (IDs 1 al 10, 98, 99 y 201) con sus respectivas fechas, horas, precios, películas y salas [45].

#### Prueba 2: Bloqueo de Seguridad (`INSERT` Directo Denegado)
Se intenta realizar una inserción directa en la tabla `COMPRA` sin utilizar el procedimiento almacenado [45, 93]:

```sql
INSERT INTO dbo.COMPRA (id_compra, fecha, dni, id_beneficio) 
VALUES (999, GETDATE(), 30111222, NULL);
GO
```
**Resultado Obtenido (Evidencia):** SQL Server bloquea inmediatamente la operación y retorna un error en rojo [45, 46, 93]:
> `Mens. 229, Nivel 14, Estado 5, Línea 74`  
> `Se denegó el permiso INSERT en el objeto 'COMPRA', base de datos 'CINEMA', esquema 'dbo'.`

Esto confirma el cumplimiento estricto del principio de mínimo privilegio y evita que los operadores alteren los datos sin pasar por los controles del sistema [45, 73].

#### Prueba 3: Venta Autorizada mediante Stored Procedure
Se ejecuta el proceso de venta invocando el procedimiento almacenado autorizado `dbo.sp_RegistrarCompraBoleto` [46, 93, 94]:

```sql
EXEC dbo.sp_RegistrarCompraBoleto 
    @dni = 30111222, 
    @id_funcion = 1, 
    @id_butaca = 1, 
    @id_beneficio = NULL;
GO
```
**Resultado Obtenido (Evidencia):** La operación se completa exitosamente imprimiendo en pantalla [46, 94]:
> `¡Boleto registrado y butaca asignada con éxito!`

Esto demuestra que el cajero puede registrar compras respetando todas las validaciones de negocio encapsuladas en el procedimiento, sin necesidad de poseer acceso directo de escritura sobre las tablas de la base de datos [46, 76].

```sql
-- Restablecer la sesión al perfil de Administrador
REVERT;
GO
```

---

## 6. Conclusión

La implementación de roles (`cajero`), inicios de sesión (`Cajero26`, `AdminCtes`) y permisos específicos (`GRANT SELECT`, `GRANT EXECUTE`) en **SQL Server Express** consolida un esquema de seguridad robusto para **CineMaCtes** [73, 91, 92]. Se impide la manipulación no autorizada de las tablas principales y se canalizan todas las operaciones críticas a través de Stored Procedures, blindando la integridad referencial y las reglas de negocio del sistema [45, 46, 73, 76].
