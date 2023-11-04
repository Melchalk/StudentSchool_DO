USE [Library]
GO

/****** Object:  Table [dbo].[Librarians]    Script Date: 04.11.2023 19:59:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Librarians](
	[Id] [uniqueidentifier] NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Telephone] [nvarchar](50) NOT NULL,
	[Library_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Librarians]  WITH CHECK ADD  CONSTRAINT [FK_Libraries_Librarians] FOREIGN KEY([Library_id])
REFERENCES [dbo].[Libraries] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Librarians] CHECK CONSTRAINT [FK_Libraries_Librarians]
GO

