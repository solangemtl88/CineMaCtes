
# Etapa 2 — Modelado de la base de datos


## 1. Objetivo del modelado

En esta etapa se diseñó la estructura de datos del sistema de cine. El trabajo comprende la representación conceptual mediante un Diagrama Entidad-Relación (DER), su transformación en un modelo relacional y la revisión de la estructura mediante las tres primeras formas normales (1FN, 2FN y 3FN).

La documentación se basa en los diagramas y en el script SQL de creación de tablas disponibles en el repositorio del proyecto.

## 2. Del dominio al Diagrama Entidad-Relación (DER)

El DER representa las entidades principales del sistema, sus atributos y las relaciones entre ellas. Entre las entidades representadas se encuentran:

- **Usuario:** identifica a cada usuario mediante su DNI y registra nombre, apellido, correo y contraseña.
- **Beneficio:** registra beneficios mediante un identificador, una descripción y un descuento.
- **Compra:** registra las compras realizadas y su fecha.
- **Película:** almacena información como título, sinopsis y duración.
- **Estado_función:** permite identificar el estado de una función.
- **Sala:** representa las salas y su capacidad.
- **Función:** registra fecha, hora y precio, y se vincula con una película, un estado y una sala.
- **Butaca:** identifica las butacas mediante un identificador y un código, y las vincula con una sala.
- **Etiqueta:** permite clasificar las películas.

El diagrama también representa relaciones entre estas entidades. Por ejemplo, un usuario efectúa compras, una sala contiene butacas, una función corresponde a una película y las películas se relacionan con etiquetas.

Además, se contemplan relaciones que incluyen atributos propios, como la cantidad asociada a las compras de funciones y butacas.

## 3. Del DER al modelo relacional

A partir del DER, las entidades se transformaron en tablas. Los atributos se representaron como columnas y se definieron claves primarias para identificar los registros. Las relaciones entre las tablas se implementaron mediante claves foráneas y tablas de asociación cuando fue necesario.

El script SQL de creación de la base de datos contiene las siguientes once tablas:

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

### 3.1. Claves primarias y foráneas

Las claves primarias permiten identificar de manera única cada registro. Las claves foráneas establecen referencias entre tablas y permiten representar las relaciones del modelo.

Las principales relaciones implementadas son:

- `COMPRA.dni` referencia a `USUARIO.dni`.
- `COMPRA.id_beneficio` referencia a `BENEFICIO.id_beneficio`.
- `FUNCION.id_pelicula` referencia a `PELICULA.id_pelicula`.
- `FUNCION.id_estado_funcion` referencia a `ESTADO_FUNCION.id_estado_funcion`.
- `FUNCION.id_sala` referencia a `SALA.id_sala`.
- `BUTACA.id_sala` referencia a `SALA.id_sala`.
- `COMPRA_FUNCION.id_compra` referencia a `COMPRA.id_compra`.
- `COMPRA_FUNCION.id_funcion` referencia a `FUNCION.id_funcion`.
- `COMPRA_FUNCION.id_butaca` referencia a `BUTACA.id_butaca`.
- `PELICULA_ETIQUETA.id_pelicula` referencia a `PELICULA.id_pelicula`.
- `PELICULA_ETIQUETA.id_etiqueta` referencia a `ETIQUETA.id_etiqueta`.

La columna `COMPRA.id_beneficio` admite valores nulos, mientras que las demás claves foráneas indicadas están definidas como obligatorias en el script.

### 3.2. Tablas de asociación

El modelo utiliza dos tablas de asociación:

- **`PELICULA_ETIQUETA`:** relaciona películas con etiquetas. Su clave primaria está compuesta por `id_pelicula` e `id_etiqueta`.
- **`COMPRA_FUNCION`:** relaciona compras con funciones y butacas. Su clave primaria está compuesta por `id_compra`, `id_funcion` e `id_butaca`. También contiene el atributo `cantidad`.

Estas tablas permiten registrar las asociaciones mediante filas y utilizar claves foráneas para mantener la integridad referencial.

## 4. Proceso de normalización

La normalización se utiliza para organizar las tablas, reducir la redundancia y revisar las dependencias entre los atributos. El proceso contempla la Primera Forma Normal (1FN), la Segunda Forma Normal (2FN) y la Tercera Forma Normal (3FN).

### 4.1. Primera Forma Normal (1FN)

La Primera Forma Normal requiere que los atributos contengan valores atómicos, que no existan grupos repetitivos y que cada tabla tenga una clave primaria definida.

En el modelo, los datos se distribuyen en columnas individuales. Las relaciones entre películas y etiquetas se representan mediante `PELICULA_ETIQUETA`, mientras que las relaciones entre compras, funciones y butacas se registran en `COMPRA_FUNCION`.

De esta manera, las asociaciones se almacenan mediante registros individuales, en lugar de guardar listas de valores dentro de una misma columna.

**Objetivo:** evitar grupos repetitivos y mantener los atributos con valores atómicos.

### 4.2. Segunda Forma Normal (2FN)

La Segunda Forma Normal requiere que una tabla cumpla 1FN y que cada atributo no clave dependa de la clave primaria completa, sin depender solamente de una parte de una clave compuesta.

Esta revisión es especialmente importante en las tablas que utilizan claves primarias compuestas.

En `PELICULA_ETIQUETA`, la clave primaria está compuesta por `id_pelicula` e `id_etiqueta`, y no hay otros atributos. En `COMPRA_FUNCION`, la clave primaria está formada por `id_compra`, `id_funcion` e `id_butaca`, y la tabla contiene el atributo `cantidad`.

Para justificar formalmente el cumplimiento de 2FN en `COMPRA_FUNCION`, debe verificarse que `cantidad` dependa de la combinación completa de compra, función y butaca, y no de una parte de esa clave. Esta conclusión depende de las reglas de negocio definidas para el sistema.

**Objetivo:** evitar dependencias parciales de los atributos no clave respecto de claves primarias compuestas.

### 4.3. Tercera Forma Normal (3FN)

La Tercera Forma Normal requiere que una tabla cumpla 2FN y que no existan dependencias transitivas indebidas entre atributos no clave.

Para favorecer la separación de responsabilidades, la información descriptiva de cada entidad se almacena en su tabla correspondiente. Las demás tablas utilizan claves foráneas para referenciarla.

Por ejemplo:

- La información de las películas, como título, sinopsis y duración, se almacena en `PELICULA`.
- Los datos propios de las funciones, como fecha, hora y precio, se almacenan en `FUNCION`, junto con las referencias a película, estado y sala.
- La descripción de los estados se almacena en `ESTADO_FUNCION`.
- La descripción de las etiquetas se almacena en `ETIQUETA`.

Para confirmar formalmente el cumplimiento de 3FN, es necesario comprobar las dependencias funcionales de cada tabla y verificar que ningún atributo no clave dependa de otro atributo no clave.

**Objetivo:** reducir la redundancia y evitar dependencias transitivas entre atributos no clave.

## 5. Decisiones de diseño

A partir de los diagramas y del script SQL, se identifican las siguientes decisiones de diseño:

- Utilizar el DNI como clave primaria de `USUARIO`.
- Asignar identificadores propios a entidades como `COMPRA`, `PELICULA`, `SALA` y `FUNCION`.
- Relacionar las compras con usuarios mediante claves foráneas.
- Permitir que una compra tenga un beneficio asociado sin obligar a que todas las compras tengan uno.
- Vincular cada función con una película, un estado y una sala.
- Representar la relación entre películas y etiquetas mediante `PELICULA_ETIQUETA`.
- Representar la relación entre compras, funciones y butacas mediante `COMPRA_FUNCION`.
- Definir restricciones `NOT NULL` para los atributos obligatorios.
- Utilizar claves primarias compuestas en las tablas de asociación.

Estas decisiones permiten expresar las relaciones entre los datos de manera explícita y establecer restricciones de integridad referencial.

## 6. Conclusión

La etapa de modelado permitió pasar de una representación conceptual mediante el DER a una estructura relacional para la base de datos CINEMA. El script de creación implementa once tablas, con claves primarias, claves foráneas y tablas de asociación para representar las relaciones entre los datos.

La normalización proporciona los criterios para revisar la atomicidad de los atributos, las dependencias respecto de las claves y la separación de la información descriptiva.

Para afirmar de manera concluyente que todas las tablas cumplen 1FN, 2FN y 3FN, es necesario contrastar el diseño con las dependencias funcionales y las reglas de negocio completas del sistema.
