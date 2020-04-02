USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.GetUserDetailsByUserId]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.GetUserDetailsByUserId]
(
	@UserId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Select 
		AU.UserID,
		AU.FirstName + ' '+ AU.LastName  AS UserName
		
	FROM [usm.ApplicationUser] AU
	WHERE AU.UserID = @UserId

	
	
END
GO
