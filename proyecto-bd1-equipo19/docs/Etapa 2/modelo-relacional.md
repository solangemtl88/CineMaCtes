# Etapa II — Modelo Relacional y Estructura de Tablas

## 1. Objetivo del Modelado
En esta etapa se diseñó la estructura de datos del sistema **CineMaCtes**. El trabajo comprende la representación conceptual mediante un Diagrama Entidad-Relación (DER), su transformación en un modelo relacional y la revisión de la estructura mediante las tres primeras formas normales (1FN, 2FN y 3FN).

---

## 2. Del Dominio al Diagrama Entidad-Relación (DER)
El DER representa las entidades principales del sistema, sus atributos y las relaciones entre ellas:

* **Usuario:** Identifica a cada cliente o usuario mediante su DNI y registra nombre, apellido, correo y contraseña.
* **Beneficio:** Registra los beneficios o promociones mediante un identificador (`id_beneficio`), una descripción y el porcentaje de descuento.
* **Compra:** Registra la cabecera de las transacciones realizadas y su fecha.
* **Película:** Almacena información cinemática como título, sinopsis y duración.
* **Estado_función:** Identifica el estado operativo de una función (ej. *Programada*, *En Curso*, *Entradas Agotadas*, *Cancelada*).
* **Sala:** Representa las salas de proyección y su capacidad total de asientos.
* **Función:** Registra la fecha, hora y precio de la proyección, vinculándose con una película, un estado y una sala.
* **Butaca:** Identifica las butacas individuales mediante un identificador y código, asociadas a una sala determinada.
* **Etiqueta:** Permite clasificar las películas por género o categoría (ej. *Acción*, *Ciencia Ficción*, *Drama*).

---

## 3. Del DER al Modelo Relacional
A partir del DER, las entidades se transformaron en tablas relacionales. Los atributos se representaron como columnas y se definieron claves primarias para identificar unívocamente cada registro. Las relaciones entre las tablas se implementaron mediante claves foráneas y tablas de asociación.

El modelo relacional está conformado por **11 tablas**:
1. `USUARIO`
2. `BENEFICIO`
3. `COMPRA`
4. `PELICULA`
5. `ESTADO_FUNCION`
6. `SALA`
7. `FUNCION`
8. `ETIQUETA`
9. `BUTACA`
10. `COMPRA_FUNCION` (Tabla de asociación)
11. `PELICULA_ETIQUETA` (Tabla de asociación)

---

## 4. Claves Primarias y Foráneas
* **Claves Primarias Simples:** `USUARIO(dni)`, `BENEFICIO(id_beneficio)`, `COMPRA(id_compra)`, `PELICULA(id_pelicula)`, `ESTADO_FUNCION(id_estado_funcion)`, `SALA(id_sala)`, `FUNCION(id_funcion)`, `ETIQUETA(id_etiqueta)`, `BUTACA(id_butaca)`.
* **Claves Foráneas (Relaciones):**
  * `COMPRA.dni` -> `USUARIO.dni`
  * `COMPRA.id_beneficio` -> `BENEFICIO.id_beneficio` (Admite `NULL`)
  * `FUNCION.id_pelicula` -> `PELICULA.id_pelicula`
  * `FUNCION.id_estado_funcion` -> `ESTADO_FUNCION.id_estado_funcion`
  * `FUNCION.id_sala` -> `SALA.id_sala`
  * `BUTACA.id_sala` -> `SALA.id_sala`
  * `COMPRA_FUNCION.id_compra` -> `COMPRA.id_compra`
  * `COMPRA_FUNCION.id_funcion` -> `FUNCION.id_funcion`
  * `COMPRA_FUNCION.id_butaca` -> `BUTACA.id_butaca`
  * `PELICULA_ETIQUETA.id_pelicula` -> `PELICULA.id_pelicula`
  * `PELICULA_ETIQUETA.id_etiqueta` -> `ETIQUETA.id_etiqueta`

---

## 5. Tablas de Asociación (Relaciones N:M)
* **`PELICULA_ETIQUETA`:** Relaciona películas con múltiples etiquetas/géneros. Clave primaria compuesta por `(id_pelicula, id_etiqueta)`.
* **`COMPRA_FUNCION`:** Relaciona las compras con las funciones y las butacas específicas reservadas. Clave primaria compuesta por `(id_compra, id_funcion, id_butaca)`. Almacena además el atributo de detalle `cantidad`.
