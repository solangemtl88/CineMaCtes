# Etapa 4 — Consultas Avanzadas y Agregaciones

## 1. Usuarios que Compraron Entradas para Funciones

* **Necesidad de información:** Conocer qué usuarios realizaron compras asociadas a funciones, sin mostrar usuarios que no tengan compras de ese tipo.
* **Estrategia SQL:** Se consultan los datos de `USUARIO` y se aplica un filtro `WHERE ... IN` con una subconsulta. La subconsulta relaciona `COMPRA` con `COMPRA_FUNCION` y obtiene los DNI asociados a compras que incluyen funciones.
* **Resultado esperado:** Obtener el DNI, nombre, apellido y correo de los usuarios que tengan al menos una compra asociada a una función. Cada usuario se presenta una sola vez en el resultado exterior, aunque haya realizado varias compras.

---

## 2. Funciones con Compras de Dos o Más Entradas

* **Necesidad de información:** Identificar funciones para las que existen compras con una cantidad de entradas igual o superior a dos, junto con la película y el horario correspondiente.
* **Estrategia SQL:** Se combinan `FUNCION`, `PELICULA` y `COMPRA_FUNCION` mediante `JOIN`. `GROUP BY` organiza los resultados por identificador de función, película, fecha, hora y cantidad de entradas. `HAVING cf.cantidad >= 2` conserva los grupos cuya cantidad registrada cumple esa condición.
* **Resultado esperado:** Mostrar el identificador de la función, el título de la película, la fecha, la hora y la cantidad de entradas de los registros que cumplen el mínimo de dos entradas.
* **Consideración:** La consulta filtra cantidades registradas en `COMPRA_FUNCION`; no suma necesariamente todas las entradas de distintas compras para una misma función. Si se necesita conocer el total acumulado de entradas vendidas por función, habría que utilizar `SUM(cf.cantidad)` y agrupar por los datos de la función.

---

## Conclusión

Las consultas de la **Etapa IV** permiten inspeccionar los datos cargados, comprobar la cantidad de registros, consultar el detalle de una compra y obtener reportes de ventas y recaudación. Se utilizan estrategias SQL como `SELECT`, `JOIN`, subconsultas, `WHERE`, `GROUP BY`, `HAVING`, `COUNT`, `SUM` y funciones de ventana para responder distintas necesidades de información del sistema **CineMaCtes**.
