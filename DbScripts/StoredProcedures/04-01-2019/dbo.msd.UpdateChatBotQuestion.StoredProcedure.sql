USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateChatBotQuestion]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UpdateChatBotQuestion]
(
@QuestionId INT,
@QuestionBody NVARCHAR(250)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE  [dbo].[msd.ChatBotQuestionnaire] SET
		QuestionBody = @QuestionBody
      
	WHERE QuestionId = @QuestionId
END 
GO
