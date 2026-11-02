
# Etapa 3 — Implementación de la base de datos


## 1. Objetivo de la implementación

En esta etapa se llevó el modelo relacional del sistema CineMaCtes a un sistema gestor de bases de datos (SGBD) mediante la creación de la base de datos, la definición de sus tablas y la carga de datos de prueba.

La implementación establece la estructura necesaria para almacenar la información de usuarios, beneficios, compras, películas, funciones, salas, butacas y etiquetas, así como las relaciones existentes entre estas entidades.

## 2. Creación de la base de datos

La base de datos se crea mediante la instrucción `CREATE DATABASE CINEMA`.

Posteriormente, el script define las tablas que conforman el modelo relacional. Para cada tabla se especifican sus columnas, tipos de datos, restricciones de obligatoriedad y claves primarias. También se incorporan claves foráneas para establecer las relaciones entre las tablas.

Las once tablas creadas son:

- `USUARIO`
- `BENEFICIO`
- `COMPRA`
- `PELICULA`
- `ESTADO_FUNCION`
- `SALA`
- `FUNCION`
- `ETIQUETA`
- `BUTACA`
- `COMPRA_FUNCION`
- `PELICULA_ETIQUETA`

## 3. Implementación de tablas y restricciones

### 3.1. Claves primarias

Se definieron claves primarias para identificar de forma única los registros de cada tabla.

La mayoría de las tablas utiliza una clave primaria simple, como `dni` en `USUARIO` o `id_pelicula` en `PELICULA`.

En cambio, las tablas de asociación utilizan claves primarias compuestas:

- `COMPRA_FUNCION`: `id_compra`, `id_funcion` e `id_butaca`.
- `PELICULA_ETIQUETA`: `id_pelicula` e `id_etiqueta`.

Estas claves permiten identificar las combinaciones registradas en cada tabla.

### 3.2. Claves foráneas e integridad referencial

Se incorporaron claves foráneas para mantener las referencias entre registros relacionados:

- `COMPRA` referencia a `USUARIO` mediante `dni` y a `BENEFICIO` mediante `id_beneficio`.
- `FUNCION` referencia a `PELICULA`, `ESTADO_FUNCION` y `SALA`.
- `BUTACA` referencia a `SALA`.
- `COMPRA_FUNCION` referencia a `COMPRA`, `FUNCION` y `BUTACA`.
- `PELICULA_ETIQUETA` referencia a `PELICULA` y `ETIQUETA`.

Estas restricciones permiten mantener las relaciones entre las tablas y preservar la integridad referencial de los datos.

### 3.3. Restricciones de obligatoriedad

Se utilizó `NOT NULL` en los atributos que deben tener un valor para que el registro pueda insertarse.

Como excepción, `COMPRA.id_beneficio` admite valores nulos. Esto permite registrar una compra sin asociarle obligatoriamente un beneficio.

## 4. Carga de datos de prueba

Para utilizar la estructura creada, se prepararon scripts de inserción de datos en las tablas principales y en las tablas relacionadas.

### 4.1. Datos de las tablas principales

El script de inserción de datos principales incorpora registros en las siguientes tablas:

- **`USUARIO`:** 10 usuarios, identificados mediante DNI, con nombre, apellido, correo y contraseña.
- **`BENEFICIO`:** 10 beneficios con descripciones y porcentajes de descuento.
- **`PELICULA`:** 10 películas con título, duración y sinopsis.
- **`ESTADO_FUNCION`:** 10 estados posibles para las funciones.
- **`SALA`:** 10 salas con distintas capacidades.
- **`ETIQUETA`:** 10 etiquetas para clasificar películas.

Los datos permiten representar distintos elementos del sistema y sirven como base para las inserciones que dependen de ellos.

### 4.2. Datos de las tablas relacionadas

El script de inserción de datos intermedios incorpora registros en las siguientes tablas:

- **`BUTACA`:** 10 registros de butacas asociados a distintas salas.
- **`PELICULA_ETIQUETA`:** 10 asociaciones entre películas y etiquetas.
- **`FUNCION`:** 10 funciones con fecha, hora, precio y referencias a película, estado y sala.
- **`COMPRA`:** 11 compras asociadas a usuarios y beneficios.
- **`COMPRA_FUNCION`:** 11 registros que vinculan compras, funciones y butacas, e incluyen la cantidad correspondiente.

La carga de datos contempla tanto los registros principales como las relaciones necesarias para representar las operaciones del sistema.

## 5. Integridad de los datos

La estructura implementada incluye restricciones que ayudan a mantener la consistencia de la información:

- Las claves primarias identifican de manera única los registros.
- Las claves foráneas mantienen las relaciones entre las tablas.
- Las restricciones `NOT NULL` exigen valores para los atributos obligatorios.
- Las claves compuestas permiten identificar las asociaciones registradas en las tablas intermedias.

Estas restricciones forman parte de la estructura definida para la base de datos CINEMA y permiten organizar la información de acuerdo con el modelo relacional.

## 6. Conclusión

La etapa de implementación permitió trasladar el modelo relacional de CineMaCtes a una estructura de base de datos compuesta por once tablas. Se definieron claves primarias, claves foráneas y restricciones de obligatoriedad para organizar la información y mantener las relaciones entre los registros.

Además, se prepararon scripts de carga con datos de prueba para usuarios, beneficios, películas, estados, salas, etiquetas, butacas, funciones y compras.

De esta manera, se estableció la estructura de la base de datos CINEMA y se incorporaron los datos necesarios para continuar con el desarrollo de las consultas SQL y los casos de uso de las siguientes etapas.
