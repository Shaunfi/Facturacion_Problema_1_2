CREATE TABLE FORMAS_PAGO (
	id_forma_pago INT PRIMARY KEY IDENTITY(1,1),
	forma_pago VARCHAR(50)
);

CREATE TABLE CLIENTES (
	cod_cliente INT PRIMARY KEY IDENTITY(1,1),
	ape_cliente VARCHAR(100),
	nom_cliente VARCHAR(100),
);

CREATE TABLE FACTURACIONES (
	nro_factura INT PRIMARY KEY IDENTITY(1,1),
	cod_cliente INT,
	fecha DATETIME,
	id_forma_pago INT
	FOREIGN KEY (cod_cliente) REFERENCES CLIENTES (cod_cliente),
	FOREIGN KEY (id_forma_pago) REFERENCES FORMAS_PAGO (id_forma_pago)
);

CREATE TABLE ARTICULOS (
	id_articulo INT PRIMARY KEY IDENTITY(1,1),
	descripcion VARCHAR(100),
	pre_unitario MONEY
);

CREATE TABLE DETALLES_FACTURA (
	nro_factura INT,
	id_articulo INT,
	cantidad INT,
	pre_unitario MONEY
	PRIMARY KEY (nro_factura, id_articulo),
    FOREIGN KEY (nro_factura) REFERENCES FACTURACIONES (nro_factura),
    FOREIGN KEY (id_articulo) REFERENCES ARTICULOS (id_articulo)
);
