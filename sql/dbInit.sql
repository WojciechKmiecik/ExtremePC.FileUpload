USE [master]
GO
/****** Object:  Database [ExtremePC.FileUploadDb]    Script Date: 11/02/2019 04:22:21 ******/
CREATE DATABASE [ExtremePC.FileUploadDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExtremePC.FileUploadDb', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ExtremePC.FileUploadDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExtremePC.FileUploadDb_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ExtremePC.FileUploadDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExtremePC.FileUploadDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET  MULTI_USER 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET QUERY_STORE = OFF
GO
USE [ExtremePC.FileUploadDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/02/2019 04:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColorCodes]    Script Date: 11/02/2019 04:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorCodes](
	[ColorCodeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ColorCodes] PRIMARY KEY CLUSTERED 
(
	[ColorCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 11/02/2019 04:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[ColorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/02/2019 04:22:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](max) NULL,
	[ArtikelCode] [nvarchar](max) NULL,
	[ColorCodeId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DiscountPrice] [decimal](18, 2) NOT NULL,
	[DeliveredInMin] [int] NOT NULL,
	[DeliveredInMax] [int] NOT NULL,
	[Q1] [nvarchar](max) NULL,
	[Size] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190211012941_InitialCreate', N'2.1.4-rtm-31024')
SET IDENTITY_INSERT [dbo].[ColorCodes] ON 

INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (1, N'broek')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (2, N'Kniebroek Jorge')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (3, N'Jeans')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (4, N'Jeans Willy')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (5, N'Kniebroek Maria')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (6, N'Top Wilma')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (7, N'Top Annie')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (8, N'Top Bill')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (9, N'Steve Irwin')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (10, N'Jeans Willy Boys')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (11, N'Short Billy & Bobble')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (12, N'jacket')
INSERT [dbo].[ColorCodes] ([ColorCodeId], [Name]) VALUES (13, N'test')
SET IDENTITY_INSERT [dbo].[ColorCodes] OFF
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ColorId], [Name]) VALUES (1, N'grijs')
INSERT [dbo].[Colors] ([ColorId], [Name]) VALUES (2, N'groen')
INSERT [dbo].[Colors] ([ColorId], [Name]) VALUES (3, N'wit')
INSERT [dbo].[Colors] ([ColorId], [Name]) VALUES (4, N'zwart')
INSERT [dbo].[Colors] ([ColorId], [Name]) VALUES (5, N'bruin')
INSERT [dbo].[Colors] ([ColorId], [Name]) VALUES (6, N'beige')
INSERT [dbo].[Colors] ([ColorId], [Name]) VALUES (7, N'rood')
INSERT [dbo].[Colors] ([ColorId], [Name]) VALUES (8, N'blauw')
SET IDENTITY_INSERT [dbo].[Colors] OFF
/****** Object:  Index [IX_Products_ColorCodeId]    Script Date: 11/02/2019 04:22:22 ******/
CREATE NONCLUSTERED INDEX [IX_Products_ColorCodeId] ON [dbo].[Products]
(
	[ColorCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_ColorId]    Script Date: 11/02/2019 04:22:22 ******/
CREATE NONCLUSTERED INDEX [IX_Products_ColorId] ON [dbo].[Products]
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ColorCodes_ColorCodeId] FOREIGN KEY([ColorCodeId])
REFERENCES [dbo].[ColorCodes] ([ColorCodeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ColorCodes_ColorCodeId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Colors_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([ColorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Colors_ColorId]
GO
USE [master]
GO
ALTER DATABASE [ExtremePC.FileUploadDb] SET  READ_WRITE 
GO
