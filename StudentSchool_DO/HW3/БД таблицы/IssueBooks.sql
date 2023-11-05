USE [Library]
GO

/****** Object:  Table [dbo].[IssueBooks]    Script Date: 04.11.2023 19:57:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IssueBooks](
	[Issue_id] [uniqueidentifier] NOT NULL,
	[Book_id] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IssueBooks]  WITH CHECK ADD  CONSTRAINT [FK_Books_IssueBooks] FOREIGN KEY([Book_id])
REFERENCES [dbo].[Books] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[IssueBooks] CHECK CONSTRAINT [FK_Books_IssueBooks]
GO

ALTER TABLE [dbo].[IssueBooks]  WITH CHECK ADD  CONSTRAINT [FK_Issues_IssueBooks] FOREIGN KEY([Issue_id])
REFERENCES [dbo].[Issues] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[IssueBooks] CHECK CONSTRAINT [FK_Issues_IssueBooks]
GO

