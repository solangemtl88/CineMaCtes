# Etapa II — Decisiones de Diseño del Modelo Relacional

A partir del análisis del dominio del cine y la aplicación de las reglas de normalización, se fundamentan las siguientes decisiones de diseño relacional para **CineMaCtes**:

1. **Utilización del DNI como Clave Primaria en `USUARIO`:** Se adoptó el número de documento como identificador natural y único de cada usuario, facilitando las búsquedas y vinculaciones con la facturación.
2. **Identificadores Autogenerados/Correlativos:** Se asignaron identificadores simples (`INT`) a tablas de alto volumen o catálogo (`COMPRA`, `PELICULA`, `SALA`, `FUNCION`) para optimizar el almacenamiento de claves foráneas e índices.
3. **Nulabilidad Opcional en `COMPRA.id_beneficio`:** Se definió explícitamente que la columna `id_beneficio` admita valores `NULL`. Esto permite registrar ventas al público general que no apliquen ningún cupón o descuento de fidelización.
4. **Tabla Tripartita `COMPRA_FUNCION`:** Para soportar la reserva exacta de asientos por función y compra, se diseñó `COMPRA_FUNCION` relacionando `(id_compra, id_funcion, id_butaca)`. Esto garantiza la trazabilidad precisa de qué cliente ocupó qué butaca en qué proyección.
5. **Restricciones NOT NULL:** Se aplicó la condición de obligatoriedad a todos los atributos descriptivos críticos (precios, capacidades, fechas, contraseñas), resguardando la calidad de los datos cargados.
