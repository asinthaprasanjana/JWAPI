USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ChatBotQuestionnaire]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
CREATE TABLE [dbo].[msd.ChatBotQuestionnaire](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId]  AS ([Id]) PERSISTED NOT NULL,
	[QuestionBody] [varchar](250) NULL,
	[AnswerBody] [varchar](250) NULL,
 CONSTRAINT [PK_msd.ChatBotQuestionnaire] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
