# Etapa I — Reglas de Negocio del Sistema

Las reglas de negocio establecen las condiciones y restricciones operativas que deben respetarse durante todas las transacciones y operaciones del sistema **CineMaCtes**.

---

### RN01 — Registro de Clientes
Toda compra de entradas o productos debe estar asociada obligatoriamente a un cliente registrado y autenticado en el sistema mediante su número de documento (DNI) y un correo electrónico único.

### RN02 — Gestión de Stock
La venta de productos del Candy está sujeta a la disponibilidad física en el inventario. No se podrá procesar ni confirmar la compra de un producto si la cantidad solicitada supera el stock disponible.

### RN03 — Historial de Precios Unitarios
Al registrar una venta, el precio unitario pactado de cada entrada o producto debe almacenarse de forma fija en la línea de detalle de la transacción. Esto garantiza que las modificaciones posteriores de los precios o del catálogo no alteren el importe histórico de las ventas ya realizadas.

### RN04 — Métodos de Pago
Toda venta debe concretarse mediante un método de pago válido y autorizado. Si la transacción es rechazada por fondos insuficientes o datos de pago inválidos, la venta queda cancelada y no se genera comprobante ni reserva de butacas.

### RN05 — Asignación Exclusiva de Butacas
Una butaca física dentro de una sala solo puede ser asignada a un único cliente por cada función específica. Queda prohibida la sobreventa o la doble asignación simultánea.

### RN06 — Capacidad Máxima de Sala
La cantidad total de boletos emitidos para una función no puede superar la capacidad total de butacas habilitadas en la sala asignada.

### RN07 — Políticas de Reembolso y Modificación
La solicitud de reembolso o cambio de asiento solo es admisible para boletos vigentes y siempre que la función correspondiente aún no haya iniciado. Un boleto utilizado o cuya función ya se haya realizado no admite reembolso ni reasignación.

### RN08 — Vigencia de Beneficios
Los cupones, promociones y descuentos solo podrán aplicarse a una compra si la transacción se efectúa dentro de su período formal de vigencia, con una fecha de inicio menor o igual a la fecha de fin, y si se cumplen las condiciones de compatibilidad de la promoción.

### RN09 — Superposición de Funciones
Una misma sala no puede tener asignadas dos o más funciones cuyos horarios y duraciones se superpongan cronológicamente.

### RN10 — Integridad de Cartelera y Productos
No se permite la eliminación de una película, función o producto del catálogo si se encuentra vinculado a transacciones activas o a boletos previamente vendidos.
