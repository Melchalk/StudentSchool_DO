USE [Library]
GO

/****** Object:  Table [dbo].[Halls]    Script Date: 04.11.2023 19:57:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Halls](
	[No] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Thematics] [nvarchar](50) NULL,
	[Library_id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Halls] PRIMARY KEY CLUSTERED 
(
	[No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Halls]  WITH CHECK ADD  CONSTRAINT [FK_Halls_Halls] FOREIGN KEY([No])
REFERENCES [dbo].[Halls] ([No])
GO

ALTER TABLE [dbo].[Halls] CHECK CONSTRAINT [FK_Halls_Halls]
GO

ALTER TABLE [dbo].[Halls]  WITH CHECK ADD  CONSTRAINT [FK1_Libraries_Halls] FOREIGN KEY([Library_id])
REFERENCES [dbo].[Libraries] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Halls] CHECK CONSTRAINT [FK1_Libraries_Halls]
GO

