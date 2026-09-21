# Proceso de Normalización

Este documento describe, paso a paso, la evolución del modelo desde el **Diagrama Entidad-Relación (DER)** hasta el **Modelo Relacional final**, justificando el cumplimiento de la **Primera (1FN), Segunda (2FN) y Tercera (3FN) Forma Normal**.

---

## 1FN — Primera Forma Normal

### Regla

Todo atributo debe ser **atómico (indivisible)**, no deben existir grupos repetitivos ni atributos multivaluados, y cada tabla debe tener una **clave primaria definida**.

En el DER original existían varias relaciones **N:M**, que de modelarse de forma directa dentro de una sola entidad generarían grupos repetitivos. Por ejemplo:

- Un usuario con una lista de beneficios.
- Una venta con una lista de productos.

Para garantizar la atomicidad, estas relaciones N:M se transformaron en **tablas intersección con clave primaria compuesta**.

### Relaciones N:M transformadas

| Relación N:M en el DER | Tabla intersección creada | Clave primaria |
|---|---|---|
| Usuario **tiene** Beneficio (`fecha_uso`) | `USUARIO_BENEFICIO` | (`id_beneficio`, `dni`) |
| Compra **tiene** Producto (`cantidad`) | `DETALLE_COMPRA` | (`id_compra`, `id_producto`) |
| Compra **corresponde** Función (`cantidad`) | `COMPRA_FUNCION` | (`id_compra`, `id_función`) |
| Película **tiene** Etiqueta | `PELÍCULA_ETIQUETA` | (`id_pelicula`, `id_etiqueta`) |

También las relaciones **1:N**:

- Usuario-Consulta
- Usuario-Venta
- Sala-Butaca
- Película-Función
- Consulta/Función con su Estado
- Tipo_usuario-Usuario

se resolvieron incorporando la **clave foránea correspondiente en el lado N**, evitando así cualquier necesidad de repetir grupos de datos.

### Conclusión 1FN

Todos los atributos del modelo (`dni`, `nombre`, `precio`, `fecha`, `hora`, etc.) son **atómicos y monovaluados**.

No hay columnas que almacenen listas de valores, y cada una de las **17 tablas resultantes** posee una clave primaria simple o compuesta claramente definida.

> **El modelo cumple 1FN.**

---

# 2FN — Segunda Forma Normal

### Regla

El modelo debe estar en **1FN** y, además, todo atributo no clave debe depender de la **clave primaria completa**, no solamente de una parte de ella.

Esta regla es especialmente relevante para las tablas que poseen **clave primaria compuesta**.

## Tablas con clave simple

Las siguientes tablas tienen una clave primaria de un solo atributo, por lo que no puede existir dependencia parcial:

- `TIPO_USUARIO`
- `USUARIO`
- `BENEFICIO`
- `CONSULTA`
- `ESTADO_CONSULTA`
- `VENTA`
- `PRODUCTO`
- `FUNCIÓN`
- `ESTADO_FUNCIÓN`
- `SALA`
- `BUTACA`
- `PELICULA`
- `ETIQUETA`

Por lo tanto, **cumplen 2FN de forma trivial**.

## Tablas con clave compuesta

En estas tablas se verifica que los atributos no clave dependan de la **combinación completa de la clave primaria**.

| Tabla | Clave compuesta | Atributo no clave | Justificación |
|---|---|---|---|
| `USUARIO_BENEFICIO` | (`id_beneficio`, `dni`) | `fecha_uso` | La fecha en que se usó el beneficio depende de **qué usuario** usó **qué beneficio**; no puede determinarse solo con `id_beneficio` ni solo con `dni`. |
| `DETALLE_COMPRA` | (`id_compra`, `id_producto`) | `cantidad` | La cantidad vendida depende de la combinación específica venta + producto, no de la venta sola ni del producto solo. |
| `COMPRA_FUNCION` | (`id_compra`, `id_función`) | `cantidad` | La cantidad de entradas depende de qué función se vendió dentro de qué venta puntual. |
| `USUARIO_COMPRA` | (`id_compra`, `dni`) | — | No posee atributos no clave adicionales. La fecha pertenece a `COMPRA`, por lo que no hay dependencia parcial posible. |
| `PELÍCULA_ETIQUETA` | (`id_pelicula`, `id_etiqueta`) | — | No posee atributos no clave adicionales, por lo que cumple 2FN de forma trivial. |

### Conclusión 2FN

En todas las tablas con **clave primaria compuesta**, los atributos no clave dependen de la **clave completa** y no de una parte de ella.

No se detectan **dependencias parciales**.

> **El modelo cumple 2FN.**