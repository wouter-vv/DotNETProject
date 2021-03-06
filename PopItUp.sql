USE [master]
GO
/****** Object:  Database [PopItUP]    Script Date: 31/07/2018 22:57:17 ******/
CREATE DATABASE [PopItUP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PopItUP', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQL2018\MSSQL\DATA\PopItUP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PopItUP_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL14.SQL2018\MSSQL\DATA\PopItUP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PopItUP] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PopItUP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PopItUP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PopItUP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PopItUP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PopItUP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PopItUP] SET ARITHABORT OFF 
GO
ALTER DATABASE [PopItUP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PopItUP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PopItUP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PopItUP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PopItUP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PopItUP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PopItUP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PopItUP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PopItUP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PopItUP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PopItUP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PopItUP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PopItUP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PopItUP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PopItUP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PopItUP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PopItUP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PopItUP] SET RECOVERY FULL 
GO
ALTER DATABASE [PopItUP] SET  MULTI_USER 
GO
ALTER DATABASE [PopItUP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PopItUP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PopItUP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PopItUP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PopItUP] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PopItUP', N'ON'
GO
ALTER DATABASE [PopItUP] SET QUERY_STORE = OFF
GO
USE [PopItUP]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [PopItUP]
GO
/****** Object:  Table [dbo].[bars]    Script Date: 31/07/2018 22:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bars](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[street] [varchar](50) NULL,
	[number] [int] NULL,
	[description] [varchar](1000) NULL,
 CONSTRAINT [PK_bars] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comment_event]    Script Date: 31/07/2018 22:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment_event](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](1000) NULL,
	[user_id] [int] NULL,
	[events_id] [int] NULL,
 CONSTRAINT [PK_review_event] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[events]    Script Date: 31/07/2018 22:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[events](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[date] [datetime] NULL,
	[description] [varchar](1000) NULL,
	[genre_id] [int] NULL,
	[bars_id] [int] NULL,
 CONSTRAINT [PK_events] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genres]    Script Date: 31/07/2018 22:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genres](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_genres] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[groups]    Script Date: 31/07/2018 22:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[groups](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_groups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[review_bar]    Script Date: 31/07/2018 22:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[review_bar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rating] [int] NULL,
	[description] [varchar](1000) NULL,
	[bars_id] [int] NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_review_bar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 31/07/2018 22:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](150) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usergroup]    Script Date: 31/07/2018 22:57:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usergroup](
	[user_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
 CONSTRAINT [PK_usergroup] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[group_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bars] ON 

INSERT [dbo].[bars] ([id], [name], [city], [street], [number], [description]) VALUES (1, N'The Village', N'Wachtebeke', N'Peene', 12, N'Gezellige bar op de rand van het heidebos. Hier drink je in het midden van de natuur.')
INSERT [dbo].[bars] ([id], [name], [city], [street], [number], [description]) VALUES (2, N'Vagevuur', N'Lokeren', N'Hoogstraat', 20, N'De bar bevindt zich in een de lagere school van Lokeren. Een zeer authentiek en mooi gebouw in het centrum van lokeren.')
INSERT [dbo].[bars] ([id], [name], [city], [street], [number], [description]) VALUES (3, N'Zomerbar Lokeren', N'Lokeren', N'Durmewegel', 30, N'Een bar in het centrum van lokeren gelegen vlak naast de Durme. Drinken met een mooi uitzicht.')
SET IDENTITY_INSERT [dbo].[bars] OFF
SET IDENTITY_INSERT [dbo].[comment_event] ON 

INSERT [dbo].[comment_event] ([id], [description], [user_id], [events_id]) VALUES (1, N'Tof', 2, 1)
INSERT [dbo].[comment_event] ([id], [description], [user_id], [events_id]) VALUES (2, N'goe', 5, 1)
INSERT [dbo].[comment_event] ([id], [description], [user_id], [events_id]) VALUES (3, N'sterk', 5, 1)
INSERT [dbo].[comment_event] ([id], [description], [user_id], [events_id]) VALUES (5, N'Zal er een bekende rode duivel aanwezig zijn??', 8, 3)
INSERT [dbo].[comment_event] ([id], [description], [user_id], [events_id]) VALUES (6, N'Wij kunnen niets beloven maar we doen ons best!! Misschien komt Leander Dendoncker langs...', 5, 3)
INSERT [dbo].[comment_event] ([id], [description], [user_id], [events_id]) VALUES (7, N'YES!!!!', 8, 3)
INSERT [dbo].[comment_event] ([id], [description], [user_id], [events_id]) VALUES (8, N'Wordt er verwacht voorkennis te hebben?', 8, 1)
INSERT [dbo].[comment_event] ([id], [description], [user_id], [events_id]) VALUES (9, N'De max!! Hoe heb je dat voor mekaar gekregen?', 8, 2)
SET IDENTITY_INSERT [dbo].[comment_event] OFF
SET IDENTITY_INSERT [dbo].[events] ON 

INSERT [dbo].[events] ([id], [name], [date], [description], [genre_id], [bars_id]) VALUES (1, N'Salsalessen', CAST(N'2018-07-22T20:00:00.000' AS DateTime), N'Leer nu salsa op tijdens de salsalessen. Komende 22 juli', 1, 1)
INSERT [dbo].[events] ([id], [name], [date], [description], [genre_id], [bars_id]) VALUES (2, N'Elon Musk komt voorlezen', CAST(N'2018-08-01T20:00:00.000' AS DateTime), N'De alom bekende Elon Musk komt zijn visie op de toekomst voorlezen in Lokeren', 5, 2)
INSERT [dbo].[events] ([id], [name], [date], [description], [genre_id], [bars_id]) VALUES (3, N'Rode Duivels wereldkampioen', CAST(N'2018-08-15T23:00:00.000' AS DateTime), N'Kom een maand na de overwinning nog eens vieren, we kunnen er nooit genoeg van krijgen dat we wereldkampioen zijn geworden', 4, 1)
INSERT [dbo].[events] ([id], [name], [date], [description], [genre_id], [bars_id]) VALUES (4, N'BBQ voor het goede doel', CAST(N'2018-08-12T12:00:00.000' AS DateTime), N'Kom mee eten op de BBQ voor de weeshuizen in afrika', 3, 3)
INSERT [dbo].[events] ([id], [name], [date], [description], [genre_id], [bars_id]) VALUES (5, N'Feestje', CAST(N'2018-08-12T00:00:00.000' AS DateTime), N'R&S Records and Kompass present a rare and unique all night long set of Maceo Plex in sign of his retrospective album that is coming out on the label under his alias Mariel Ito. Founding father Renaat Vandepapeliere will take you on a journey in room two.

Room 1
Maceo Plex - all night long

Room 2
Renaat Vandepapeliere - all night long
Mathieu De Telder', 2, 1)
INSERT [dbo].[events] ([id], [name], [date], [description], [genre_id], [bars_id]) VALUES (6, N'Kompas Day Rave', CAST(N'2018-08-22T00:00:00.000' AS DateTime), N'bla bla', 2, 1)
INSERT [dbo].[events] ([id], [name], [date], [description], [genre_id], [bars_id]) VALUES (7, N'Thé Dansant - Lazy Sunday', CAST(N'2018-09-02T00:00:00.000' AS DateTime), N'For the Thé Dansant summer closing we return to the beautiful green surroundings of the open air swimming pool Wouterbron! 

Theme: Lazy Sunday! 

Dresscode: come straight out of bed to Thé Dansant: keep your pyjama on, take your Onesie, that bath jacket, those slippers, come as The dude (Big Lebowski).. We provide the brunch!

Djs: 
DJ Antonio Pinelas (Giraffe Leuven)
Lola Jones (The Underground, ZODIAK)
Cemode (Deep House Belgium, 12 Inch Lovers)
More TBA', 2, 1)
INSERT [dbo].[events] ([id], [name], [date], [description], [genre_id], [bars_id]) VALUES (8, N'No Man''s World 2018', CAST(N'2018-09-29T00:00:00.000' AS DateTime), N'- MAINSTAGE

The Magician - Mr. Belt & Wezol ????- Alex Germys - Linka&Mondello - DJ Neon - Beaver T & Pinch - Funky Fool b2b DJ Simon B - Anzano - Deejay SvB b2b Melodeep - USX - NvT (contest)

- DEATH VALLEY

Radical Redemption ????- Coone - The Unit - Blasco - War of Noize - STEVE-D - Crazy We R - Nephalem - Trip-Tik - Bilyboy''z - Da Player''z - Dirty Loopers (contest)

- OASIS hosted by KetaLoco

Nico Morano - Mickey - Pierre - Don Cabron - Anais - Maslan - Viotti - Alfonso "Artist Page"', 2, 1)
SET IDENTITY_INSERT [dbo].[events] OFF
INSERT [dbo].[genres] ([id], [name]) VALUES (1, N'Workshop')
INSERT [dbo].[genres] ([id], [name]) VALUES (2, N'Optreden')
INSERT [dbo].[genres] ([id], [name]) VALUES (3, N'Maaltijd')
INSERT [dbo].[genres] ([id], [name]) VALUES (4, N'Fuif')
INSERT [dbo].[genres] ([id], [name]) VALUES (5, N'Lezing')
INSERT [dbo].[groups] ([id], [name]) VALUES (1, N'admin')
INSERT [dbo].[groups] ([id], [name]) VALUES (2, N'user')
SET IDENTITY_INSERT [dbo].[review_bar] ON 

INSERT [dbo].[review_bar] ([id], [rating], [description], [bars_id], [user_id]) VALUES (3, 3, N'ja kan beter', 1, 5)
INSERT [dbo].[review_bar] ([id], [rating], [description], [bars_id], [user_id]) VALUES (9, 4, N'Though this place is really busy, with its’ prime sidewalk seats facing Limmatplatz, a rear garden seating area, and a nice interior space of bar seats and another seating room, I quickly realized why I have not returned here. I had to settle, once again, for a hot tea (5CHF) as this place refuses to offer milk substitute products on menu. The volumes of customers through their doors would certainly justify having milk substitute alternatives on the menu. Also, I did not see a self-service water station, but everyone around me received a glass of water with their hot beverage purchase so I guess you have to be a regular; otherwise, if you don''t ask you don''t receive.

Too bad, as I like the interior design of the place but it just refuses to go or make the extra effort to improve it services. There are far too many other cafes around town that really makes the effort in service and product offerings, so I’ll pass on visiting here again.', 2, 5)
INSERT [dbo].[review_bar] ([id], [rating], [description], [bars_id], [user_id]) VALUES (10, 5, N'Fantastische bar, genieten elke keer.', 3, 7)
INSERT [dbo].[review_bar] ([id], [rating], [description], [bars_id], [user_id]) VALUES (11, 4, N'jaja', 3, 5)
INSERT [dbo].[review_bar] ([id], [rating], [description], [bars_id], [user_id]) VALUES (12, 5, N'amaaaaaaai', 1, 7)
INSERT [dbo].[review_bar] ([id], [rating], [description], [bars_id], [user_id]) VALUES (13, 1, NULL, 2, 7)
INSERT [dbo].[review_bar] ([id], [rating], [description], [bars_id], [user_id]) VALUES (14, 5, N'Aangenaam vertoeven in een prachtige locatie!!', 2, 8)
INSERT [dbo].[review_bar] ([id], [rating], [description], [bars_id], [user_id]) VALUES (15, 3, N'ja kan beter', 3, 8)
INSERT [dbo].[review_bar] ([id], [rating], [description], [bars_id], [user_id]) VALUES (16, 5, N'Aangenaam cafe, zeer leuk in het bos!', 1, 8)
SET IDENTITY_INSERT [dbo].[review_bar] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [first_name], [last_name], [username], [password], [email]) VALUES (1, N'Wouter', N'Vande Velde', N'Walter', N'Azerty123', N'w@msn.be')
INSERT [dbo].[user] ([id], [first_name], [last_name], [username], [password], [email]) VALUES (2, N'Fille', N'Mon', N'Fillemon', N'Azerty123', N'f@msn.be')
INSERT [dbo].[user] ([id], [first_name], [last_name], [username], [password], [email]) VALUES (3, N'Wouter', N'Velde', N'wa@msn.be', N'sbzoOelC1mVQGVkCMcuT6VPbFL04XvaixsHbf6aTUCW25hmcHsoY8n6V4qMpsMesvHWQfqx9ZFZnE8lDP0kdXw==', N'wa@msn.be')
INSERT [dbo].[user] ([id], [first_name], [last_name], [username], [password], [email]) VALUES (4, N'test', N'test', N'ttst', N'/mzo+EX2C+8CozTZrh5noogLqvof+6xA+HyAiUyULSNdCdmJupRj7TdbgL3k+aN5GNOE9KVROIoJNiCPlhHuiQ==', N'testtest@hotmail.com')
INSERT [dbo].[user] ([id], [first_name], [last_name], [username], [password], [email]) VALUES (5, N'admin', N'admin', N'admin', N'Nne6aGKBl5sUIyQ4Gt6Hvgh75UDndXhNTjtgyqHzSzXCw5T6nvjSevBIjDDtQ95Sek0F5i4tJ51OxL8btBj5fw==', N'admin@hotmail.com')
INSERT [dbo].[user] ([id], [first_name], [last_name], [username], [password], [email]) VALUES (6, N'wally', N'wonka', N'wallywonka', N'dD2zxL64ZX+1hLNrnGIafIcQcoFgJO9VjlElKCDgFehiXBj1aSZrp6T4b7XLwjJH5iY6Pdzee+mFzwkeMq/9pg==', N'wouter@student.odisee.be')
INSERT [dbo].[user] ([id], [first_name], [last_name], [username], [password], [email]) VALUES (7, N'Markske', N'Vertonghen', N'Werkthet', N'NbvFvP+rMvLi5diqGJXDb18XtdMPq8HzPEgL5g46PK1DbGg3qu3HKA48W4ZuXS6GcBUYwWHa/g+D5t7Z2fwsbQ==', N'ja@hotmail.com')
INSERT [dbo].[user] ([id], [first_name], [last_name], [username], [password], [email]) VALUES (8, N'Wouter', N'Vande Velde', N'Wouter', N'nimrSM0qcihp1bj4VZvGaOmjNjPWEwlY8dxkcJA/GAsIGKM2N84MXHFGi65wqE/4F/3xuTftfgJyb6uW7cKuTg==', N'wouter.vandevelde@student.odisee.be')
SET IDENTITY_INSERT [dbo].[user] OFF
INSERT [dbo].[usergroup] ([user_id], [group_id]) VALUES (1, 1)
INSERT [dbo].[usergroup] ([user_id], [group_id]) VALUES (2, 1)
INSERT [dbo].[usergroup] ([user_id], [group_id]) VALUES (5, 1)
INSERT [dbo].[usergroup] ([user_id], [group_id]) VALUES (6, 2)
INSERT [dbo].[usergroup] ([user_id], [group_id]) VALUES (7, 2)
INSERT [dbo].[usergroup] ([user_id], [group_id]) VALUES (8, 2)
ALTER TABLE [dbo].[comment_event]  WITH CHECK ADD  CONSTRAINT [FK_review_event_events] FOREIGN KEY([events_id])
REFERENCES [dbo].[events] ([id])
GO
ALTER TABLE [dbo].[comment_event] CHECK CONSTRAINT [FK_review_event_events]
GO
ALTER TABLE [dbo].[comment_event]  WITH CHECK ADD  CONSTRAINT [FK_review_event_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[comment_event] CHECK CONSTRAINT [FK_review_event_user]
GO
ALTER TABLE [dbo].[events]  WITH CHECK ADD  CONSTRAINT [FK_events_bars] FOREIGN KEY([bars_id])
REFERENCES [dbo].[bars] ([id])
GO
ALTER TABLE [dbo].[events] CHECK CONSTRAINT [FK_events_bars]
GO
ALTER TABLE [dbo].[events]  WITH CHECK ADD  CONSTRAINT [FK_events_genres] FOREIGN KEY([genre_id])
REFERENCES [dbo].[genres] ([id])
GO
ALTER TABLE [dbo].[events] CHECK CONSTRAINT [FK_events_genres]
GO
ALTER TABLE [dbo].[review_bar]  WITH CHECK ADD  CONSTRAINT [FK_review_bar_bars] FOREIGN KEY([bars_id])
REFERENCES [dbo].[bars] ([id])
GO
ALTER TABLE [dbo].[review_bar] CHECK CONSTRAINT [FK_review_bar_bars]
GO
ALTER TABLE [dbo].[review_bar]  WITH CHECK ADD  CONSTRAINT [FK_review_bar_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[review_bar] CHECK CONSTRAINT [FK_review_bar_user]
GO
ALTER TABLE [dbo].[usergroup]  WITH CHECK ADD  CONSTRAINT [FK_usergroup_groups] FOREIGN KEY([group_id])
REFERENCES [dbo].[groups] ([id])
GO
ALTER TABLE [dbo].[usergroup] CHECK CONSTRAINT [FK_usergroup_groups]
GO
ALTER TABLE [dbo].[usergroup]  WITH CHECK ADD  CONSTRAINT [FK_usergroup_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[usergroup] CHECK CONSTRAINT [FK_usergroup_user]
GO
USE [master]
GO
ALTER DATABASE [PopItUP] SET  READ_WRITE 
GO
