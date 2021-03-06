---DROP AND CREATE DATABASE---
USE [master]
GO

/****** Object:  Database [SportScotlandDev]    Script Date: 08/20/2016 14:14:38 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'SportScotlandDev')
DROP DATABASE [SportScotlandDev]
GO

USE [master]
GO

/****** Object:  Database [SportScotlandDev]    Script Date: 08/20/2016 14:14:38 ******/
CREATE DATABASE [SportScotlandDev] ON  PRIMARY 
( NAME = N'SportScotandDev', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\SportScotandDev.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SportScotandDev_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\SportScotandDev_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [SportScotlandDev] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SportScotlandDev].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [SportScotlandDev] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [SportScotlandDev] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [SportScotlandDev] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [SportScotlandDev] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [SportScotlandDev] SET ARITHABORT OFF 
GO

ALTER DATABASE [SportScotlandDev] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [SportScotlandDev] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [SportScotlandDev] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [SportScotlandDev] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [SportScotlandDev] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [SportScotlandDev] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [SportScotlandDev] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [SportScotlandDev] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [SportScotlandDev] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [SportScotlandDev] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [SportScotlandDev] SET  DISABLE_BROKER 
GO

ALTER DATABASE [SportScotlandDev] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [SportScotlandDev] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [SportScotlandDev] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [SportScotlandDev] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [SportScotlandDev] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [SportScotlandDev] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [SportScotlandDev] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [SportScotlandDev] SET  READ_WRITE 
GO

ALTER DATABASE [SportScotlandDev] SET RECOVERY FULL 
GO

ALTER DATABASE [SportScotlandDev] SET  MULTI_USER 
GO

ALTER DATABASE [SportScotlandDev] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [SportScotlandDev] SET DB_CHAINING OFF 
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------

USE [SportScotlandDev]
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------

/****** Object:  Table [dbo].[Impact]    Script Date: 08/20/2016 14:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Impact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Impact](
	[ImpactId] [int] IDENTITY(1,1) NOT NULL,
	[ImpactName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Impact] PRIMARY KEY CLUSTERED 
(
	[ImpactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Benificiary]    Script Date: 08/20/2016 14:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Benificiary]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Benificiary](
	[BenificiaryId] [int] IDENTITY(1,1) NOT NULL,
	[BenificiaryDescription] [nvarchar](100) NULL,
 CONSTRAINT [PK_Benificiary] PRIMARY KEY CLUSTERED 
(
	[BenificiaryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Benificiary] ON
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 1)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (1, N'Male')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 2)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (2, N'Female')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 3)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (3, N'Under 18s')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 4)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (4, N'Aged 18-64')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 5)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (5, N'Aged 65+')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 6)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (6, N'People with disabilities')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 7)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (7, N'People from minority ethnic communities')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 8)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (8, N'Lesbian, Gay, Bisexual people')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 9)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (9, N'Transgender people')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 10)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (10, N'People from specific religious groups')
END	
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 11)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (11, N'People living in rural communities')
END
IF NOT EXISTS (SELECT * FROM [dbo].[Benificiary] WHERE [BenificiaryId] = 12)
BEGIN
	INSERT [dbo].[Benificiary] ([BenificiaryId], [BenificiaryDescription]) VALUES (12, N'People living in areas of deprivation')
END
SET IDENTITY_INSERT [dbo].[Benificiary] OFF
/****** Object:  Table [dbo].[ImpactRecord]    Script Date: 08/20/2016 14:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ImpactRecord](
	[ImpactRecordId] [int] IDENTITY(1,1) NOT NULL,
	[ImpactId] [int] NULL,
	[Notes] [nvarchar](250) NULL,
	[StartDate] [int] NULL,
	[EndDate] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ImpactRecordId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ImpactRecordBenificiaries]    Script Date: 08/20/2016 14:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImpactRecordBenificiaries]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ImpactRecordBenificiaries](
	[ImpactRecordBenificiariesId] [int] IDENTITY(1,1) NOT NULL,
	[ImpactRecordId] [int] NULL,
	[BenificiaryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ImpactRecordBenificiariesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  ForeignKey [fk_Impact_ImpactId]    Script Date: 08/20/2016 14:08:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Impact_ImpactId]') AND parent_object_id = OBJECT_ID(N'[dbo].[ImpactRecord]'))
ALTER TABLE [dbo].[ImpactRecord]  WITH CHECK ADD  CONSTRAINT [fk_Impact_ImpactId] FOREIGN KEY([ImpactId])
REFERENCES [dbo].[Impact] ([ImpactId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[fk_Impact_ImpactId]') AND parent_object_id = OBJECT_ID(N'[dbo].[ImpactRecord]'))
ALTER TABLE [dbo].[ImpactRecord] CHECK CONSTRAINT [fk_Impact_ImpactId]
GO
/****** Object:  ForeignKey [FK__ImpactRec__Benif__1367E606]    Script Date: 08/20/2016 14:08:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ImpactRec__Benif__1367E606]') AND parent_object_id = OBJECT_ID(N'[dbo].[ImpactRecordBenificiaries]'))
ALTER TABLE [dbo].[ImpactRecordBenificiaries]  WITH CHECK ADD FOREIGN KEY([BenificiaryId])
REFERENCES [dbo].[Benificiary] ([BenificiaryId])
GO
/****** Object:  ForeignKey [FK__ImpactRec__Impac__1273C1CD]    Script Date: 08/20/2016 14:08:27 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ImpactRec__Impac__1273C1CD]') AND parent_object_id = OBJECT_ID(N'[dbo].[ImpactRecordBenificiaries]'))
ALTER TABLE [dbo].[ImpactRecordBenificiaries]  WITH CHECK ADD FOREIGN KEY([ImpactRecordId])
REFERENCES [dbo].[ImpactRecord] ([ImpactRecordId])
GO
