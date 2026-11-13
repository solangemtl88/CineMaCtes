# 🎬 CineMaCtes

<div align="center">
  
### Sistema de Gestión Integral para Cine

<p>
  <img src="https://img.shields.io/badge/UNNE-Base%20de%20Datos%20I-blue?style=for-the-badge" alt="UNNE Base de Datos I">
  <img src="https://img.shields.io/badge/Proyecto-Integrador%202026-orange?style=for-the-badge" alt="Proyecto Integrador 2026">
  <img src="https://img.shields.io/badge/Grupo-19-green?style=for-the-badge" alt="Grupo 19">
  <img src="https://img.shields.io/badge/Estado-Finalizado-yellow?style=for-the-badge" alt="Estado Finalizado">
</p>

</div>

---

## <img src="https://img.shields.io/badge/01-PRESENTACIÓN-blue?style=flat-square" alt="01"> Presentación General y Contexto

El crecimiento continuo de la industria cinematográfica y la transformación digital de los servicios de entretenimiento han generado la necesidad imperiosa de contar con sistemas de información robustos, eficientes y seguros. Los complejos de cines modernos requieren soluciones integradas que reduzcan los tiempos de espera en taquilla, prevengan errores en la asignación de butacas, garanticen la trazabilidad de los datos y aseguren la consistencia de las transacciones financieras en tiempo real.

En este marco surge **CineMaCtes**, una plataforma integral de gestión de base de datos desarrollada en **SQL Server Express** para la administración completa de un complejo de cines. El sistema centraliza el control de la cartelera de películas, la programación de funciones y salas, la venta y reserva de boletos, la aplicación de beneficios de fidelización de clientes, la auditoría automática de cambios tarifarios y la atención de consultas o reclamos.

---

## <img src="https://img.shields.io/badge/02-PROBLEMÁTICA-red?style=flat-square" alt="02"> Problemática y Objetivo General

### Problemática Operativa del Modelo Tradicional
En los sistemas tradicionales o descentralizados de gestión de cines suelen presentarse deficiencias operativas críticas:
* **Riesgo de sobreventa y colisión de butacas:** Asignaciones dobles en funciones de alta demanda por falta de controles de concurrencia y atomicidad a nivel de base de datos.
* **Superposición de funciones en salas:** Conflictos de horarios y falta de márgenes de limpieza entre proyecciones consecutivas.
* **Alteración involuntaria de la facturación histórica:** Cambios en el precio de catálogo de entradas que modifican retroactivamente el importe de compras ya cerradas.
* **Falta de trazabilidad en cambios tarifarios:** Ausencia de registros automáticos sobre modificaciones en los precios de las funciones, dificultando el control administrativo.
* **Vulnerabilidades de seguridad:** Accesos directos e irrestrictos a las tablas por parte de terminales de punto de venta (taquilla), sin control de roles ni encapsulamiento mediante procedimientos.

### Objetivo General del Proyecto
Diseñar, implementar, optimizar y documentar la base de datos relacional del sistema **CineMaCtes** en **SQL Server Express**, garantizando la integridad referencial, el cumplimiento estricto de las reglas de negocio, la atomicidad transaccional (propiedades ACID), la auditoría automática de cambios, el control de acceso granular basado en roles y la maximización del rendimiento mediante estrategias avanzadas de indexación.

---

## <img src="https://img.shields.io/badge/03-ALCANCE-green?style=flat-square" alt="03"> Alcance del Sistema y Módulos Funcionales

El sistema abarca tanto la perspectiva operativa del cliente como la administración integral del complejo:

| Módulo Funcional | Descripción y Responsabilidades Operativas |
| :--- | :--- |
| **Gestión de Boletos y Reservas** | Permite seleccionar funciones, verificar la disponibilidad de asientos en tiempo real, procesar compras individuales o múltiples y solicitar reembolsos/cambios según las políticas vigentes. |
| **Gestión de Cartelera y Salas** | Permite a la administración alta, baja y modificación de películas, asignación de salas con su capacidad máxima y programación de horarios evitando solapamientos. |
| **Fidelización y Beneficios** | Administra programas de puntos, cupones institucionales y descuentos por categoría de usuario (ej. Estudiante, Socio Cine Club, Cumpleañero, Banco Galicia). |

---

## <img src="https://img.shields.io/badge/04-REGLAS_DE_NEGOCIO-purple?style=flat-square" alt="04"> Reglas de Negocio (RN01 - RN10)

El motor de base de datos de **CineMaCtes** asegura el cumplimiento de las siguientes diez reglas de negocio fundamentales:

1. **RN01 — Registro Obligatorio de Clientes:** Toda venta de entradas debe estar vinculada obligatoriamente a un cliente registrado y autenticado mediante su número de documento (DNI) y correo electrónico único.
2. **RN02 — Asignación Exclusiva de Butaca:** Una butaca física en una función específica solo puede ser vendida a un único cliente, prohibiendo estrictamente la sobreventa o doble reserva.
3. **RN03 — Historial Invariable de Precios:** Al concretar una venta, el precio unitario pactado se almacena de forma fija en el detalle de la transacción, evitando que futuras actualizaciones de precios alteren la facturación histórica.
4. **RN04 — Validación de Métodos de Pago:** Toda compra debe concretarse con un medio de pago válido y autorizado; ante un rechazo, la transacción se cancela y no se emiten boletos.
5. **RN05 — Límite de Capacidad de Sala:** La cantidad total de boletos emitidos para una función no puede exceder la capacidad total de asientos de la sala asignada.
6. **RN06 — Políticas de Reembolso y Cambio:** Las solicitudes de reembolso o cambio solo son admisibles sobre boletos vigentes antes de que la función haya iniciado.
7. **RN07 — Vigencia de Beneficios:** Los cupones y promociones solo son aplicables si la compra se realiza dentro del período formal de vigencia y bajo las condiciones de la promoción.
8. **RN08 — Prevención de Superposición de Horarios:** Una sala no puede albergar dos o más funciones cuyos rangos de horario (incluyendo 15 minutos adicionales de limpieza) se solapen.
9. **RN09 — Integridad del Catálogo:** No se permite eliminar películas, funciones o salas vinculadas a transacciones activas o boletos previamente comercializados.
10. **RN10 — Auditoría de Tarifas:** Todo cambio en los precios de las funciones debe ser auditado de forma automática registrando el precio anterior, el nuevo, el usuario y la marca de tiempo en `AUDITORIA_PRECIO_FUNCION`.

---

## <img src="https://img.shields.io/badge/05-ESTRUCTURA-informational?style=flat-square" alt="05"> Estructura General del Repositorio

El repositorio se encuentra organizado de manera modular y estandarizada en GitHub, separando la documentación por etapas de los scripts SQL del proyecto:

```text
proyecto-bd1-equipo19/
│
├── docs/
│   ├── Etapa 1/
│   │   ├── alcance.md
│   │   ├── decisiones-diseno-e1.md
│   │   ├── descripcion-caso.md
│   │   ├── etapa-01 (Requerimientos).md
│   │   └── reglas-negocio.md
│   │
│   ├── Etapa 2/
│   │   ├── Forma Normal 1FN y 2FN.md
│   │   ├── Modelo Entidad Relacion.png
│   │   ├── Modelo Relacional.png
│   │   ├── decisiones-diseno-e2.md
│   │   ├── etapa-02 (Modelado).md
│   │   ├── forma normal 3FN.md
│   │   ├── modelo-relacional.md
│   │   └── normalizacion.md
│   │
│   ├── Etapa 3/
│   │   ├── etapa-03 (Implementación).md
│   │   ├── implementacion.md
│   │   ├── pruebas-validacion.md
│   │   └── restricciones-integridad.md
│   │
│   ├── Etapa 4/
│   │   ├── casos-uso.md
│   │   ├── comprobante-venta.md
│   │   ├── consulta-avanzada.md
│   │   ├── etapa-04 ( Consultas).md
│   │   └── informe-ventas.md
│   │
│   └── Etapa 5/
│       ├── indices-optimizacion.md
│       ├── procedimientos-funciones.md
│       ├── seguridad.md
│       ├── transacciones.md
│       └── triggers-auditoria.md
│
├── sql/
│   ├── consultas/
│   │   ├── Comprobante.sql
│   │   └── consultas.sql
│   │
│   ├── ddl/
│   │   └── SQL.CineMa.sql
│   │
│   ├── dml/
│   │   ├── insert_intermedias.sql
│   │   └── insert_principales.sql
│   │
│   └── tecnico/
│       ├── funciones/
│       │   ├── Evidencias_CalcularOcupacionFuncion y ObtenerComprobanteCompra.pdf
│       │   ├── fn_CalcularOcupacionFuncion.sql
│       │   └── fn_ObtenerComprobanteCompra.sql
│       ├── optimizacion con indices/
│       │   ├── evidencia_optimizacion.pdf
│       │   └── indices-optimizacion.sql
│       ├── procedimientos/
│       │   ├── Evidencias_ RegistrarCompraBoleto.pdf
│       │   └── RegistrarCompraBoleto.sql
│       ├── seguridad/
│       │   ├── Evidencias.De.Seguridad.pdf
│       │   └── seguridadRoles.sql
│       ├── transacciones/
│       │   ├── TransaccionRegistrarCompraBoleto.sql
│       │   └── transacciones.pdf
│       └── triggers/
│           ├── TRIGGERS.Evidencias.pdf
│           └── triggers.sql
│
├── .gitignore
└── README.md
```
---
---

## <img src="https://img.shields.io/badge/06-NAVEGACIÓN-blueviolet?style=flat-square" alt="06"> Guía de Navegación por Etapas y Entregables

La documentación del proyecto se divide en 5 etapas secuenciales que reflejan el ciclo de vida de desarrollo de la base de datos:

### Etapa 1: Requerimientos del Sistema (`docs/Etapa 1/`)
* **descripcion-caso.md:** Fundamentación del negocio, justificación de la plataforma y objetivos.
* **alcance.md:** Desglose detallado de los módulos funcionales, perfiles de usuario y catálogo de operaciones.
* **reglas-negocio.md:** Especificación formal de las reglas de negocio RN01 a RN10.
* **decisiones-diseno-e1.md:** Justificaciones iniciales de arquitectura e integridad de información.

### Etapa 2: Modelado de Datos (`docs/Etapa 2/`)
* **modelo-relacional.md:** Transformación del DER al Modelo Relacional de 12 tablas con claves primarias simples/compuestas y claves foráneas.
* **normalizacion.md:** Justificación formal del cumplimiento de **1FN**, **2FN** y **3FN** para eliminar redundancias y dependencias transitivas.
* **decisiones-diseno-e2.md:** Razonamiento detrás del uso del DNI como clave primaria en usuarios, nulabilidad de beneficios y tablas de asociación (`COMPRA_FUNCION`, `PELICULA_ETIQUETA`).

### Etapa 3: Implementación DDL/DML (`docs/Etapa 3/`)
* **implementacion.md:** Script de creación de la base de datos `CINEMA` y definición DDL de la estructura de tablas.
* **restricciones-integridad.md:** Especificación de restricciones `PRIMARY KEY`, `FOREIGN KEY` y la regla `NOT NULL` (con la excepción justificada de `COMPRA.id_beneficio`).
* **pruebas-validacion.md:** Proceso de población de la base de datos con datos de prueba realistas para la verificación del modelo.

### Etapa 4: Consultas y Casos de Uso (`docs/Etapa 4/`)
* **casos-uso.md:** Verificación global del contenido de las 12 tablas (`SELECT *`) y métricas de cantidad de registros (`COUNT(*)`).
* **comprobante-venta.md:** Consulta SQL de facturación con `JOIN` múltiple y función de ventana `SUM(...) OVER (PARTITION BY c.id_compra)`.
* **informe-ventas.md:** Reportes de ventas agregadas por categoría (`GROUP BY`, `COUNT(DISTINCT)`) y películas de alta recaudación (`HAVING > 4000`).
* **consulta-avanzada.md:** Subconsultas con `WHERE ... IN` y filtrado por volumen de entradas por función.

### Etapa 5: Mecanismos Avanzados en T-SQL (`docs/Etapa 5/`)
* **procedimientos-funciones.md:** Análisis de la función escalar `dbo.fn_CalcularOcupacionFuncion`, la función de tabla `dbo.fn_ObtenerComprobanteCompra` y el procedimiento `dbo.sp_RegistrarCompraBoleto`.
* **transacciones.md:** Garantía de propiedades **ACID** (Atomicidad, Consistencia, Aislamiento, Durabilidad) mediante `BEGIN TRANSACTION`, `COMMIT`, `ROLLBACK` y captura de excepciones con `TRY...CATCH`.
* **triggers-auditoria.md:** Desarrollo de 5 triggers automáticos (`trg_AuditoriaPrecioFuncion`, `trg_UnicoBeneficioPorUsuarioFecha`, `trg_ValidarHorarioFuncion`, `trg_ActualizarEstadoFuncionAgotada` y `trg_ValidarSuperposicionFunciones`).
* **seguridad.md:** Implementación del Principio de Mínimo Privilegio mediante Logins, Database Users, Roles de aplicación (`cajero`) y asignación de permisos de ejecución (`GRANT EXECUTE`) aislando las tablas.
* **indices-optimizacion.md:** Estrategia de optimización de rendimiento mediante 7 Índices No Agrupados de Cobertura (`INCLUDE`), acelerando consultas de cartelera, ventas por DNI y mapa de butacas.

---

## <img src="https://img.shields.io/badge/07-ARQUITECTURA-orange?style=flat-square" alt="07"> Arquitectura de la Base de Datos (12 Tablas)

La base de datos **CINEMA** se compone de 12 tablas relacionales optimizadas:

```sql
USUARIO (dni PK, nombre, apellido, correo, contrasena)
BENEFICIO (id_beneficio PK, descripcion_, descuento)
COMPRA (id_compra PK, fecha, dni FK, id_beneficio FK NULL)
PELICULA (id_pelicula PK, titulo, duracion, sinopsis)
ESTADO_FUNCION (id_estado_funcion PK, descripcion)
SALA (id_sala PK, capacidad)
FUNCION (id_funcion PK, fecha, hora, precio, id_pelicula FK, id_estado_funcion FK, id_sala FK)
BUTACA (id_butaca PK, codigo_butaca, id_sala FK)
ETIQUETA (id_etiqueta PK, descripcion)
COMPRA_FUNCION (id_compra PK/FK, id_funcion PK/FK, id_butaca PK/FK, cantidad)
PELICULA_ETIQUETA (id_pelicula PK/FK, id_etiqueta PK/FK)
AUDITORIA_PRECIO_FUNCION (id_auditoria PK, id_funcion FK, precio_anterior, precio_nuevo, fecha_modificacion, usuario, tipo_operacion)
```
---
---

---

## <img src="https://img.shields.io/badge/08-INSTALACIÓN-yellowgreen?style=flat-square" alt="08"> Guía de Instalación y Despliegue de Scripts SQL

Para desplegar la base de datos **CineMaCtes** en una instancia de **SQL Server Express**, ejecute los scripts ubicados en la carpeta `sql/` siguiendo estrictamente el siguiente orden de dependencia:

1. **Creación de Esquema DDL:**  
   Ejecutar `sql/ddl/SQL.CineMa.sql` para crear la base de datos `CINEMA`, las 12 tablas y las restricciones de claves primarias y foráneas.
2. **Carga de Datos de Prueba DML:**  
   Ejecutar `sql/dml/insert_principales.sql` (datos maestros) y luego `sql/dml/insert_intermedias.sql` (relaciones y ventas).
3. **Mecanismos Avanzados T-SQL:**  
   * Ejecutar `sql/tecnico/funciones/fn_CalcularOcupacionFuncion.sql`  
   * Ejecutar `sql/tecnico/funciones/fn_ObtenerComprobanteCompra.sql`  
   * Ejecutar `sql/tecnico/procedimientos/RegistrarCompraBoleto.sql`  
   * Ejecutar `sql/tecnico/triggers/triggers.sql`  
4. **Seguridad y Roles:**  
   Ejecutar `sql/tecnico/seguridad/seguridadRoles.sql` para crear los logins, usuarios de base de datos y otorgar permisos de ejecución al rol cajero.
5. **Optimización e Índices:**  
   Ejecutar `sql/tecnico/optimizacion con indices/indices-optimizacion.sql` para crear los 7 índices no agrupados de cobertura.

---

## <img src="https://img.shields.io/badge/09-CRÉDITOS-pink?style=flat-square" alt="09"> Integrantes del Equipo y Créditos

**Universidad Nacional del Nordeste (UNNE)**  
**Facultad de Ciencias Exactas y Naturales y Agrimensura (FACENA)**  
**Carrera:** Licenciatura en Sistemas de Información
**Cátedra:** Base de Datos I — Año 2026  

**Grupo 19:**  
* **Acosta, Celio Elizeo** — D.N.I. N° 44.718.594  
* **Batalla, Juan Cruz** — D.N.I. N° 44.718.979  
* **Pérez, Rodrigo** — D.N.I. N° 43.783.504  
* **Teruel Laola, Melanie Solange** — D.N.I. N° 45.020.586
