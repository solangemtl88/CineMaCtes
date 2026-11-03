# Etapa III — Carga de Datos de Prueba y Validación

## 1. Carga de Datos de Prueba (DML `INSERT`)
Para validar el funcionamiento del modelo relacional y la consistencia de las restricciones de integridad, se ejecutaron scripts DML de inserción con datos representativos del negocio **CineMaCtes**.

---

## 2. Cobertura de Datos Cargados

### 2.1. Tablas Principales / Catálogos:
* **`USUARIO`:** 10 usuarios cargados con DNI, nombres, apellidos, correos únicos y contraseñas.
* **`BENEFICIO`:** 10 promociones registradas (ej. *Estudiante Universitario* 20%, *Socio Cine Club* 15%, *Descuento Banco Galicia* 25%, *Cumpleañero* 50%, etc.).
* **`PELICULA`:** 10 títulos cinematográficos registrados (ej. *Inception*, *Interstellar*, *The Dark Knight*, *Oppenheimer*, *Avatar*, etc.).
* **`ESTADO_FUNCION`:** 10 estados de función cargados (ej. *Programada*, *En Curso*, *Entradas Agotadas*, *Finalizada*, etc.).
* **`SALA`:** 10 salas registradas con capacidades reales de butacas.
* **`ETIQUETA`:** 10 categorías de género para clasificación.

### 2.2. Tablas Intermedias y Transaccionales:
* **`BUTACA`:** 10 registros de butacas físicas asociadas a las salas.
* **`PELICULA_ETIQUETA`:** 10 vinculaciones de género por película.
* **`FUNCION`:** 10 proyecciones programadas con fecha, hora y precio unitario.
* **`COMPRA`:** 11 comprobantes de compra de prueba registrados.
* **`COMPRA_FUNCION`:** 11 detalles de venta vinculando compras, funciones, butacas y cantidades.

---

## 3. Conclusión de la Implementación
La carga de datos confirmó la validez del esquema DDL en **SQL Server Express**. Todas las claves primarias y foráneas operaron correctamente, dejando la base de datos `CINEMA` completamente poblada y lista para la ejecución de consultas, reportes y mecanismos avanzados en las etapas posteriores.
