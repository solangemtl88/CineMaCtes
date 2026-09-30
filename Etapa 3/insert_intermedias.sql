
-- Insertar datos en tablas intermedias


USE CINEMA;

-- COMPRA (depende de USUARIO)

INSERT INTO COMPRA (id_compra, fecha, dni)
VALUES
(1, '2024-10-01', 1001),
(2, '2024-10-02', 1002),
(3, '2024-10-02', 1003),
(4, '2024-10-03', 1004),
(5, '2024-10-04', 1005),
(6, '2024-10-05', 1006),
(7, '2024-10-05', 1007),
(8, '2024-10-06', 1008),
(9, '2024-10-07', 1009),
(10, '2024-10-08', 1010);

-- FUNCION (depende de PELICULA, ESTADO_FUNCION, SALA)

INSERT INTO FUNCION (id_funcion, fecha, hora, precio, id_pelicula, id_estado_funcion, id_sala)
VALUES
(1, '2024-10-10', '18:00:00', 4500, 1, 1, 1),
(2, '2024-10-10', '21:00:00', 4800, 2, 1, 2),
(3, '2024-10-11', '17:30:00', 4200, 3, 2, 3),
(4, '2024-10-11', '20:00:00', 5000, 4, 1, 4),
(5, '2024-10-12', '16:00:00', 3800, 5, 1, 5),
(6, '2024-10-12', '19:00:00', 4500, 6, 7, 6),
(7, '2024-10-13', '15:00:00', 3500, 7, 1, 7),
(8, '2024-10-13', '18:30:00', 4300, 8, 1, 8),
(9, '2024-10-14', '20:30:00', 4600, 9, 1, 9),
(10, '2024-10-14', '22:15:00', 5200, 10, 1, 10);


-- BUTACA (depende de SALA)

INSERT INTO BUTACA (id_butaca, codigo_butaca, id_sala)
VALUES
(1, 'A1', 1),
(2, 'A2', 1),
(3, 'B1', 2),
(4, 'B2', 2),
(5, 'C1', 3),
(6, 'D1', 4),
(7, 'E1', 5),
(8, 'F1', 6),
(9, 'G1', 7),
(10, 'H1', 8);


-- PELICULA_ETIQUETA

INSERT INTO PELICULA_ETIQUETA (id_pelicula, id_etiqueta)
VALUES
(1, 2),
(1, 8),
(2, 2),
(2, 6),
(3, 1),
(3, 6),
(4, 3),
(5, 2),
(7, 5),
(9, 4);



-- Insertar datos en tablas finales

-- COMPRA_FUNCION (depende de COMPRA y FUNCION)

INSERT INTO COMPRA_FUNCION (cantidad, id_compra, id_funcion)
VALUES
(2, 1, 1),
(1, 2, 2),
(3, 3, 3),
(2, 4, 4),
(4, 5, 5),
(1, 6, 6),
(2, 7, 7),
(2, 8, 8),
(3, 9, 9),
(1, 10, 10);


-- USUARIO_BENEFICIO (depende de BENEFICIO, USUARIO y COMPRA)

INSERT INTO USUARIO_BENEFICIO (fecha_uso, id_usuario_beneficio, id_beneficio, dni, id_compra)
VALUES
('2024-10-01', 1, 1, 1001, 1),
('2024-10-02', 2, 2, 1002, 2),
('2024-10-02', 3, 3, 1003, 3),
('2024-10-03', 4, 4, 1004, 4),
('2024-10-04', 5, 5, 1005, 5),
('2024-10-05', 6, 6, 1006, 6),
('2024-10-05', 7, 7, 1007, 7),
('2024-10-06', 8, 8, 1008, 8),
('2024-10-07', 9, 9, 1009, 9),
('2024-10-08', 10, 10, 1010, 10);
