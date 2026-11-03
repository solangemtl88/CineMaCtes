# Etapa I — Decisiones de Diseño Iniciales

## 1. Fundamentación de las Decisiones de Requerimientos
Para responder a los objetivos de **CineMaCtes**, el análisis inicial derivó en las siguientes decisiones clave de arquitectura funcional:

1. **Estructura Modular e Integrada:** Se definió una separación lógica en 5 módulos (Boletos, Cartelera, Candy, Beneficios, Consultas) pero interconectados operacionalmente para permitir compras unificadas (ej. entradas + combos de pochoclos en un mismo comprobante).
2. **Priorización de la Integridad de Datos sobre la Flexibilidad Excesiva:** Se decidió que reglas como la asignación exclusiva de butacas (RN05) y la capacidad máxima de sala (RN06) debían controlarse de forma estricta para evitar la sobreventa, trasladando estas restricciones desde la capa de requerimientos hasta las futuras validaciones de base de datos.
3. **Preservación de Trazabilidad Histórica:** La regla RN03 (Historial de Precios Unitarios) se estableció como requisito no negociable para impedir recálculos erróneos en auditorías o reportes contables tras cambios de tarifas en el catálogo.

## 2. Conclusión de la Etapa
Los requerimientos definidos y las 10 reglas de negocio constituyen la columna vertebral sobre la cual se erige el modelado conceptual, relacional y la implementación en SQL Server Express para el sistema de cine **CineMaCtes**.
