USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddUserCommentDetails]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.AddUserCommentDetails]
(
	
	@UserName VARCHAR(50),
	@UserComments VARCHAR(MAX),
	@CreatedUserId INT
)
	
AS
BEGIN
		INSERT INTO [dbo].[msd.UserComment]
           (
				[UserName]
			   ,[UserComments]
			   ,[CreatedUserId]
			   ,[CreatedDateTime]
		   
		   )

		values 
		( 
				@UserName,
				@UserComments,
				@CreatedUserId,
				GETDATE() 
		)
END
GO
