# Etapa IV: Consultas y casos de uso

## Introducción

En esta etapa se desarrollan consultas SQL para obtener información útil sobre las operaciones del sistema de cine CINEMA. Para cada consulta se describe la necesidad de información que resuelve, la estrategia SQL utilizada y el resultado esperado.

## 1. Verificación del contenido de las tablas

**Necesidad de información:** conocer los datos almacenados en cada tabla de la base de datos y comprobar visualmente que la carga de datos se haya realizado.

**Estrategia SQL:** se utiliza `SELECT *` sobre las tablas `USUARIO`, `BENEFICIO`, `SALA`, `ESTADO_FUNCION`, `PELICULA`, `ETIQUETA`, `COMPRA`, `FUNCION`, `BUTACA`, `PELICULA_ETIQUETA`, `COMPRA_FUNCION` y `USUARIO_BENEFICIO`. El asterisco indica que se solicitan todas las columnas de cada tabla.

**Resultado esperado:** obtener los registros existentes en cada tabla para inspeccionar los datos cargados y detectar posibles faltantes o valores inesperados.

## 2. Conteo de registros por tabla

**Necesidad de información:** conocer cuántos registros contiene cada tabla y verificar de manera general la cantidad de datos cargados.

**Estrategia SQL:** se aplica la función de agregación `COUNT(*)` por separado a cada tabla. Se utiliza `AS` para asignar un alias descriptivo al resultado de cada conteo.

**Resultado esperado:** obtener una cantidad total de registros para cada una de las tablas consultadas. Estos valores permiten comprobar la carga de datos, aunque por sí solos no garantizan que todos los registros sean correctos.

## 3. Factura o comprobante de una compra

**Necesidad de información:** consultar en un mismo resultado los datos generales de una compra, la información del usuario que la realizó y el detalle de las funciones para las que se adquirieron entradas. También se necesita conocer el subtotal de cada renglón y el total acumulado de la compra.

**Estrategia SQL:** se combinan las tablas `COMPRA`, `USUARIO`, `COMPRA_FUNCION`, `FUNCION` y `PELICULA` mediante `JOIN`, relacionándolas a través de sus identificadores. El subtotal de cada renglón se calcula multiplicando el precio de la función por la cantidad de entradas (`f.precio * cf.cantidad`). Para obtener el total de la compra se utiliza la función de ventana `SUM(...) OVER (PARTITION BY c.id_compra)`, que suma los subtotales correspondientes a cada compra sin agrupar y ocultar el detalle de sus renglones.

**Resultado esperado:** obtener una fila por cada detalle de función asociado a una compra, mostrando los datos del usuario, la película, la fecha y hora de la función, la cantidad de entradas, el precio unitario, el subtotal y el total general de esa compra.

## 4. Reporte agregado de ventas por categoría

**Necesidad de información:** identificar qué categorías de películas tienen mayor actividad de ventas y recaudación durante un período determinado.

**Estrategia SQL:** se relacionan `ETIQUETA`, `PELICULA_ETIQUETA`, `PELICULA`, `FUNCION`, `COMPRA_FUNCION` y `COMPRA` mediante `INNER JOIN`. Se filtran las compras con `WHERE` y un rango de fechas. Luego, `GROUP BY` agrupa los resultados por identificador y descripción de la etiqueta. Se utilizan `COUNT(DISTINCT c.id_compra)` para contar compras diferentes, `SUM(cf.cantidad)` para sumar las entradas vendidas y `SUM(cf.cantidad * f.precio)` para calcular la recaudación asociada. Finalmente, `ORDER BY total_recaudado DESC` ordena las categorías desde la mayor hasta la menor recaudación.

**Resultado esperado:** obtener una fila por categoría, con la cantidad de compras distintas asociadas, el total de entradas vendidas y la recaudación calculada para el rango de fechas seleccionado.

**Consideración:** una película puede tener más de una etiqueta, por lo que una misma compra puede contribuir a más de una categoría. Por ello, los importes por categoría representan la recaudación asociada a cada etiqueta y no necesariamente partes exclusivas de un total general.

## 5. Películas con recaudación total mayor a 4000

**Necesidad de información:** identificar las películas cuya recaudación calculada supera el valor de 4000, para reconocer cuáles generaron mayores ingresos según los datos registrados.

**Estrategia SQL:** se combinan `PELICULA`, `FUNCION` y `COMPRA_FUNCION` mediante `JOIN`. La recaudación se calcula sumando el precio de cada función multiplicado por la cantidad de entradas (`SUM(f.precio * cf.cantidad)`). `GROUP BY p.titulo` agrupa los resultados por película y `HAVING` filtra los grupos cuya recaudación total es mayor que 4000.

**Resultado esperado:** obtener el título de cada película que supere el umbral establecido y su recaudación total calculada. Si ninguna película supera ese importe, la consulta no devolverá filas.

## 6. Usuarios que compraron entradas para funciones

**Necesidad de información:** conocer qué usuarios realizaron compras asociadas a funciones, sin mostrar usuarios que no tengan compras de ese tipo.

**Estrategia SQL:** se consultan los datos de `USUARIO` y se aplica un filtro `WHERE ... IN` con una subconsulta. La subconsulta relaciona `COMPRA` con `COMPRA_FUNCION` y obtiene los DNI asociados a compras que incluyen funciones.

**Resultado esperado:** obtener el DNI, nombre, apellido y correo de los usuarios que tengan al menos una compra asociada a una función. Cada usuario se presenta una sola vez en el resultado exterior, aunque haya realizado varias compras.

## 7. Funciones con compras de dos o más entradas

**Necesidad de información:** identificar funciones para las que existen compras con una cantidad de entradas igual o superior a dos, junto con la película y el horario correspondiente.

**Estrategia SQL:** se combinan `FUNCION`, `PELICULA` y `COMPRA_FUNCION` mediante `JOIN`. `GROUP BY` organiza los resultados por identificador de función, película, fecha, hora y cantidad de entradas. `HAVING cf.cantidad >= 2` conserva los grupos cuya cantidad registrada cumple esa condición.

**Resultado esperado:** mostrar el identificador de la función, el título de la película, la fecha, la hora y la cantidad de entradas de los registros que cumplen el mínimo de dos entradas.

**Consideración:** la consulta filtra cantidades registradas en `COMPRA_FUNCION`; no suma necesariamente todas las entradas de distintas compras para una misma función. Si se necesita conocer el total acumulado de entradas vendidas por función, habría que utilizar `SUM(cf.cantidad)` y agrupar por los datos de la función.

## Conclusión

Las consultas permiten inspeccionar los datos cargados, comprobar la cantidad de registros, consultar el detalle de una compra y obtener reportes de ventas y recaudación. Se utilizan estrategias SQL como `SELECT`, `JOIN`, subconsultas, `WHERE`, `GROUP BY`, `HAVING`, `COUNT`, `SUM` y funciones de ventana para responder distintas necesidades de información del sistema CINEMA.

