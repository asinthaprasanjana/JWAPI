USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddChatBotQuestion]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddChatBotQuestion]
(
  @QuestionBody NVARCHAR(250)
)
AS
BEGIN
		INSERT INTO [dbo].[msd.ChatBotQuestionnaire]
           (
		     [QuestionBody]
		   )

		VALUES 
		( 
		   @QuestionBody  
		)

END
GO
