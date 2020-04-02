USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.GetApplicationUserDetailsByUserId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.GetApplicationUserDetailsByUserId]
(
	@UserId SMALLINT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Select 
		AULD.UserID,
		AULD.UserName
		
	FROM [msd.ApplicationUserLogInDetails] AULD
	WHERE AULD.UserID = @UserId

	
	
END
GO
