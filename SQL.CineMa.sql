
CREATE DATABASE CINEMA; 

CREATE TABLE USUARIO
(
  dni INT NOT NULL,
  nombre VARCHAR(50) NOT NULL,
  apellido VARCHAR(50) NOT NULL,
  correo VARCHAR(50) NOT NULL,
  contrasenia VARCHAR(50) NOT NULL,
  PRIMARY KEY (dni)
);

CREATE TABLE BENEFICIO
(
  id_beneficio INT NOT NULL,
  descripcion_ VARCHAR(100) NOT NULL,
  descuento INT NOT NULL,
  PRIMARY KEY (id_beneficio)
);

CREATE TABLE COMPRA
(
  id_compra INT NOT NULL,
  fecha DATE NOT NULL,
  dni INT NOT NULL,
  PRIMARY KEY (id_compra),
  FOREIGN KEY (dni) REFERENCES USUARIO(dni)
);

CREATE TABLE PELICULA
(
  id_pelicula INT NOT NULL,
  sinopsis VARCHAR(100) NOT NULL,
  duracion VARCHAR(50) NOT NULL,
  titulo VARCHAR(100) NOT NULL,
  PRIMARY KEY (id_pelicula)
);

CREATE TABLE ESTADO_FUNCION
(
  id_estado_funcion INT NOT NULL,
  descripcion VARCHAR(100) NOT NULL,
  PRIMARY KEY (id_estado_funcion)
);

CREATE TABLE SALA
(
  id_sala INT NOT NULL,
  capacidad INT NOT NULL,
  PRIMARY KEY (id_sala)
);

CREATE TABLE FUNCION
(
  id_funcion INT NOT NULL,
  fecha DATE NOT NULL,
  hora TIME NOT NULL,
  precio INT NOT NULL,
  id_pelicula INT NOT NULL,
  id_estado_funcion INT NOT NULL,
  id_sala INT NOT NULL,
  PRIMARY KEY (id_funcion),
  FOREIGN KEY (id_pelicula) REFERENCES PELICULA(id_pelicula),
  FOREIGN KEY (id_estado_funcion) REFERENCES ESTADO_FUNCION(id_estado_funcion),
  FOREIGN KEY (id_sala) REFERENCES SALA(id_sala)
);

CREATE TABLE ETIQUETA
(
  id_etiqueta INT NOT NULL,
  descripcion VARCHAR(50) NOT NULL,
  PRIMARY KEY (id_etiqueta)
);

CREATE TABLE BUTACA
(
  id_butaca INT NOT NULL,
  codigo_butaca VARCHAR(10) NOT NULL,
  id_sala INT NOT NULL,
  PRIMARY KEY (id_butaca),
  FOREIGN KEY (id_sala) REFERENCES SALA(id_sala)
);

CREATE TABLE USUARIO_BENEFICIO
(
  fecha_uso DATE NOT NULL,
  id_usuario_beneficio INT NOT NULL,
  id_beneficio INT NOT NULL,
  dni INT NOT NULL,
  id_compra INT NOT NULL,
  PRIMARY KEY (id_beneficio, dni, id_usuario_beneficio),
  FOREIGN KEY (id_beneficio) REFERENCES BENEFICIO(id_beneficio),
  FOREIGN KEY (dni) REFERENCES USUARIO(dni),
  FOREIGN KEY (id_compra) REFERENCES COMPRA(id_compra)
);

CREATE TABLE COMPRA_FUNCION
(
  cantidad INT NOT NULL,
  id_compra INT NOT NULL,
  id_funcion INT NOT NULL,
  PRIMARY KEY (id_compra, id_funcion),
  FOREIGN KEY (id_compra) REFERENCES COMPRA(id_compra),
  FOREIGN KEY (id_funcion) REFERENCES FUNCION(id_funcion)
);

CREATE TABLE PELICULA_ETIQUETA
(
  id_pelicula INT NOT NULL,
  id_etiqueta INT NOT NULL,
  PRIMARY KEY (id_pelicula, id_etiqueta),
  FOREIGN KEY (id_pelicula) REFERENCES PELICULA(id_pelicula),
  FOREIGN KEY (id_etiqueta) REFERENCES ETIQUETA(id_etiqueta)
);

-- 1. TABLAS PRINCIPALES (Sin dependencias)

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

-- 2. TABLAS INTERMEDIAS (Dependencia Nivel 1)

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

-- 3. TABLAS FINALES (Dependencia Nivel 2)

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