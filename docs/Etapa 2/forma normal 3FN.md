## 3FN — Tercera Forma Normal

### Regla

El modelo debe estar en **2FN** y, además, ningún atributo no clave puede depender de **otro atributo no clave** (dependencia transitiva).

Todos los atributos no clave deben depender únicamente de la **clave primaria**.

Se revisó cada tabla que contiene claves foráneas, para verificar que no se haya "arrastrado" información descriptiva de la entidad relacionada.

| Tabla | Posible riesgo de transitividad | Resolución aplicada |
|---|---|---|
| `USUARIO` (`id_tipo_usuario` FK) | Que la descripción del tipo de usuario se guarde repetida en Usuario. | La descripción vive únicamente en `TIPO_USUARIO`; Usuario solo referencia el ID. |
| `CONSULTA` (`id_estado_consulta` FK) | Que la descripción del estado se duplique en Consulta. | La descripción vive únicamente en `ESTADO_CONSULTA`. |
| `FUNCIÓN` (`id_pelicula` FK, `id_estado_función` FK) | Que sinopsis/duración de la película o la descripción del estado se guarden en Función. | Esos atributos permanecen exclusivamente en `PELICULA` y `ESTADO_FUNCIÓN`, respectivamente. `FUNCIÓN` solo guarda sus propios datos (`fecha`, `hora`, `precio`) y las referencias. |
| `SALA` (`id_función` FK) | — | `capacidad` depende directamente de `id_sala`, no de ningún otro atributo no clave. |
| `BUTACA` (`id_sala` FK) | — | `codigo_butaca` depende directamente de `id_butaca`. |

En ningún caso un atributo no clave depende de otro atributo no clave.

Cada dato descriptivo (`descripción`, `sinopsis`, `capacidad`, `código`, etc.) quedó alojado en la tabla de la entidad a la que realmente pertenece, y la vinculación entre tablas se resuelve exclusivamente mediante **claves foráneas**.

### Conclusión 3FN

No existen dependencias transitivas entre atributos no clave.

> **El modelo cumple 3FN.**

---
# Resumen de la evolución del modelo

| Etapa | Acción realizada | Objetivo cumplido |
|---|---|---|
| **DER → 1FN** | Transformación de relaciones N:M en tablas intersección con clave compuesta; verificación de atomicidad de atributos. | Eliminar grupos repetitivos y atributos multivaluados. |
| **1FN → 2FN** | Verificación de que los atributos no clave en tablas con clave compuesta dependan de la clave completa. | Eliminar dependencias parciales. |
| **2FN → 3FN** | Separación de atributos descriptivos en la tabla de su entidad de origen, vinculando por FK en vez de duplicar datos. | Eliminar dependencias transitivas. |

---

## Conclusión final

El proceso de normalización permitió transformar progresivamente el **DER** inicial en un **modelo relacional organizado**, aplicando las reglas de las tres primeras formas normales.

- **1FN:** se eliminaron grupos repetitivos y atributos multivaluados.
- **2FN:** se eliminaron las dependencias parciales.
- **3FN:** se eliminaron las dependencias transitivas.

Por lo tanto, el **modelo relacional final**, tal como quedó representado en el diagrama de tablas, se encuentra en **Tercera Forma Normal (3FN)**.