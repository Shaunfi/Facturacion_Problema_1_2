USE [master]
GO
/****** Object:  Database [FACTURACIONES_1_2]    Script Date: 25/9/2023 00:36:46 ******/
CREATE DATABASE [FACTURACIONES_1_2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FACTURACIONES_1_2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FACTURACIONES_1_2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FACTURACIONES_1_2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\FACTURACIONES_1_2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FACTURACIONES_1_2] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FACTURACIONES_1_2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FACTURACIONES_1_2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET ARITHABORT OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET  MULTI_USER 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FACTURACIONES_1_2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FACTURACIONES_1_2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FACTURACIONES_1_2] SET QUERY_STORE = ON
GO
ALTER DATABASE [FACTURACIONES_1_2] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FACTURACIONES_1_2]
GO
/****** Object:  Table [dbo].[ARTICULOS]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ARTICULOS](
	[id_articulo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[pre_unitario] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTES](
	[cod_cliente] [int] IDENTITY(1,1) NOT NULL,
	[ape_cliente] [varchar](100) NULL,
	[nom_cliente] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[cod_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLES_FACTURA]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLES_FACTURA](
	[nro_factura] [int] NOT NULL,
	[id_articulo] [int] NOT NULL,
	[cantidad] [int] NULL,
	[pre_unitario] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[nro_factura] ASC,
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FACTURACIONES]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACTURACIONES](
	[nro_factura] [int] IDENTITY(1,1) NOT NULL,
	[cod_cliente] [int] NULL,
	[fecha] [datetime] NULL,
	[id_forma_pago] [int] NULL,
	[fecha_baja] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[nro_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FORMAS_PAGO]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FORMAS_PAGO](
	[id_forma_pago] [int] IDENTITY(1,1) NOT NULL,
	[forma_pago] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DETALLES_FACTURA]  WITH CHECK ADD FOREIGN KEY([id_articulo])
REFERENCES [dbo].[ARTICULOS] ([id_articulo])
GO
ALTER TABLE [dbo].[DETALLES_FACTURA]  WITH CHECK ADD FOREIGN KEY([nro_factura])
REFERENCES [dbo].[FACTURACIONES] ([nro_factura])
GO
ALTER TABLE [dbo].[FACTURACIONES]  WITH CHECK ADD FOREIGN KEY([cod_cliente])
REFERENCES [dbo].[CLIENTES] ([cod_cliente])
GO
ALTER TABLE [dbo].[FACTURACIONES]  WITH CHECK ADD FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[FORMAS_PAGO] ([id_forma_pago])
GO
/****** Object:  StoredProcedure [dbo].[SP_BAJAR_FACTURA]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BAJAR_FACTURA]
@nro_factura INT
AS
BEGIN
	UPDATE FACTURACIONES
	SET fecha_baja = GETDATE()
	WHERE nro_factura = @nro_factura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TABLA]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_TABLA]
    @nombre_tabla NVARCHAR(100)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX)
    SET @sql = 'SELECT * FROM ' + QUOTENAME(@nombre_tabla) + ';'
    
    EXEC sp_executesql @sql
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TABLA_Articulos]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_TABLA_Articulos]
AS
BEGIN
    SELECT * FROM ARTICULOS
	ORDER BY 2;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TABLA_Clientes]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_TABLA_Clientes]
AS
BEGIN
    SELECT *, ape_cliente + ', ' + nom_cliente 'nombre_completo' FROM Clientes
	ORDER BY 2;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TABLA_Facturas]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_TABLA_Facturas]
@cod_cliente INT,
@fecha DATE
AS
BEGIN
    SELECT * FROM FACTURACIONES
	WHERE cod_cliente = @cod_cliente 
	  AND CAST(fecha AS DATE) = @fecha
	  AND fecha_baja IS NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_TABLA_FormasPago]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_TABLA_FormasPago]
AS
BEGIN
    SELECT * FROM FORMAS_PAGO
	ORDER BY 2;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ARTICULO]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_ARTICULO]
@descripcion VARCHAR(100),
@pre_unitario MONEY
AS
BEGIN
	INSERT INTO dbo.ARTICULOS(descripcion, pre_unitario) 
	VALUES (@descripcion, @pre_unitario)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_CLIENTE]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_CLIENTE]
@apellido VARCHAR(100),
@nombre VARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.CLIENTES(ape_cliente, nom_cliente) 
	VALUES (@apellido, @nombre)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE]
@nro_factura INT,
@id_articulo INT,
@cantidad INT,
@pre_unitario MONEY
AS
BEGIN
	INSERT INTO dbo.DETALLES_FACTURA(nro_factura, id_articulo, cantidad, pre_unitario) 
	VALUES (@nro_factura, @id_articulo, @cantidad, @pre_unitario)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_Facturas]    Script Date: 25/9/2023 00:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_Facturas]
@cod_cliente INT,
@id_forma_pago INT,
@nro_factura INT OUTPUT
AS
BEGIN
    INSERT INTO dbo.FACTURACIONES(cod_cliente, fecha, id_forma_pago) VALUES (@cod_cliente, GETDATE(), @id_forma_pago);
	SET @nro_factura = SCOPE_IDENTITY();
END
GO
USE [master]
GO
ALTER DATABASE [FACTURACIONES_1_2] SET  READ_WRITE 
GO
