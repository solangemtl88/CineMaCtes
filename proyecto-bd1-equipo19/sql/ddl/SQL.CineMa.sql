-- ============================================
-- CREACION DE BASE DE DATOS



CREATE DATABASE CINEMA; 


-- ============================================
-- CREACION DE TABLAS

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

