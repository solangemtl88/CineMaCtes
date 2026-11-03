# Etapa 4 — Casos de Uso y Verificación de Datos

## Introducción

En esta etapa se desarrollan consultas SQL para obtener información útil sobre las operaciones del sistema de cine **CineMaCtes** (base de datos `CINEMA`). Para cada consulta se describe la necesidad de información que resuelve, la estrategia SQL utilizada y el resultado esperado.

---

## 1. Verificación del Contenido de las Tablas

* **Necesidad de información:** Conocer los datos almacenados en cada tabla de la base de datos y comprobar visualmente que la carga de datos se haya realizado correctamente.
* **Estrategia SQL:** Se utiliza `SELECT *` sobre las tablas `USUARIO`, `BENEFICIO`, `SALA`, `ESTADO_FUNCION`, `PELICULA`, `ETIQUETA`, `COMPRA`, `FUNCION`, `BUTACA`, `PELICULA_ETIQUETA`, `COMPRA_FUNCION` y `USUARIO_BENEFICIO`. El asterisco indica que se solicitan todas las columnas de cada tabla.
* **Resultado esperado:** Obtener los registros existentes en cada tabla para inspeccionar los datos cargados y detectar posibles faltantes o valores inesperados.

---

## 2. Conteo de Registros por Tabla

* **Necesidad de información:** Conocer cuántos registros contiene cada tabla y verificar de manera general la cantidad de datos cargados.
* **Estrategia SQL:** Se aplica la función de agregación `COUNT(*)` por separado a cada tabla. Se utiliza `AS` para asignar un alias descriptivo al resultado de cada conteo.
* **Resultado esperado:** Obtener una cantidad total de registros para cada una de las tablas consultadas. Estos valores permiten comprobar la carga de datos, aunque por sí solos no garantizan que todos los registros sean correctos.
