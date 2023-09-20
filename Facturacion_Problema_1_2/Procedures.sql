CREATE PROCEDURE SP_INSERTAR_ARTICULOS
@descripcion VARCHAR(100),
@pre_unitario MONEY
AS
BEGIN
	INSERT INTO ARTICULOS(descripcion, pre_unitario) VALUES (@descripcion, @pre_unitario);
END

CREATE PROCEDURE SP_INSERTAR_CLIENTES
@nom_cliente VARCHAR(100),
@ape_cliente VARCHAR(100)
AS
BEGIN
	INSERT INTO CLIENTES VALUES (@nom_cliente, @ape_cliente);
END


CREATE PROCEDURE SP_INSERTAR_FACTURAS
@cod_cliente VARCHAR(100),
@fecha DATETIME,
@id_forma_pago INT
AS
BEGIN
	INSERT INTO FACTURACIONES VALUES (@cod_cliente, @fecha, @id_forma_pago);
END

CREATE PROCEDURE SP_INSERTAR_DETALLES_FACTURA
@descripcion VARCHAR(100),
@pre_unitario MONEY
AS
BEGIN
	INSERT INTO DETALLES_FACTURA VALUES (@descripcion, @pre_unitario);
END





CREATE PROCEDURE SP_CONSULTAR_TABLA
    @nombre_tabla NVARCHAR(100)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX)
    SET @sql = 'SELECT * FROM ' + QUOTENAME(@nombre_tabla) + ';'
    
    EXEC sp_executesql @sql
END

CREATE PROCEDURE SP_CONSULTAR_TABLA_Clientes
AS
BEGIN
    SELECT * FROM Clientes;
END


CREATE PROCEDURE SP_CONSULTAR_TABLA_Articulos
AS
BEGIN
    SELECT * FROM ARTICULOS;
END

CREATE PROCEDURE SP_INSERTAR_Facturas
@cod_cliente INT,
@id_forma_pago INT,
@nro_factura INT OUTPUT
AS
BEGIN
    INSERT INTO dbo.FACTURACIONES(cod_cliente, fecha, id_forma_pago) VALUES (@cod_cliente, GETDATE(), @id_forma_pago);
	SET @nro_factura = SCOPE_IDENTITY();
END


CREATE PROCEDURE SP_INSERTAR_Detalle
@nro_factura INT,
@id_articulo INT,
@cantidad INT,
@pre_unitario MONEY
AS
BEGIN
	INSERT INTO dbo.DETALLES_FACTURA(nro_factura, id_articulo, cantidad, pre_unitario) 
	VALUES (@nro_factura, @id_articulo, @cantidad, @pre_unitario)
END

