
-- Insertar datos en tablas principales


USE CINEMA;


-- USUARIO
INSERT INTO USUARIO (dni, nombre, apellido, correo, contrasenia)
VALUES
(1001, 'Carlos', 'Gomez', 'carlos.gomez@gmail.com', 'pass1234'),
(1002, 'Maria', 'Lopez', 'maria.lopez@hotmail.com', 'mlopez2024'),
(1003, 'Juan', 'Perez', 'juan.perez@yahoo.com', 'juanp123'),
(1004, 'Lucia', 'Fernandez', 'lucia.f@gmail.com', 'luciaSegura!'),
(1005, 'Mateo', 'Diaz', 'mateo.diaz@outlook.com', 'mateoD88'),
(1006, 'Sofia', 'Romero', 'sofia.romero@gmail.com', 'sofiapass'),
(1007, 'Lucas', 'Torres', 'lucas.torres@gmail.com', 'lucasT99'),
(1008, 'Camila', 'Benitez', 'camila.b@gmail.com', 'cami2024'),
(1009, 'Diego', 'Acosta', 'diego.acosta@gmail.com', 'claveDiego1'),
(1010, 'Valeria', 'Silva', 'valeria.silva@gmail.com', 'valeriaPass');

-- BENEFICIO
INSERT INTO BENEFICIO (id_beneficio, descripcion_, descuento)
VALUES
(1, '2x1 Tarjeta Club Cine', 50),
(2, 'Descuento Estudiantes', 20),
(3, 'Descuento Jubilados', 30),
(4, 'Promo Cumpleanos', 100),
(5, 'Descuento Banco Ciudad', 25),
(6, 'Promo Clientes Frecuentes', 15),
(7, 'Descuento Tarjeta Joven', 10),
(8, 'Promo Lunes y Martes', 35),
(9, 'Descuento Corporativo', 18),
(10, 'Promo Fin de Semana', 12);

-- SALA

INSERT INTO SALA (id_sala, capacidad)
VALUES
(1, 120),
(2, 100),
(3, 80),
(4, 150),
(5, 60),
(6, 90),
(7, 110),
(8, 130),
(9, 70),
(10, 200);


-- ESTADO_FUNCION

INSERT INTO ESTADO_FUNCION (id_estado_funcion, descripcion)
VALUES
(1, 'Disponible'),
(2, 'Agotada'),
(3, 'Cancelada'),
(4, 'Reprogramada'),
(5, 'En curso'),
(6, 'Finalizada'),
(7, 'Preventa'),
(8, 'Suspendida'),
(9, 'Casi llena'),
(10, 'Exclusiva socios');

-- PELICULA

INSERT INTO PELICULA (id_pelicula, sinopsis, duracion, titulo)
VALUES
(1, 'Exploradores viajan por un agujero de gusano.', '169 min', 'Interstellar'),
(2, 'Un ladron roba secretos mediante el mundo de los suenos.', '148 min', 'Inception'),
(3, 'Batman combate el crimen organizado en Gotham.', '152 min', 'The Dark Knight'),
(4, 'Historia sobre el desarrollo de la bomba atomica.', '180 min', 'Oppenheimer'),
(5, 'Aventuras en una luna alienigena habitable llamada Pandora.', '162 min', 'Avatar'),
(6, 'Un general romano traicionado busca venganza.', '155 min', 'Gladiador'),
(7, 'Emociones que interactuan en la mente de una nina.', '95 min', 'Intensamente'),
(8, 'Un detective investiga un misterio en un tren clasico.', '110 min', 'Asesinato en el Orient'),
(9, 'La popular muneca viaja al mundo real en busca de respuestas.', '114 min', 'Barbie'),
(10, 'Carrera espacial por la supervivencia humana.', '125 min', 'Mision Espacial');


-- ETIQUETA

INSERT INTO ETIQUETA (id_etiqueta, descripcion)
VALUES
(1, 'Accion'),
(2, 'Ciencia Ficcion'),
(3, 'Drama'),
(4, 'Comedia'),
(5, 'Animacion'),
(6, 'Suspenso'),
(7, '3D'),
(8, 'Subtitulada'),
(9, 'Doblada'),
(10, 'IMAX');
