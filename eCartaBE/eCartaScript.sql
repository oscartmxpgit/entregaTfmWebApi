USE [master]
GO
/****** Object:  Database [eCarta]    Script Date: 6/10/2022 12:24:52 PM ******/
CREATE DATABASE [eCarta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eCarta', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eCarta.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eCarta_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\eCarta_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [eCarta] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eCarta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eCarta] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eCarta] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eCarta] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eCarta] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eCarta] SET ARITHABORT OFF 
GO
ALTER DATABASE [eCarta] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eCarta] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eCarta] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eCarta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eCarta] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eCarta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eCarta] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eCarta] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eCarta] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eCarta] SET  DISABLE_BROKER 
GO
ALTER DATABASE [eCarta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eCarta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eCarta] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eCarta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eCarta] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eCarta] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eCarta] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eCarta] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eCarta] SET  MULTI_USER 
GO
ALTER DATABASE [eCarta] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eCarta] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eCarta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eCarta] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eCarta] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eCarta] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [eCarta] SET QUERY_STORE = OFF
GO
USE [eCarta]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 6/10/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[dni] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](50) NULL,
	[pass] [nvarchar](500) NOT NULL,
	[idNegocio] [int] NOT NULL,
	[email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encargado]    Script Date: 6/10/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encargado](
	[idEncargado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[dni] [nvarchar](50) NOT NULL,
	[pass] [nvarchar](500) NULL,
	[correo] [nvarchar](50) NULL,
	[telefono] [nvarchar](50) NULL,
 CONSTRAINT [PK_Encargado] PRIMARY KEY CLUSTERED 
(
	[idEncargado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvaluacionEmpleado]    Script Date: 6/10/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluacionEmpleado](
	[idEvaluacionEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[idEmpleado] [int] NOT NULL,
	[criterio] [nvarchar](50) NOT NULL,
	[evaluacion] [smallint] NOT NULL,
	[IdNegocio] [int] NOT NULL,
 CONSTRAINT [PK_EvaluacionEmpleado] PRIMARY KEY CLUSTERED 
(
	[idEvaluacionEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insumo]    Script Date: 6/10/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insumo](
	[idInsumo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[stock] [smallint] NOT NULL,
	[idNegocio] [int] NOT NULL,
	[Precio] [float] NULL,
	[estado] [nvarchar](50) NULL,
 CONSTRAINT [PK_Insumo] PRIMARY KEY CLUSTERED 
(
	[idInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesa]    Script Date: 6/10/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesa](
	[idMesa] [int] IDENTITY(1,1) NOT NULL,
	[personas] [smallint] NOT NULL,
	[comentario] [nvarchar](50) NULL,
	[idNegocio] [int] NOT NULL,
	[noMesa] [smallint] NULL,
	[estadoPedido] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mesa] PRIMARY KEY CLUSTERED 
(
	[idMesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Negocio]    Script Date: 6/10/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Negocio](
	[idNegocio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](150) NOT NULL,
	[direccion] [nvarchar](150) NULL,
	[idEncargado] [int] NOT NULL,
	[tipo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Negocio] PRIMARY KEY CLUSTERED 
(
	[idNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperacionesCaja]    Script Date: 6/10/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperacionesCaja](
	[idOperacionesCaja] [int] IDENTITY(1,1) NOT NULL,
	[operacion] [nvarchar](250) NULL,
	[importe] [float] NULL,
	[fechaHora] [datetime] NULL,
	[producto] [nvarchar](500) NULL,
	[idNegocio] [int] NULL,
	[cantidad] [smallint] NULL,
	[tipo] [nvarchar](50) NULL,
	[estado] [nvarchar](50) NULL,
 CONSTRAINT [PK_OperacionesCaja] PRIMARY KEY CLUSTERED 
(
	[idOperacionesCaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plato]    Script Date: 6/10/2022 12:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plato](
	[idPlato] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NULL,
	[precio] [float] NULL,
	[stock] [smallint] NULL,
	[idNegocio] [int] NULL,
	[tipo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Plato] PRIMARY KEY CLUSTERED 
(
	[idPlato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Negocio] FOREIGN KEY([idNegocio])
REFERENCES [dbo].[Negocio] ([idNegocio])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Negocio]
GO
ALTER TABLE [dbo].[EvaluacionEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionEmpleado_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[EvaluacionEmpleado] CHECK CONSTRAINT [FK_EvaluacionEmpleado_Empleado]
GO
ALTER TABLE [dbo].[EvaluacionEmpleado]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionEmpleado_Negocio] FOREIGN KEY([IdNegocio])
REFERENCES [dbo].[Negocio] ([idNegocio])
GO
ALTER TABLE [dbo].[EvaluacionEmpleado] CHECK CONSTRAINT [FK_EvaluacionEmpleado_Negocio]
GO
ALTER TABLE [dbo].[Insumo]  WITH CHECK ADD  CONSTRAINT [FK_Insumo_Negocio] FOREIGN KEY([idNegocio])
REFERENCES [dbo].[Negocio] ([idNegocio])
GO
ALTER TABLE [dbo].[Insumo] CHECK CONSTRAINT [FK_Insumo_Negocio]
GO
ALTER TABLE [dbo].[Mesa]  WITH CHECK ADD  CONSTRAINT [FK_Mesa_Negocio] FOREIGN KEY([idNegocio])
REFERENCES [dbo].[Negocio] ([idNegocio])
GO
ALTER TABLE [dbo].[Mesa] CHECK CONSTRAINT [FK_Mesa_Negocio]
GO
ALTER TABLE [dbo].[Negocio]  WITH CHECK ADD  CONSTRAINT [FK_Negocio_Encargado] FOREIGN KEY([idEncargado])
REFERENCES [dbo].[Encargado] ([idEncargado])
GO
ALTER TABLE [dbo].[Negocio] CHECK CONSTRAINT [FK_Negocio_Encargado]
GO
ALTER TABLE [dbo].[OperacionesCaja]  WITH CHECK ADD  CONSTRAINT [FK_OperacionesCaja_Negocio] FOREIGN KEY([idNegocio])
REFERENCES [dbo].[Negocio] ([idNegocio])
GO
ALTER TABLE [dbo].[OperacionesCaja] CHECK CONSTRAINT [FK_OperacionesCaja_Negocio]
GO
ALTER TABLE [dbo].[Plato]  WITH CHECK ADD  CONSTRAINT [FK_Plato_Negocio] FOREIGN KEY([idNegocio])
REFERENCES [dbo].[Negocio] ([idNegocio])
GO
ALTER TABLE [dbo].[Plato] CHECK CONSTRAINT [FK_Plato_Negocio]
GO
USE [master]
GO
ALTER DATABASE [eCarta] SET  READ_WRITE 
GO
