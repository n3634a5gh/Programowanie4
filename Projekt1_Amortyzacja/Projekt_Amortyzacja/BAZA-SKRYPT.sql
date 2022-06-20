USE [master]
GO
/****** Object:  Database [Projekt_Amortyzacja]    Script Date: 20.06.2022 21:58:35 ******/
CREATE DATABASE [Projekt_Amortyzacja]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Projekt_Amortyzacja', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Projekt_Amortyzacja.mdf' , SIZE = 10240KB , MAXSIZE = 52428800KB , FILEGROWTH = 10240KB )
 LOG ON 
( NAME = N'Projekt_Amortyzacja_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Projekt_Amortyzacja_log.ldf' , SIZE = 5120KB , MAXSIZE = 26214400KB , FILEGROWTH = 10240KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Projekt_Amortyzacja] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Projekt_Amortyzacja].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Projekt_Amortyzacja] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET ARITHABORT OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET  MULTI_USER 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Projekt_Amortyzacja] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Projekt_Amortyzacja] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Projekt_Amortyzacja] SET QUERY_STORE = OFF
GO
USE [Projekt_Amortyzacja]
GO
/****** Object:  Schema [K_UR]    Script Date: 20.06.2022 21:58:36 ******/
CREATE SCHEMA [K_UR]
GO
/****** Object:  Schema [Ksiegowosc]    Script Date: 20.06.2022 21:58:36 ******/
CREATE SCHEMA [Ksiegowosc]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20.06.2022 21:58:36 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [K_UR].[Srodek_trwaly]    Script Date: 20.06.2022 21:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [K_UR].[Srodek_trwaly](
	[Nr_srodka_trwalego] [int] IDENTITY(1,1) NOT NULL,
	[Id_klasy] [int] NOT NULL,
	[Id_wytworcy] [int] NULL,
	[Data_przyjecia] [date] NOT NULL,
	[Data_zakupu] [date] NOT NULL,
	[Lokalizacja] [char](32) NULL,
	[Aktywny] [bit] NOT NULL,
	[Amortyzowalny] [bit] NOT NULL,
	[Opis] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Nr_srodka_trwalego] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [K_UR].[Wartosc_srodka_trwalego]    Script Date: 20.06.2022 21:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [K_UR].[Wartosc_srodka_trwalego](
	[Id_wartosci] [int] IDENTITY(1,1) NOT NULL,
	[Nr_srodka_trwalego] [int] NOT NULL,
	[Wartosc] [money] NOT NULL,
	[Data_aktualizacji] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_wartosci] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [K_UR].[Wytworca]    Script Date: 20.06.2022 21:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [K_UR].[Wytworca](
	[Id_wytworcy] [int] IDENTITY(1,1) NOT NULL,
	[Nazwa] [nvarchar](32) NOT NULL,
	[Email] [nvarchar](32) NOT NULL,
	[NIP] [nvarchar](10) NULL,
	[Telefon] [nvarchar](16) NULL,
	[Kraj] [nvarchar](32) NULL,
	[Miejscowosc] [nvarchar](32) NULL,
	[Ulica] [nvarchar](32) NULL,
	[Nr_lokalu] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_wytworcy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Ksiegowosc].[Amortyzacja]    Script Date: 20.06.2022 21:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ksiegowosc].[Amortyzacja](
	[Id_amortyzacji] [int] IDENTITY(1,1) NOT NULL,
	[Id_planu] [int] NOT NULL,
	[Kwota_rozliczona] [money] NOT NULL,
	[Wartosc_rozliczenia] [money] NOT NULL,
	[Zakonczona] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_amortyzacji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Ksiegowosc].[Klasyfikacja]    Script Date: 20.06.2022 21:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ksiegowosc].[Klasyfikacja](
	[Id_klasy] [int] IDENTITY(1,1) NOT NULL,
	[Nr_grupy] [smallint] NOT NULL,
	[Nr_podgrupy] [smallint] NOT NULL,
	[Rodzaj] [smallint] NOT NULL,
	[Stawka_amortyzacji] [real] NOT NULL,
	[Opis] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_klasy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Ksiegowosc].[Plan_amortyzacji]    Script Date: 20.06.2022 21:58:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Ksiegowosc].[Plan_amortyzacji](
	[Id_planu] [int] IDENTITY(1,1) NOT NULL,
	[Id_wartosci] [int] NOT NULL,
	[Wartosc_amortyzacji] [money] NOT NULL,
	[Data_wprowadzenia] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_planu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [K_UR].[Srodek_trwaly]  WITH CHECK ADD  CONSTRAINT [rST_Klasa] FOREIGN KEY([Id_klasy])
REFERENCES [Ksiegowosc].[Klasyfikacja] ([Id_klasy])
GO
ALTER TABLE [K_UR].[Srodek_trwaly] CHECK CONSTRAINT [rST_Klasa]
GO
ALTER TABLE [K_UR].[Srodek_trwaly]  WITH CHECK ADD  CONSTRAINT [rST_Wytworca] FOREIGN KEY([Id_wytworcy])
REFERENCES [K_UR].[Wytworca] ([Id_wytworcy])
GO
ALTER TABLE [K_UR].[Srodek_trwaly] CHECK CONSTRAINT [rST_Wytworca]
GO
ALTER TABLE [K_UR].[Wartosc_srodka_trwalego]  WITH CHECK ADD  CONSTRAINT [rWartosc_ST] FOREIGN KEY([Nr_srodka_trwalego])
REFERENCES [K_UR].[Srodek_trwaly] ([Nr_srodka_trwalego])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [K_UR].[Wartosc_srodka_trwalego] CHECK CONSTRAINT [rWartosc_ST]
GO
ALTER TABLE [Ksiegowosc].[Amortyzacja]  WITH CHECK ADD  CONSTRAINT [rAmortyzacja_Plan] FOREIGN KEY([Id_planu])
REFERENCES [Ksiegowosc].[Plan_amortyzacji] ([Id_planu])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Ksiegowosc].[Amortyzacja] CHECK CONSTRAINT [rAmortyzacja_Plan]
GO
ALTER TABLE [Ksiegowosc].[Plan_amortyzacji]  WITH CHECK ADD  CONSTRAINT [rPlan_Wartosc] FOREIGN KEY([Id_wartosci])
REFERENCES [K_UR].[Wartosc_srodka_trwalego] ([Id_wartosci])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Ksiegowosc].[Plan_amortyzacji] CHECK CONSTRAINT [rPlan_Wartosc]
GO
ALTER TABLE [K_UR].[Wartosc_srodka_trwalego]  WITH CHECK ADD  CONSTRAINT [checkWartosc_większa_od_0] CHECK  (([Wartosc]>(0)))
GO
ALTER TABLE [K_UR].[Wartosc_srodka_trwalego] CHECK CONSTRAINT [checkWartosc_większa_od_0]
GO
ALTER TABLE [Ksiegowosc].[Amortyzacja]  WITH CHECK ADD  CONSTRAINT [checkkwoty_większe_od_0] CHECK  (([Kwota_rozliczona]>(0) AND [Wartosc_rozliczenia]>(0)))
GO
ALTER TABLE [Ksiegowosc].[Amortyzacja] CHECK CONSTRAINT [checkkwoty_większe_od_0]
GO
ALTER TABLE [Ksiegowosc].[Klasyfikacja]  WITH CHECK ADD  CONSTRAINT [checkStawka_czyzakres] CHECK  (([Stawka_amortyzacji]>(0) AND [Stawka_amortyzacji]<(100)))
GO
ALTER TABLE [Ksiegowosc].[Klasyfikacja] CHECK CONSTRAINT [checkStawka_czyzakres]
GO
ALTER TABLE [Ksiegowosc].[Plan_amortyzacji]  WITH CHECK ADD  CONSTRAINT [checkWartoscAmortyzacji_większa_od_0] CHECK  (([Wartosc_amortyzacji]>(0)))
GO
ALTER TABLE [Ksiegowosc].[Plan_amortyzacji] CHECK CONSTRAINT [checkWartoscAmortyzacji_większa_od_0]
GO
USE [master]
GO
ALTER DATABASE [Projekt_Amortyzacja] SET  READ_WRITE 
GO
