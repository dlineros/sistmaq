USE [master]
GO
/****** Object:  Database [DB_A2DC40_dlineros]    Script Date: 27-11-2017 22:35:48 ******/
CREATE DATABASE [DB_A2DC40_dlineros]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A2DC40_dlineros', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SS2014\MSSQL\DATA\DB_A2DC40_dlineros.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_A2DC40_dlineros_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SS2014\MSSQL\DATA\DB_A2DC40_dlineros_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A2DC40_dlineros].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DB_A2DC40_dlineros]
GO
/****** Object:  User [DB_A2DC40_dlineros_admin]    Script Date: 27-11-2017 22:35:49 ******/
CREATE USER [DB_A2DC40_dlineros_admin] FOR LOGIN [DB_A2DC40_dlineros_admin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [DB_A2DC40_dlineros_admin]
GO
/****** Object:  Table [dbo].[bingoJuego]    Script Date: 27-11-2017 22:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bingoJuego](
	[idbingo] [int] IDENTITY(1,1) NOT NULL,
	[idlocal] [int] NULL,
	[inicioJuego] [datetime] NULL,
	[finjuego] [datetime] NULL,
	[ultimonumero] [varchar](50) NULL,
	[premio] [int] NULL,
	[esperaNumeroSeg] [int] NULL,
	[B1] [bit] NOT NULL CONSTRAINT [DF_bingoJuego_B1]  DEFAULT ((0)),
	[B2] [bit] NOT NULL CONSTRAINT [DF_bingoJuego_B2]  DEFAULT ((0)),
	[B3] [bit] NOT NULL,
	[B4] [bit] NOT NULL,
	[B5] [bit] NOT NULL,
	[B6] [bit] NOT NULL,
	[B7] [bit] NOT NULL,
	[B8] [bit] NOT NULL,
	[B9] [bit] NOT NULL,
	[B10] [bit] NOT NULL,
	[B11] [bit] NOT NULL,
	[B12] [bit] NOT NULL,
	[B13] [bit] NOT NULL,
	[B14] [bit] NOT NULL,
	[B15] [bit] NOT NULL,
	[I16] [bit] NOT NULL,
	[I17] [bit] NOT NULL,
	[I18] [bit] NOT NULL,
	[I19] [bit] NOT NULL,
	[I20] [bit] NOT NULL,
	[I21] [bit] NOT NULL,
	[I22] [bit] NOT NULL,
	[I23] [bit] NOT NULL,
	[I24] [bit] NOT NULL,
	[I25] [bit] NOT NULL,
	[I26] [bit] NOT NULL,
	[I27] [bit] NOT NULL,
	[I28] [bit] NOT NULL,
	[I29] [bit] NOT NULL,
	[I30] [bit] NOT NULL,
	[N31] [bit] NOT NULL,
	[N32] [bit] NOT NULL,
	[N33] [bit] NOT NULL,
	[N34] [bit] NOT NULL,
	[N35] [bit] NOT NULL,
	[N36] [bit] NOT NULL,
	[N37] [bit] NOT NULL,
	[N38] [bit] NOT NULL,
	[N39] [bit] NOT NULL,
	[N40] [bit] NOT NULL,
	[N41] [bit] NOT NULL,
	[N42] [bit] NOT NULL,
	[N43] [bit] NOT NULL,
	[N44] [bit] NOT NULL,
	[N45] [bit] NOT NULL,
	[G46] [bit] NOT NULL,
	[G47] [bit] NOT NULL,
	[G48] [bit] NOT NULL,
	[G49] [bit] NOT NULL,
	[G50] [bit] NOT NULL,
	[G51] [bit] NOT NULL,
	[G52] [bit] NOT NULL,
	[G53] [bit] NOT NULL,
	[G54] [bit] NOT NULL,
	[G55] [bit] NOT NULL,
	[G56] [bit] NOT NULL,
	[G57] [bit] NOT NULL,
	[G58] [bit] NOT NULL,
	[G59] [bit] NOT NULL,
	[G60] [bit] NOT NULL,
	[O61] [bit] NOT NULL,
	[O62] [bit] NOT NULL,
	[O63] [bit] NOT NULL,
	[O64] [bit] NOT NULL,
	[O65] [bit] NOT NULL,
	[O66] [bit] NOT NULL,
	[O67] [bit] NOT NULL,
	[O68] [bit] NOT NULL,
	[O69] [bit] NOT NULL,
	[O70] [bit] NOT NULL,
	[O71] [bit] NOT NULL,
	[O72] [bit] NOT NULL,
	[O73] [bit] NOT NULL,
	[O74] [bit] NOT NULL,
	[O75] [bit] NOT NULL,
 CONSTRAINT [PK_bingoJuego] PRIMARY KEY CLUSTERED 
(
	[idbingo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bingoParametro]    Script Date: 27-11-2017 22:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bingoParametro](
	[idParametro] [int] IDENTITY(1,1) NOT NULL,
	[idLocal] [int] NOT NULL,
	[idEstadoJuego] [int] NOT NULL CONSTRAINT [DF_bingoParametro_idEstadoJuego]  DEFAULT ((2)),
	[videoActivo] [bit] NOT NULL,
	[esperaNumeroSeg] [int] NOT NULL CONSTRAINT [DF_bingoParametro_esperaNumeroSeg]  DEFAULT ((0)),
	[premioDefecto] [int] NOT NULL CONSTRAINT [DF_bingoParametro_premioDefecto]  DEFAULT ((0)),
	[juegoAutomatico] [bit] NOT NULL CONSTRAINT [DF_bingoParametro_juegoAutomatico]  DEFAULT ((0)),
	[juegoAutomaticoCadaSeg] [int] NOT NULL CONSTRAINT [DF_bingoParametro_juegoAutomaticoCadaSeg]  DEFAULT ((0)),
	[urlVideo] [varchar](max) NULL,
	[MensajeVideo] [varchar](max) NULL,
	[ultimaActualizacion] [datetime] NULL,
	[apagarCliente] [bit] NOT NULL CONSTRAINT [DF_bingoParametro_apagarCliente]  DEFAULT ((0)),
	[visualizar] [varchar](50) NULL,
	[urlcliente] [varchar](500) NULL,
 CONSTRAINT [PK_bingoParametro] PRIMARY KEY CLUSTERED 
(
	[idParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[carton]    Script Date: 27-11-2017 22:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carton](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idlocal] [int] NOT NULL,
	[n1] [int] NOT NULL,
	[n2] [int] NOT NULL,
	[n3] [int] NOT NULL,
	[n4] [int] NOT NULL,
	[n5] [int] NOT NULL,
	[n6] [int] NOT NULL,
	[n7] [int] NOT NULL,
	[n8] [int] NOT NULL,
	[n9] [int] NOT NULL,
	[n10] [int] NOT NULL,
	[n11] [int] NOT NULL,
	[n12] [int] NOT NULL,
	[n13] [int] NOT NULL,
	[n14] [int] NOT NULL,
	[n15] [int] NOT NULL,
	[n16] [int] NOT NULL,
	[n17] [int] NOT NULL,
	[n18] [int] NOT NULL,
	[n19] [int] NOT NULL,
	[n20] [int] NOT NULL,
	[n21] [int] NOT NULL,
	[n22] [int] NOT NULL,
	[n23] [int] NOT NULL,
	[n24] [int] NOT NULL,
 CONSTRAINT [PK_carton] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[estadoJuego]    Script Date: 27-11-2017 22:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[estadoJuego](
	[idestado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[descripcion] [varchar](max) NULL,
 CONSTRAINT [PK_estadoJuego] PRIMARY KEY CLUSTERED 
(
	[idestado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbltoken]    Script Date: 27-11-2017 22:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbltoken](
	[idToken] [int] IDENTITY(1,1) NOT NULL,
	[token] [varchar](max) NULL,
	[local] [varchar](200) NULL,
	[usuario] [varchar](200) NULL,
	[idLocal] [int] NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_tbltoken] PRIMARY KEY CLUSTERED 
(
	[idToken] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblusuario]    Script Date: 27-11-2017 22:35:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblusuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[pass] [varchar](50) NULL,
	[idlocal] [int] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[bingoJuego] ON 

INSERT [dbo].[bingoJuego] ([idbingo], [idlocal], [inicioJuego], [finjuego], [ultimonumero], [premio], [esperaNumeroSeg], [B1], [B2], [B3], [B4], [B5], [B6], [B7], [B8], [B9], [B10], [B11], [B12], [B13], [B14], [B15], [I16], [I17], [I18], [I19], [I20], [I21], [I22], [I23], [I24], [I25], [I26], [I27], [I28], [I29], [I30], [N31], [N32], [N33], [N34], [N35], [N36], [N37], [N38], [N39], [N40], [N41], [N42], [N43], [N44], [N45], [G46], [G47], [G48], [G49], [G50], [G51], [G52], [G53], [G54], [G55], [G56], [G57], [G58], [G59], [G60], [O61], [O62], [O63], [O64], [O65], [O66], [O67], [O68], [O69], [O70], [O71], [O72], [O73], [O74], [O75]) VALUES (1, 1, CAST(N'2017-11-24 02:23:33.173' AS DateTime), NULL, N'O-66', 15000, NULL, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[bingoJuego] OFF
SET IDENTITY_INSERT [dbo].[bingoParametro] ON 

INSERT [dbo].[bingoParametro] ([idParametro], [idLocal], [idEstadoJuego], [videoActivo], [esperaNumeroSeg], [premioDefecto], [juegoAutomatico], [juegoAutomaticoCadaSeg], [urlVideo], [MensajeVideo], [ultimaActualizacion], [apagarCliente], [visualizar], [urlcliente]) VALUES (1, 1, 4, 0, 3, 5000, 0, 0, N'https://www.youtube.com/embed/playlist?list=PL6Go6XFhidEAac3TgkP8EfLF1bA1odl4e&autoplay=1', N'Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original.', CAST(N'2017-11-27 22:33:24.020' AS DateTime), 0, N'bingo', N'http://dll.ddns.net:8089/')
SET IDENTITY_INSERT [dbo].[bingoParametro] OFF
SET IDENTITY_INSERT [dbo].[carton] ON 

INSERT [dbo].[carton] ([id], [idlocal], [n1], [n2], [n3], [n4], [n5], [n6], [n7], [n8], [n9], [n10], [n11], [n12], [n13], [n14], [n15], [n16], [n17], [n18], [n19], [n20], [n21], [n22], [n23], [n24]) VALUES (1, 1, 1, 2, 5, 8, 9, 21, 22, 33, 44, 45, 6, 54, 75, 66, 32, 23, 24, 25, 26, 27, 36, 61, 62, 63)
SET IDENTITY_INSERT [dbo].[carton] OFF
SET IDENTITY_INSERT [dbo].[estadoJuego] ON 

INSERT [dbo].[estadoJuego] ([idestado], [nombre], [descripcion]) VALUES (1, N'Juego Finalizado', N'Muestra el resultado del último juego del local')
INSERT [dbo].[estadoJuego] ([idestado], [nombre], [descripcion]) VALUES (2, N'Video', N'Muestra el video')
INSERT [dbo].[estadoJuego] ([idestado], [nombre], [descripcion]) VALUES (3, N'En Juego', N'Existe un juego de Bingo activo en el local')
INSERT [dbo].[estadoJuego] ([idestado], [nombre], [descripcion]) VALUES (4, N'Pausado', N'Se ha pausado el juego')
SET IDENTITY_INSERT [dbo].[estadoJuego] OFF
SET IDENTITY_INSERT [dbo].[tbltoken] ON 

INSERT [dbo].[tbltoken] ([idToken], [token], [local], [usuario], [idLocal], [idUsuario]) VALUES (1, N'xxxxxx', N'local1', N'usuario1', 1, 1)
SET IDENTITY_INSERT [dbo].[tbltoken] OFF
SET IDENTITY_INSERT [dbo].[tblusuario] ON 

INSERT [dbo].[tblusuario] ([idusuario], [usuario], [pass], [idlocal]) VALUES (1, N'dlineros', N'xxxx', 1)
SET IDENTITY_INSERT [dbo].[tblusuario] OFF
ALTER TABLE [dbo].[bingoParametro]  WITH CHECK ADD  CONSTRAINT [FK_bingoParametro_estadoJuego] FOREIGN KEY([idEstadoJuego])
REFERENCES [dbo].[estadoJuego] ([idestado])
GO
ALTER TABLE [dbo].[bingoParametro] CHECK CONSTRAINT [FK_bingoParametro_estadoJuego]
GO
USE [master]
GO
ALTER DATABASE [DB_A2DC40_dlineros] SET  READ_WRITE 
GO
