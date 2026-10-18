# 🎬 CineMaCtes

<div align="center">
  
### Sistema de Gestión Integral para Cine y Candy Bar

<p>
  <img src="https://img.shields.io/badge/UNNE-Base%20de%20Datos%20I-blue?style=for-the-badge" alt="UNNE Base de Datos I">
  <img src="https://img.shields.io/badge/Proyecto-Integrador%202026-orange?style=for-the-badge" alt="Proyecto Integrador 2026">
  <img src="https://img.shields.io/badge/Grupo-19-green?style=for-the-badge" alt="Grupo 19">
  <img src="https://img.shields.io/badge/Estado-En%20desarrollo-yellow?style=for-the-badge" alt="Estado">
</p>

</div>

---

## <code>01</code> Presentación y contexto

El crecimiento de la industria cinematográfica y la digitalización de los servicios de entretenimiento han impulsado la necesidad de sistemas que optimicen la gestión de boletos, funciones y productos asociados. 

**CineMaCtes** surge como un sistema de gestión integral orientado a automatizar y centralizar las operaciones de un complejo de cines. El sistema permite administrar de manera integrada la cartelera, funciones, reservas y venta de entradas, el stock y preventa de alimentos en el Candy Bar, la aplicación de beneficios y cupones de fidelización, así como la atención de consultas y reclamos de los clientes.

---

## <code>02</code> Problemática

En la gestión tradicional de cines se presentan dificultades operativas críticas:
* Riesgo de sobreventa o asignación doble de butacas durante funciones de alta demanda.
* Falta de sincronización entre el stock real de productos en el Candy Bar y las órdenes emitidas.
* Inconsistencias históricas de precios ante cambios en el catálogo.
* Complejidad en la aplicación de promociones, cupones de descuento y políticas de reembolso en tiempo real.

---

## <code>03</code> Objetivo general

Diseñar e implementar un sistema de gestión de boletos de cine que permita administrar de forma integrada las operaciones de venta, reembolso, cartelera, productos del Candy, beneficios y consultas de clientes.

---

## <code>04</code> Alcance del sistema

El sistema contempla tanto la experiencia del usuario/cliente como la administración interna:

* **Gestión de Boletos:** Solicitud de compra/reserva, selección de asientos, cambios de detalles y gestión de reembolsos sujetos a políticas.
* **Gestión de Cartelera:** Administración de películas, asignación de salas y horarios de funciones para administradores; visualización detallada, sinopsis y horarios para clientes.
* **Gestión de Productos Candy:** Módulo de preventa de alimentos y bebidas (popcorn, refrescos, combos) para ser integrados al carrito de compra.
* **Acceso a Beneficios:** Visualización de puntos acumulados, cupones de descuento y promociones por fidelidad.
* **Gestión de Consultas:** Módulo para recepción, procesamiento y respuesta de dudas, quejas y sugerencias.

---

## <code>05</code> Reglas de Negocio (RN)

1. **RN01 (Registro de clientes):** Toda compra de entradas o productos debe estar asociada obligatoriamente a un cliente registrado y autenticado por DNI y correo electrónico único.
2. **RN02 (Gestión de stock):** La venta de productos del Candy está sujeta a la disponibilidad física en el inventario.
3. **RN03 (Historial de precios unitarios):** El precio unitario de cada entrada o producto se almacena de forma fija en la transacción para mantener el historial invariable.
4. **RN04 (Métodos de pago):** Toda venta debe concretarse con un método de pago válido y autorizado para generar comprobante y reserva.
5. **RN05 (Asignación exclusiva de butacas):** Una butaca física en una función solo puede ser asignada a un único cliente (prohibida sobreventa).
6. **RN06 (Capacidad máxima de sala):** El total de boletos emitidos no puede superar la capacidad máxima habilitada de la sala.
7. **RN07 (Políticas de reembolso y modificación):** Reembolsos y cambios solo aplican para boletos vigentes previa al inicio de la función.
8. **RN08 (Vigencia de beneficios):** Las promociones y cupones solo son aplicables dentro de su período formal de vigencia y bajo sus condiciones.
9. **RN09 (Superposición de funciones):** Una misma sala no puede tener funciones con horarios/duraciones que se superpongan cronológicamente.
10. **RN10 (Integridad de cartelera y productos):** No se permite eliminar películas, funciones o productos vinculados a transacciones activas o boletos vendidos.

---

## <code>06</code> Estructura del repositorio
```text
proyecto-bd1-equipo19/
│
├── docs/
│   ├── [Etapa 2](docs/Etapa%202)/
│   │   ├── [Forma Normal 1FN y 2FN.md](docs/Etapa%202/Forma%20Normal%201FN%20y%202FN.md)
│   │   ├── [Modelo Entidad Relacion.png](docs/Etapa%202/Modelo%20Entidad%20Relacion.png)
│   │   ├── [Modelo Relacional.png](docs/Etapa%202/Modelo%20Relacional.png)
│   │   └── [forma normal 3FN.md](docs/Etapa%202/forma%20normal%203FN.md)
│   │
│   ├── [Etapa 3](docs/Etapa%203)/
│   │
│   └── [Etapa 4](docs/Etapa%204)/
│       └── [Descripción.md](docs/Etapa%204/Descripción.md)
│
├── sql/
│   ├── [consultas](sql/consultas)/
│   │   ├── [Comprobante.sql](sql/consultas/Comprobante.sql)
│   │   └── [consultas.sql](sql/consultas/consultas.sql)
│   │
│   ├── [ddl](sql/ddl)/
│   │   └── [SQL.CineMa.sql](sql/ddl/SQL.CineMa.sql)
│   │
│   └── [dml](sql/dml)/
│       ├── [insert_intermedias.sql](sql/dml/insert_intermedias.sql)
│       └── [insert_principales.sql](sql/dml/insert_principales.sql)
│
├── .gitignore
└── README.md
```

Integrantes (Grupo 19)
Acosta, Celio Elizeo — D.N.I. N° 44.718.594

Batalla, Juan Cruz — D.N.I. N° 44.718.979

Pérez, Rodrigo — D.N.I. N° 43.783.504

Teruel Laola, Melanie Solange — D.N.I. N° 45.020.586

Universidad Nacional del Nordeste (UNNE) — Facultad de Ciencias Exactas y Naturales y Agrimensura (FACENA)

Cátedra: Base de Datos I — Año 2026
