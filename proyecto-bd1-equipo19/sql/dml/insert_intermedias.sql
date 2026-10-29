
-- Insertar datos en tablas intermedias


-- 1. BUTACA (10 registros asociados a las salas de la 1 a la 10)
INSERT INTO BUTACA (id_butaca, codigo_butaca, id_sala) VALUES
(1, 'A1', 1),
(2, 'A2', 1),
(3, 'B1', 2),
(4, 'B2', 2),
(5, 'C1', 3),
(6, 'C2', 4),
(7, 'D1', 5),
(8, 'D2', 6),
(9, 'E1', 7),
(10, 'E2', 8);

-- 2. PELICULA_ETIQUETA (10 relaciones entre películas y géneros/etiquetas)
INSERT INTO PELICULA_ETIQUETA (id_pelicula, id_etiqueta) VALUES
(1, 2), -- Inception -> Ciencia Ficción
(1, 7), -- Inception -> Suspenso
(2, 2), -- Interstellar -> Ciencia Ficción
(3, 1), -- The Dark Knight -> Acción
(4, 2), -- Avatar -> Ciencia Ficción
(5, 6), -- Spider-Man -> Animación
(6, 10),-- Oppenheimer -> Historia
(7, 5), -- Barbie -> Comedia
(8, 1), -- Gladiador -> Acción
(9, 8); -- Titanic -> Romance

-- 3. FUNCION (10 funciones programadas)
INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala) VALUES
(1, '2026-11-01', '18:00:00', 4500, 1, 2, 1),
(2, '2026-11-01', '21:00:00', 5000, 2, 2, 2),
(3, '2026-11-02', '19:30:00', 4000, 3, 2, 3),
(4, '2026-11-02', '22:00:00', 5500, 4, 1, 4),
(5, '2026-11-03', '17:00:00', 3800, 5, 2, 5),
(6, '2026-11-03', '20:00:00', 4800, 6, 2, 6),
(7, '2026-11-04', '18:30:00', 4200, 7, 1, 7),
(8, '2026-11-04', '21:30:00', 4500, 8, 2, 8),
(9, '2026-11-05', '19:00:00', 4000, 9, 5, 9),
(10, '2026-11-05', '22:30:00', 5000, 10, 1, 10);

-- 4. COMPRA (10 compras de usuarios con o sin beneficio)
INSERT INTO COMPRA (id_compra, fecha, dni, id_beneficio) VALUES
(1, '2026-10-25', 30111222, 1),  -- Juan Pérez, Sin beneficio
(2, '2026-10-25', 31222333, 2),  -- María Gómez, Estudiante
(3, '2026-10-26', 32333444, 5),  -- Carlos López, 2x1 Martes
(4, '2026-10-26', 33444555, 1),  -- Ana Martínez, Sin beneficio
(5, '2026-10-27', 34555666, 3),  -- Lucas Rodríguez, Jubilado
(6, '2026-10-27', 35666777, 4),  -- Sofia Fernández, Cine Club
(7, '2026-10-28', 36777888, 6),  -- Diego Sánchez, Galicia
(8, '2026-10-28', 37888999, 1),  -- Laura Díaz, Sin beneficio
(9, '2026-10-29', 38999000, 9),  -- Gonzalo Romero, Cumpleañero
(10, '2026-10-29', 39000111, 7); -- Camila Alvarez, Mercado Pago

-- 5. COMPRA_FUNCION (10 registros de tickets vendidos)
INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion, id_butaca) VALUES
(1, 1, 1, 1),
(1, 2, 2, 3),
(2, 3, 3, 5),
(1, 4, 4, 6),
(1, 5, 5, 7),
(2, 6, 6, 8),
(1, 7, 7, 9),
(1, 8, 8, 10),
(2, 9, 9, 2),
(1, 10, 10, 4);
GO
