# Etapa 4 — Informes de Ventas y Recaudación

## 1. Reporte Agregado de Ventas por Categoría

* **Necesidad de información:** Identificar qué categorías de películas tienen mayor actividad de ventas y recaudación durante un período determinado.
* **Estrategia SQL:** Se relacionan `ETIQUETA`, `PELICULA_ETIQUETA`, `PELICULA`, `FUNCION`, `COMPRA_FUNCION` y `COMPRA` mediante `INNER JOIN`. Se filtran las compras con `WHERE` y un rango de fechas. Luego, `GROUP BY` agrupa los resultados por identificador y descripción de la etiqueta. Se utilizan `COUNT(DISTINCT c.id_compra)` para contar compras diferentes, `SUM(cf.cantidad)` para sumar las entradas vendidas y `SUM(cf.cantidad * f.precio)` para calcular la recaudación asociada. Finalmente, `ORDER BY total_recaudado DESC` ordena las categorías desde la mayor hasta la menor recaudación.
* **Resultado esperado:** Obtener una fila por categoría, con la cantidad de compras distintas asociadas, el total de entradas vendidas y la recaudación calculada para el rango de fechas seleccionado.
* **Consideración:** Una película puede tener más de una etiqueta, por lo que una misma compra puede contribuir a más de una categoría. Por ello, los importes por categoría representan la recaudación asociada a cada etiqueta y no necesariamente partes exclusivas de un total general.

---

## 2. Películas con Recaudación Total Mayor a $4000

* **Necesidad de información:** Identificar las películas cuya recaudación calculada supera el valor de $4000, para reconocer cuáles generaron mayores ingresos según los datos registrados.
* **Estrategia SQL:** Se combinan `PELICULA`, `FUNCION` y `COMPRA_FUNCION` mediante `JOIN`. La recaudación se calcula sumando el precio de cada función multiplicado por la cantidad de entradas (`SUM(f.precio * cf.cantidad)`). `GROUP BY p.titulo` agrupa los resultados por película y `HAVING` filtra los grupos cuya recaudación total es mayor que 4000.
* **Resultado esperado:** Obtener el título de cada película que supere el umbral establecido y su recaudación total calculada. Si ninguna película supera ese importe, la consulta no devolverá filas.
