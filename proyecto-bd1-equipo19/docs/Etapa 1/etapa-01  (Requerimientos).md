
# Etapa 1 — Requerimientos del sistema


## 1. Introducción

El crecimiento de la industria cinematográfica y la digitalización de los servicios de entretenimiento han impulsado la necesidad de sistemas que optimicen la gestión de boletos, funciones y productos asociados. Los cines modernos buscan ofrecer experiencias ágiles y personalizadas, reduciendo los tiempos de espera y mejorando la interacción entre clientes y personal administrativo.

En este contexto surge **CineMaCtes**, un sistema de gestión integral para la administración de boletos, cartelera, productos del Candy, beneficios y consultas de clientes.

El desarrollo de CineMaCtes busca automatizar y centralizar las operaciones del cine, permitiendo una gestión más eficiente de boletos, funciones y productos. Además, brinda al cliente una plataforma para realizar compras, solicitar reembolsos y acceder a beneficios. Con ello se busca mejorar la calidad del servicio, optimizar los recursos humanos y facilitar la comunicación entre clientes y administradores.

## 2. Objetivo general

Diseñar e implementar un sistema de gestión de boletos de cine que permita administrar de forma integrada las operaciones de venta, reembolso, cartelera, productos del Candy, beneficios y consultas de clientes.

## 3. Alcance del sistema

El sistema abarca tanto las operaciones realizadas por los clientes, como la compra de entradas y productos, como las tareas administrativas relacionadas con la gestión de ventas, cartelera, productos y beneficios.

CineMaCtes contempla los siguientes módulos y funcionalidades:

### 3.1. Gestión de boletos

Permite al cliente iniciar la compra o reserva de entradas. Incluye la posibilidad de solicitar cambios en los detalles del boleto, como el asiento o la función, sujetos a las políticas establecidas por el sistema.

### 3.2. Gestión de cartelera

Permite al administrador añadir películas, modificar horarios y salas, y eliminar funciones obsoletas, de acuerdo con las restricciones del sistema.

Para el cliente, ofrece la visualización de la cartelera actual, con información sobre las películas, los horarios disponibles y las sinopsis.

### 3.3. Gestión de productos del Candy

Contempla la preventa de alimentos y bebidas, como pochoclos, refrescos y combos. Estos productos pueden añadirse al carrito junto con las entradas para facilitar la compra y reducir los tiempos de espera en el recinto.

### 3.4. Acceso a beneficios

Permite al cliente consultar beneficios asociados a la fidelidad, como puntos acumulados, cupones de descuento y promociones exclusivas.

### 3.5. Gestión de consultas

Contempla la atención de dudas, quejas y sugerencias de los clientes mediante formularios de contacto o chats de soporte.

## 4. Descripción del caso

CineMaCtes es un sistema de gestión para un cine que permite centralizar y administrar las principales operaciones del negocio. El sistema contempla la venta de entradas, la gestión de funciones y salas, la venta de productos del Candy, la aplicación de beneficios y la atención de consultas de los clientes.

## 5. Actores del sistema

A partir de las funcionalidades descritas, se identifican los siguientes actores principales:

- **Cliente:** consulta la cartelera, compra entradas y productos, accede a beneficios y puede solicitar cambios o reembolsos sujetos a las políticas del sistema.
- **Administrador:** gestiona las películas, las funciones, las salas, los productos y los beneficios, además de participar en la administración de las operaciones del cine.

Las consultas de los clientes constituyen otra interacción contemplada por el sistema. El texto de requerimientos no especifica otros perfiles de usuario ni sus permisos particulares.

## 6. Operaciones principales

Las operaciones contempladas en los requerimientos son:

- Consultar películas, sinopsis y horarios disponibles.
- Comprar o reservar entradas.
- Seleccionar o modificar asientos y funciones, de acuerdo con las políticas aplicables.
- Comprar productos del Candy junto con las entradas.
- Consultar y aplicar beneficios y promociones.
- Solicitar reembolsos cuando se cumplan las condiciones establecidas.
- Gestionar películas, funciones y salas.
- Gestionar productos y beneficios.
- Recibir y atender consultas, quejas y sugerencias de los clientes.

## 7. Reglas de negocio

Las reglas de negocio establecen las condiciones que deben respetarse durante las operaciones del sistema.

### RN01 — Registro de clientes

Toda compra de entradas o productos debe estar asociada obligatoriamente a un cliente registrado y autenticado en el sistema mediante su número de documento (DNI) y un correo electrónico único.

### RN02 — Gestión de stock

La venta de productos del Candy está sujeta a la disponibilidad física en el inventario. No se podrá procesar ni confirmar la compra de un producto si la cantidad solicitada supera el stock disponible.

### RN03 — Historial de precios unitarios

Al registrar una venta, el precio unitario pactado de cada entrada o producto debe almacenarse de forma fija en la línea de detalle de la transacción. Esto garantiza que las modificaciones posteriores de los precios o del catálogo no alteren el importe histórico de las ventas ya realizadas.

### RN04 — Métodos de pago

Toda venta debe concretarse mediante un método de pago válido y autorizado. Si la transacción es rechazada por fondos insuficientes o datos de pago inválidos, la venta queda cancelada y no se genera comprobante ni reserva de butacas.

### RN05 — Asignación exclusiva de butacas

Una butaca física dentro de una sala solo puede ser asignada a un único cliente por cada función específica. Queda prohibida la sobreventa o la doble asignación simultánea.

### RN06 — Capacidad máxima de sala

La cantidad total de boletos emitidos para una función no puede superar la capacidad total de butacas habilitadas en la sala asignada.

### RN07 — Políticas de reembolso y modificación

La solicitud de reembolso o cambio de asiento solo es admisible para boletos vigentes y siempre que la función correspondiente aún no haya iniciado. Un boleto utilizado o cuya función ya se haya realizado no admite reembolso ni reasignación.

### RN08 — Vigencia de beneficios

Los cupones, promociones y descuentos solo podrán aplicarse a una compra si la transacción se efectúa dentro de su período formal de vigencia, con una fecha de inicio menor o igual a la fecha de fin, y si se cumplen las condiciones de compatibilidad de la promoción.

### RN09 — Superposición de funciones

Una misma sala no puede tener asignadas dos o más funciones cuyos horarios y duraciones se superpongan cronológicamente.

### RN10 — Integridad de cartelera y productos

No se permite la eliminación de una película, función o producto del catálogo si se encuentra vinculado a transacciones activas o a boletos previamente vendidos.

## 8. Conclusión

CineMaCtes busca centralizar las principales operaciones de un cine mediante la gestión de entradas, funciones, salas, productos del Candy, beneficios y consultas de clientes.

El alcance y las reglas de negocio establecen las funcionalidades contempladas y las condiciones que deben respetarse para mantener la disponibilidad de productos, evitar conflictos en la asignación de butacas, controlar la capacidad de las salas, preservar los importes históricos y regular las modificaciones, los reembolsos y el uso de promociones.

Estos requerimientos constituyen la base para el modelado de los datos, la implementación de la base de datos y las etapas posteriores del proyecto.
