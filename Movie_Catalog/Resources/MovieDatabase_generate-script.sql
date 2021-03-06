USE [master]
GO
/****** Object:  Database [MovieDatabase]    Script Date: 2015-11-19 00:02:34 ******/
CREATE DATABASE [MovieDatabase]

GO
USE [MovieDatabase]
GO
/****** Object:  Table [dbo].[Favourite_Hated]    Script Date: 2015-11-19 00:02:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favourite_Hated](
	[FilmID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[LikeOrDislike] [int] NOT NULL,
 CONSTRAINT [PK_Favourite_Hated] PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MainMovieList]    Script Date: 2015-11-19 00:02:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainMovieList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Movie_Name] [nvarchar](50) NULL,
	[File_Name] [nvarchar](max) NOT NULL,
	[File_Path] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MainMovieList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Playlist]    Script Date: 2015-11-25 19:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlist](
	[UserID] [int] NOT NULL,
	[FilmID] [int] NOT NULL,
	[isOnPlaylist] [int] NOT NULL,
 CONSTRAINT [PK_Playlist] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Users]    Script Date: 2015-11-19 00:02:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Favourite_Hated]  WITH CHECK ADD FOREIGN KEY([FilmID])
REFERENCES [dbo].[MainMovieList] ([ID])
GO
ALTER TABLE [dbo].[Favourite_Hated]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
USE [master]
GO
ALTER DATABASE [MovieDatabase] SET  READ_WRITE 
GO
