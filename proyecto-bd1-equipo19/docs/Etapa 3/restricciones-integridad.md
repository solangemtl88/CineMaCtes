# Etapa III — Restricciones de Integridad Física y Lógica

Para garantizar la consistencia de los datos almacenados en **CineMaCtes**, se definieron e implementaron las siguientes restricciones en SQL Server:

---

## 1. Claves Primarias (`PRIMARY KEY`)
Garantizan la unicosidad e identificabilidad de cada registro en el sistema:
* **Claves Simples:**
  * `USUARIO(dni)`
  * `BENEFICIO(id_beneficio)`
  * `COMPRA(id_compra)`
  * `PELICULA(id_pelicula)`
  * `ESTADO_FUNCION(id_estado_funcion)`
  * `SALA(id_sala)`
  * `FUNCION(id_funcion)`
  * `ETIQUETA(id_etiqueta)`
  * `BUTACA(id_butaca)`
* **Claves Compuestas:**
  * `COMPRA_FUNCION(id_compra, id_funcion, id_butaca)`
  * `PELICULA_ETIQUETA(id_pelicula, id_etiqueta)`

---

## 2. Claves Foráneas (`FOREIGN KEY`) e Integridad Referencial
Impiden la existencia de registros huérfanos y mantienen la consistencia en cascada:
* `COMPRA.dni` -> `USUARIO(dni)`
* `COMPRA.id_beneficio` -> `BENEFICIO(id_beneficio)`
* `FUNCION.id_pelicula` -> `PELICULA(id_pelicula)`
* `FUNCION.id_estado_funcion` -> `ESTADO_FUNCION(id_estado_funcion)`
* `FUNCION.id_sala` -> `SALA(id_sala)`
* `BUTACA.id_sala` -> `SALA(id_sala)`
* `COMPRA_FUNCION.id_compra` -> `COMPRA(id_compra)`
* `COMPRA_FUNCION.id_funcion` -> `FUNCION(id_funcion)`
* `COMPRA_FUNCION.id_butaca` -> `BUTACA(id_butaca)`
* `PELICULA_ETIQUETA.id_pelicula` -> `PELICULA(id_pelicula)`
* `PELICULA_ETIQUETA.id_etiqueta` -> `ETIQUETA(id_etiqueta)`

---

## 3. Restricciones de Obligatoriedad (`NOT NULL` / `NULL`)
* Todos los campos de datos esenciales (DNI, nombres, títulos, precios, fechas, capacidades) fueron configurados como `NOT NULL` para obligar su carga.
* La columna `COMPRA.id_beneficio` se configuró como `NULL` para permitir ventas estándar sin promociones aplicadas.
