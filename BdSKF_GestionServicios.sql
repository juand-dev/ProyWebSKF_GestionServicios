USE [master]
GO
/****** Object:  Database [BdSKF_GestionServicios]    Script Date: 27/09/2019 12:54:57 p.m. ******/
CREATE DATABASE [BdSKF_GestionServicios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BdSKF_GestionServicios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL\MSSQL\DATA\BdSKF_GestionServicios.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BdSKF_GestionServicios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL\MSSQL\DATA\BdSKF_GestionServicios_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BdSKF_GestionServicios] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BdSKF_GestionServicios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BdSKF_GestionServicios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET ARITHABORT OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET  MULTI_USER 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BdSKF_GestionServicios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BdSKF_GestionServicios] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BdSKF_GestionServicios]
GO
/****** Object:  Table [dbo].[CARGOS]    Script Date: 27/09/2019 12:54:58 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CARGOS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[descripcion] [varchar](150) NULL,
 CONSTRAINT [PK_CARGOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COMPRADORES]    Script Date: 27/09/2019 12:54:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPRADORES](
	[persona_id] [int] NOT NULL,
	[enmail] [varchar](50) NULL,
	[sexo] [varchar](10) NULL,
 CONSTRAINT [PK_COMPRADORES] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DETALLEPAQUETES]    Script Date: 27/09/2019 12:54:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLEPAQUETES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[paquete_id] [int] NOT NULL,
	[servicio_id] [int] NOT NULL,
 CONSTRAINT [PK_DETALLESERVICIOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[paquete_id] ASC,
	[servicio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EMPLEADOS]    Script Date: 27/09/2019 12:54:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLEADOS](
	[persona_id] [int] NOT NULL,
	[cargo_id] [int] NOT NULL,
	[fechaIngreso] [date] NULL,
	[fechaCese] [date] NULL,
 CONSTRAINT [PK_EMPLEADOS] PRIMARY KEY CLUSTERED 
(
	[persona_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PAQUETES]    Script Date: 27/09/2019 12:54:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAQUETES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](150) NULL,
	[descripcion] [nvarchar](250) NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_PAQUETES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERSONAS]    Script Date: 27/09/2019 12:54:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PERSONAS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[tipoDocumento_id] [int] NOT NULL,
	[numeroDocumento] [varchar](20) NULL,
	[direccion] [varchar](250) NULL,
	[fechaNacimiento] [date] NULL,
	[celular] [varchar](12) NULL,
	[usuario] [varchar](20) NULL,
	[contrasena] [varchar](20) NULL,
 CONSTRAINT [PK_PERSONAS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SERVICIOS]    Script Date: 27/09/2019 12:54:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SERVICIOS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](150) NULL,
	[descripcion] [varchar](250) NULL,
	[tipoServicio_id] [int] NOT NULL,
	[costo] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SERVICIOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TIPODOCUMENTOS]    Script Date: 27/09/2019 12:54:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIPODOCUMENTOS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcionLarga] [varchar](50) NULL,
	[descripcionCorta] [varchar](20) NULL,
	[longitud] [int] NULL,
 CONSTRAINT [PK_TIPODOCUMENTOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TIPOSERVICIOS]    Script Date: 27/09/2019 12:54:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TIPOSERVICIOS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[acronimo] [varchar](20) NULL,
	[descripcion] [varchar](150) NULL,
 CONSTRAINT [PK_TIPOSERVICIOS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[COMPRADORES]  WITH CHECK ADD  CONSTRAINT [FK_COMPRADORES_PERSONAS] FOREIGN KEY([persona_id])
REFERENCES [dbo].[PERSONAS] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[COMPRADORES] CHECK CONSTRAINT [FK_COMPRADORES_PERSONAS]
GO
ALTER TABLE [dbo].[EMPLEADOS]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADOS_CARGOS] FOREIGN KEY([cargo_id])
REFERENCES [dbo].[CARGOS] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[EMPLEADOS] CHECK CONSTRAINT [FK_EMPLEADOS_CARGOS]
GO
ALTER TABLE [dbo].[EMPLEADOS]  WITH CHECK ADD  CONSTRAINT [FK_EMPLEADOS_PERSONAS] FOREIGN KEY([persona_id])
REFERENCES [dbo].[PERSONAS] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EMPLEADOS] CHECK CONSTRAINT [FK_EMPLEADOS_PERSONAS]
GO
ALTER TABLE [dbo].[PERSONAS]  WITH CHECK ADD  CONSTRAINT [FK_PERSONAS_TIPODOCUMENTOS] FOREIGN KEY([tipoDocumento_id])
REFERENCES [dbo].[TIPODOCUMENTOS] ([id])
GO
ALTER TABLE [dbo].[PERSONAS] CHECK CONSTRAINT [FK_PERSONAS_TIPODOCUMENTOS]
GO
ALTER TABLE [dbo].[SERVICIOS]  WITH CHECK ADD  CONSTRAINT [FK_SERVICIOS_TIPOSERVICIOS] FOREIGN KEY([tipoServicio_id])
REFERENCES [dbo].[TIPOSERVICIOS] ([id])
GO
ALTER TABLE [dbo].[SERVICIOS] CHECK CONSTRAINT [FK_SERVICIOS_TIPOSERVICIOS]
GO
USE [master]
GO
ALTER DATABASE [BdSKF_GestionServicios] SET  READ_WRITE 
GO
