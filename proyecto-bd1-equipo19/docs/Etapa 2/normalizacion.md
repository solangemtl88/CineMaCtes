# Etapa II — Proceso de Normalización (1FN, 2FN, 3FN)

La normalización se aplicó sobre el diseño conceptual de **CineMaCtes** para organizar las tablas, eliminar redundancias anómalas y garantizar la integridad estructural de la base de datos `CINEMA`.

---

## 1. Primera Forma Normal (1FN)
### Requisitos:
* Atributos con valores atómicos (indivisibles).
* Ausencia de grupos repetitivos o listas guardadas en una sola columna.
* Existencia de una clave primaria bien definida en cada tabla.

### Aplicación en CineMaCtes:
Los datos se distribuyen en columnas atómicas individuales (ej. `nombre`, `apellido`, `fecha`, `precio`). Las relaciones de varios a varios entre películas y géneros no se guardan como texto separado por comas, sino mediante registros individuales en la tabla intermedia `PELICULA_ETIQUETA`. Del mismo modo, el detalle de entradas adquiridas en una compra se desglosa fila por fila en `COMPRA_FUNCION`.

**Objetivo cumplido:** Eliminación de grupos repetitivos y garantia de valores atómicos.

---

## 2. Segunda Forma Normal (2FN)
### Requisitos:
* Cumplir con la 1FN.
* Todos los atributos no clave deben depender funcionalmente de la **clave primaria completa**, y no de una parte de ella (ausencia de dependencias parciales).

### Aplicación en CineMaCtes:
La revisión de 2FN cobra especial relevancia en las tablas con claves primarias compuestas:
* En `PELICULA_ETIQUETA`, la clave es `(id_pelicula, id_etiqueta)` y no existen atributos no clave adicionales.
* En `COMPRA_FUNCION`, la clave está formada por `(id_compra, id_funcion, id_butaca)`. El atributo no clave `cantidad` representa el número de entradas emitidas para esa combinación específica de compra, función y butaca, dependiendo funcionalmente de la clave compuesta completa.

**Objetivo cumplido:** Ausencia de dependencias parciales sobre claves compuestas.

---

## 3. Tercera Forma Normal (3FN)
### Requisitos:
* Cumplir con la 2FN.
* Ningún atributo no clave debe depender de otro atributo no clave (ausencia de dependencias transitivas).

### Aplicación en CineMaCtes:
Para favorecer la separación de responsabilidades:
* La información descriptiva de la película (`titulo`, `sinopsis`, `duracion`) reside exclusivamente en `PELICULA`.
* Los datos operativos de la proyección (`fecha`, `hora`, `precio`) se almacenan en `FUNCION`, haciendo referencia únicamente al identificador `id_pelicula`.
* La descripción textual de los estados de sala se aísla en `ESTADO_FUNCION`.
* Los datos del usuario (`nombre`, `apellido`, `correo`) residen en `USUARIO` y se vinculan a la compra mediante la FK `dni`.

**Objetivo cumplido:** Minimización de la redundancia y eliminación de dependencias transitivas.
