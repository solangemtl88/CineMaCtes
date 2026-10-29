USE CINEMA;
GO

-- INSERCION DE DATOS EN TABLAS PRINCIPALES
  
--  USUARIO
INSERT INTO USUARIO (dni, nombre, apellido, correo, contrasenia) VALUES
(30111222, 'Juan', 'Pérez', 'juan.perez@email.com', 'Pass1234'),
(31222333, 'María', 'Gómez', 'maria.gomez@email.com', 'Pass5678'),
(32333444, 'Carlos', 'López', 'carlos.lopez@email.com', 'Pass9012'),
(33444555, 'Ana', 'Martínez', 'ana.martinez@email.com', 'Pass3456'),
(34555666, 'Lucas', 'Rodríguez', 'lucas.rodriguez@email.com', 'Pass7890'),
(35666777, 'Sofia', 'Fernández', 'sofia.fernandez@email.com', 'Pass2345'),
(36777888, 'Diego', 'Sánchez', 'diego.sanchez@email.com', 'Pass6789'),
(37888999, 'Laura', 'Díaz', 'laura.diaz@email.com', 'Pass0123'),
(38999000, 'Gonzalo', 'Romero', 'gonzalo.romero@email.com', 'Pass4567'),
(39000111, 'Camila', 'Alvarez', 'camila.alvarez@email.com', 'Pass8901');

--  BENEFICIO 
INSERT INTO BENEFICIO (id_beneficio, descripcion, descuento) VALUES
(1, 'Sin Beneficio', 0),
(2, 'Estudiante Universitario', 20),
(3, 'Jubilados y Pensionados', 30),
(4, 'Socio Cine Club', 15),
(5, 'Promoción 2x1 Martes', 50),
(6, 'Descuento Banco Galicia', 25),
(7, 'Descuento Mercado Pago', 10),
(8, 'Cliente Premium', 35),
(9, 'Cumpleañero', 100),
(10, 'Personal Docente', 15);

-- PELICULA 
INSERT INTO PELICULA (id_pelicula, titulo, duracion, sinopsis) VALUES
(1, 'Inception', '148 min', 'Un ladrón que roba secretos corporativos a través del uso de la tecnología de compartir sueños.'),
(2, 'Interstellar', '169 min', 'Un grupo de exploradores viaja a través de un agujero de gusano en el espacio.'),
(3, 'The Dark Knight', '152 min', 'Batman lucha contra el crimen organizado en Gotham y enfrenta al Joker.'),
(4, 'Avatar: El Camino del Agua', '192 min', 'Jake Sully vive con su nueva familia formada en el planeta Pandora.'),
(5, 'Spider-Man: Across the Spider-Verse', '140 min', 'Miles Morales catapultado a través del Multiverso.'),
(6, 'Oppenheimer', '180 min', 'La historia del físico estadounidense J. Robert Oppenheimer y su papel en la bomba atómica.'),
(7, 'Barbie', '114 min', 'Barbie sufre una crisis que la hace cuestionar su mundo y su existencia.'),
(8, 'Gladiador', '155 min', 'Un ex general romano busca venganza contra el corrupto emperador que asesinó a su familia.'),
(9, 'Titanic', '195 min', 'Un aristócrata de diecisiete años se enamora de un artista amable pero pobre a bordo del Titanic.'),
(10, 'El Señor de los Anillos', '178 min', 'Un hobbit de la Comarca y sus compañeros emprenden un viaje para destruir el Anillo Único.');

-- ESTADO_FUNCION 
INSERT INTO ESTADO_FUNCION (id_estado_funcion, descripcion) VALUES
(1, 'Programada'),
(2, 'En Cartelera'),
(3, 'Entradas Agotadas'),
(4, 'En Emisión'),
(5, 'Finalizada'),
(6, 'Cancelada'),
(7, 'Suspendida por fallas técnicas'),
(8, 'Reprogramada'),
(9, 'Próximamente'),
(10, 'Privada / Evento Especial');

--  SALA
INSERT INTO SALA (id_sala, capacidad) VALUES
(1, 120),
(2, 100),
(3, 80),
(4, 150),
(5, 200),
(6, 90),
(7, 110),
(8, 75),
(9, 130),
(10, 160);

-- ETIQUETA 
INSERT INTO ETIQUETA (id_etiqueta, descripcion) VALUES
(1, 'Acción'),
(2, 'Ciencia Ficción'),
(3, 'Drama'),
(4, 'Aventura'),
(5, 'Comedia'),
(6, 'Animación'),
(7, 'Suspenso'),
(8, 'Romance'),
(9, 'Fantasía'),
(10, 'Historia');
GO
