USE [Library]
GO

/****** Object:  Table [dbo].[Issues]    Script Date: 04.11.2023 19:58:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Issues](
	[Id] [uniqueidentifier] NOT NULL,
	[Reader_id] [uniqueidentifier] NOT NULL,
	[Date_issue] [date] NOT NULL,
	[Period] [int] NOT NULL,
 CONSTRAINT [PK_Issues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Issues]  WITH CHECK ADD  CONSTRAINT [FK_Readers_Issues] FOREIGN KEY([Reader_id])
REFERENCES [dbo].[Readers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Issues] CHECK CONSTRAINT [FK_Readers_Issues]
GO

