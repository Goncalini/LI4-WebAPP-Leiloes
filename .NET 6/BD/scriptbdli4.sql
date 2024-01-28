USE [master]
GO
/****** Object:  Database [LI4DB]    Script Date: 26/01/2024 16:51:14 ******/
CREATE DATABASE [LI4DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LI4DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LI4DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LI4DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\LI4DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LI4DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LI4DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LI4DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LI4DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LI4DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LI4DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LI4DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LI4DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LI4DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LI4DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LI4DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LI4DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LI4DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LI4DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LI4DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LI4DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LI4DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LI4DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LI4DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LI4DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LI4DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LI4DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LI4DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LI4DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LI4DB] SET RECOVERY FULL 
GO
ALTER DATABASE [LI4DB] SET  MULTI_USER 
GO
ALTER DATABASE [LI4DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LI4DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LI4DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LI4DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LI4DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LI4DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'LI4DB', N'ON'
GO
ALTER DATABASE [LI4DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [LI4DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LI4DB]
GO
/****** Object:  Table [dbo].[Avaliação]    Script Date: 26/01/2024 16:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avaliação](
	[AvaliaçãoID] [int] NOT NULL,
	[UsernameClient] [varchar](50) NOT NULL,
	[UsernameUser] [varchar](50) NOT NULL,
	[Avaliação] [int] NOT NULL,
	[Comentario] [text] NULL,
 CONSTRAINT [PK_Avaliação] PRIMARY KEY CLUSTERED 
(
	[AvaliaçãoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carregamentos]    Script Date: 26/01/2024 16:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carregamentos](
	[Username] [varchar](50) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Valor] [float] NOT NULL,
	[IDCarregamento] [int] NOT NULL,
 CONSTRAINT [PK_Carregamentos] PRIMARY KEY CLUSTERED 
(
	[IDCarregamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 26/01/2024 16:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID] [int] NOT NULL,
	[Nome] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foto do produto]    Script Date: 26/01/2024 16:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foto do produto](
	[IDLeilão] [int] NOT NULL,
	[Foto] [image] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leilão]    Script Date: 26/01/2024 16:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leilão](
	[LeilãoID] [int] NOT NULL,
	[Tipo do Leilão] [varchar](10) NOT NULL,
	[Estado] [varchar](10) NOT NULL,
	[Nome do produto] [varchar](50) NOT NULL,
	[Categoria do produto] [int] NOT NULL,
	[Marca do Produto] [varbinary](20) NOT NULL,
	[Username do Vendedor] [varchar](50) NOT NULL,
	[Descrição] [text] NOT NULL,
	[TempoLimite] [time](7) NOT NULL,
	[Valor inicial] [float] NOT NULL,
	[Data de termino] [datetime] NOT NULL,
 CONSTRAINT [PK_Leilão] PRIMARY KEY CLUSTERED 
(
	[LeilãoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Licitação]    Script Date: 26/01/2024 16:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licitação](
	[LicitaçãoID] [int] NOT NULL,
	[Tempo] [datetime] NOT NULL,
	[Valor] [float] NOT NULL,
	[UserUsername] [varchar](50) NOT NULL,
	[IDLeilão] [int] NOT NULL,
 CONSTRAINT [PK_Licitação] PRIMARY KEY CLUSTERED 
(
	[LicitaçãoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizador]    Script Date: 26/01/2024 16:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizador](
	[Username] [varchar](50) NOT NULL,
	[Primeiro Nome] [varchar](50) NOT NULL,
	[Segundo Nome] [varchar](50) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Contacto Telefónico] [varchar](9) NOT NULL,
	[Morada] [varchar](50) NOT NULL,
	[Saldo] [float] NOT NULL,
 CONSTRAINT [PK_Utilizador] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Avaliação]  WITH CHECK ADD  CONSTRAINT [FK_Avaliação_Utilizador] FOREIGN KEY([UsernameClient])
REFERENCES [dbo].[Utilizador] ([Username])
GO
ALTER TABLE [dbo].[Avaliação] CHECK CONSTRAINT [FK_Avaliação_Utilizador]
GO
ALTER TABLE [dbo].[Avaliação]  WITH CHECK ADD  CONSTRAINT [FK_Avaliação_Utilizador1] FOREIGN KEY([UsernameUser])
REFERENCES [dbo].[Utilizador] ([Username])
GO
ALTER TABLE [dbo].[Avaliação] CHECK CONSTRAINT [FK_Avaliação_Utilizador1]
GO
ALTER TABLE [dbo].[Carregamentos]  WITH CHECK ADD  CONSTRAINT [FK_Carregamentos_Utilizador] FOREIGN KEY([Username])
REFERENCES [dbo].[Utilizador] ([Username])
GO
ALTER TABLE [dbo].[Carregamentos] CHECK CONSTRAINT [FK_Carregamentos_Utilizador]
GO
ALTER TABLE [dbo].[Foto do produto]  WITH CHECK ADD  CONSTRAINT [FK_Foto do produto_Leilão] FOREIGN KEY([IDLeilão])
REFERENCES [dbo].[Leilão] ([LeilãoID])
GO
ALTER TABLE [dbo].[Foto do produto] CHECK CONSTRAINT [FK_Foto do produto_Leilão]
GO
ALTER TABLE [dbo].[Leilão]  WITH CHECK ADD  CONSTRAINT [FK_Leilão_Categoria] FOREIGN KEY([Categoria do produto])
REFERENCES [dbo].[Categoria] ([ID])
GO
ALTER TABLE [dbo].[Leilão] CHECK CONSTRAINT [FK_Leilão_Categoria]
GO
ALTER TABLE [dbo].[Licitação]  WITH CHECK ADD  CONSTRAINT [FK_Licitação_Leilão] FOREIGN KEY([IDLeilão])
REFERENCES [dbo].[Leilão] ([LeilãoID])
GO
ALTER TABLE [dbo].[Licitação] CHECK CONSTRAINT [FK_Licitação_Leilão]
GO
ALTER TABLE [dbo].[Licitação]  WITH CHECK ADD  CONSTRAINT [FK_Licitação_Utilizador] FOREIGN KEY([UserUsername])
REFERENCES [dbo].[Utilizador] ([Username])
GO
ALTER TABLE [dbo].[Licitação] CHECK CONSTRAINT [FK_Licitação_Utilizador]
GO
USE [master]
GO
ALTER DATABASE [LI4DB] SET  READ_WRITE 
GO
