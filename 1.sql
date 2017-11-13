USE [master]
GO
/****** Object:  Database [bdbingo]    Script Date: 13-11-2017 0:27:55 ******/
CREATE DATABASE [bdbingo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bdbingo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SS2014\MSSQL\DATA\bdbingo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bdbingo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SS2014\MSSQL\DATA\bdbingo_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bdbingo] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bdbingo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bdbingo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bdbingo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bdbingo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bdbingo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bdbingo] SET ARITHABORT OFF 
GO
ALTER DATABASE [bdbingo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bdbingo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bdbingo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bdbingo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bdbingo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bdbingo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bdbingo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bdbingo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bdbingo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bdbingo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bdbingo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bdbingo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bdbingo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bdbingo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bdbingo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bdbingo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bdbingo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bdbingo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bdbingo] SET  MULTI_USER 
GO
ALTER DATABASE [bdbingo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bdbingo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bdbingo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bdbingo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [bdbingo] SET DELAYED_DURABILITY = DISABLED 
GO
USE [bdbingo]
GO
/****** Object:  Table [dbo].[bingoJuego]    Script Date: 13-11-2017 0:27:55 ******/
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
/****** Object:  Table [dbo].[bingoParametro]    Script Date: 13-11-2017 0:27:55 ******/
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
 CONSTRAINT [PK_bingoParametro] PRIMARY KEY CLUSTERED 
(
	[idParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[estadoJuego]    Script Date: 13-11-2017 0:27:55 ******/
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
/****** Object:  Table [dbo].[tbltoken]    Script Date: 13-11-2017 0:27:55 ******/
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
/****** Object:  Table [dbo].[tblusuario]    Script Date: 13-11-2017 0:27:55 ******/
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

INSERT [dbo].[bingoJuego] ([idbingo], [idlocal], [inicioJuego], [finjuego], [ultimonumero], [premio], [esperaNumeroSeg], [B1], [B2], [B3], [B4], [B5], [B6], [B7], [B8], [B9], [B10], [B11], [B12], [B13], [B14], [B15], [I16], [I17], [I18], [I19], [I20], [I21], [I22], [I23], [I24], [I25], [I26], [I27], [I28], [I29], [I30], [N31], [N32], [N33], [N34], [N35], [N36], [N37], [N38], [N39], [N40], [N41], [N42], [N43], [N44], [N45], [G46], [G47], [G48], [G49], [G50], [G51], [G52], [G53], [G54], [G55], [G56], [G57], [G58], [G59], [G60], [O61], [O62], [O63], [O64], [O65], [O66], [O67], [O68], [O69], [O70], [O71], [O72], [O73], [O74], [O75]) VALUES (1, 1, NULL, NULL, N'I-26', NULL, NULL, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[bingoJuego] OFF
SET IDENTITY_INSERT [dbo].[bingoParametro] ON 

INSERT [dbo].[bingoParametro] ([idParametro], [idLocal], [idEstadoJuego], [videoActivo], [esperaNumeroSeg], [premioDefecto], [juegoAutomatico], [juegoAutomaticoCadaSeg], [urlVideo], [MensajeVideo]) VALUES (1, 1, 2, 1, 3000, 5000, 0, 0, N'https://www.youtube.com/embed/sq6oc066w14', N'Un mensaje de prueba')
SET IDENTITY_INSERT [dbo].[bingoParametro] OFF
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
ALTER DATABASE [bdbingo] SET  READ_WRITE 
GO
