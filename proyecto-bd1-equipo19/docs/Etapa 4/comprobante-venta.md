# Etapa 4 — Factura y Comprobante de Compra

## Factura o Comprobante de una Compra

* **Necesidad de información:** Consultar en un mismo resultado los datos generales de una compra, la información del usuario que la realizó y el detalle de las funciones para las que se adquirieron entradas. También se necesita conocer el subtotal de cada renglón y el total acumulado de la compra.

* **Estrategia SQL:** Se combinan las tablas `COMPRA`, `USUARIO`, `COMPRA_FUNCION`, `FUNCION` y `PELICULA` mediante `JOIN`, relacionándolas a través de sus identificadores. El subtotal de cada renglón se calcula multiplicando el precio de la función por la cantidad de entradas (`f.precio * cf.cantidad`). Para obtener el total de la compra se utiliza la función de ventana `SUM(...) OVER (PARTITION BY c.id_compra)`, que suma los subtotales correspondientes a cada compra sin agrupar ni ocultar el detalle de sus renglones.

* **Resultado esperado:** Obtener una fila por cada detalle de función asociado a una compra, mostrando los datos del usuario, la película, la fecha y hora de la función, la cantidad de entradas, el precio unitario, el subtotal y el total general de esa compra.
