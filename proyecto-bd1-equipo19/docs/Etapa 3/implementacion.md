# Etapa III — Implementación de la Base de Datos en SQL Server Express

## 1. Objetivo de la Implementación
En esta etapa se trasladó el modelo relacional del sistema **CineMaCtes** a un Sistema Gestor de Bases de Datos Relacionales (SGBD) mediante la ejecución de scripts DDL (*Data Definition Language*) en **SQL Server Express**.

Se creó la base de datos `CINEMA` y se construyeron las 11 tablas con sus correspondientes tipos de datos, restricciones de obligatoriedad, claves primarias y claves foráneas.

---

## 2. Creación de la Base de Datos y Estructura DDL
La base de datos se inicializa mediante la sentencia:
```sql
CREATE DATABASE CINEMA;
GO
USE CINEMA;
GO
```

A continuación, el script crea las 11 tablas que conforman el esquema relacional:
1. `USUARIO`: Almacena clientes registrados (`dni`, `nombre`, `apellido`, `correo`, `contrasena`).
2. `BENEFICIO`: Catálogo de promociones (`id_beneficio`, `descripcion_`, `descuento`).
3. `PELICULA`: Catálogo cinematográfico (`id_pelicula`, `titulo`, `duracion`, `sinopsis`).
4. `ESTADO_FUNCION`: Estados de función (`id_estado_funcion`, `descripcion_`).
5. `SALA`: Salas físicas (`id_sala`, `capacidad`).
6. `ETIQUETA`: Clasificación de géneros (`id_etiqueta`, `descripcion_`).
7. `BUTACA`: Asientos físicos (`id_butaca`, `codigo`, `id_sala`).
8. `FUNCION`: Proyecciones programadas (`id_funcion`, `fecha`, `hora`, `precio`, `id_pelicula`, `id_estado_funcion`, `id_sala`).
9. `COMPRA`: Cabecera de facturas (`id_compra`, `fecha`, `dni`, `id_beneficio`).
10. `COMPRA_FUNCION`: Detalle de líneas de venta (`cantidad`, `id_compra`, `id_funcion`, `id_butaca`).
11. `PELICULA_ETIQUETA`: Clasificación de películas (`id_pelicula`, `id_etiqueta`).
