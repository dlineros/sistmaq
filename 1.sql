USE [bdbingo]
GO
/****** Object:  Table [dbo].[bingoJuego]    Script Date: 08-11-2017 22:41:01 ******/
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
	[estadoJuego] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[bingoParametro]    Script Date: 08-11-2017 22:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bingoParametro](
	[idParametro] [int] IDENTITY(1,1) NOT NULL,
	[idLocal] [int] NOT NULL,
	[esperaNumeroSeg] [int] NOT NULL CONSTRAINT [DF_bingoParametro_esperaNumeroSeg]  DEFAULT ((0)),
	[premioDefecto] [int] NOT NULL CONSTRAINT [DF_bingoParametro_premioDefecto]  DEFAULT ((0)),
	[juegoAutomatico] [bit] NOT NULL CONSTRAINT [DF_bingoParametro_juegoAutomatico]  DEFAULT ((0)),
	[juegoAutomaticoCadaSeg] [int] NOT NULL CONSTRAINT [DF_bingoParametro_juegoAutomaticoCadaSeg]  DEFAULT ((0)),
 CONSTRAINT [PK_bingoParametro] PRIMARY KEY CLUSTERED 
(
	[idParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblusuario]    Script Date: 08-11-2017 22:41:01 ******/
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
