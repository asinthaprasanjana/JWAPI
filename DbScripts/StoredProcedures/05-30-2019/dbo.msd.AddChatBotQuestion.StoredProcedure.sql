USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddChatBotQuestion]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddChatBotQuestion]
(
  @QuestionBody VARCHAR(250)
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
