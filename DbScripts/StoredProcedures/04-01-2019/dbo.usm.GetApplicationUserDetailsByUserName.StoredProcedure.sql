USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.GetApplicationUserDetailsByUserName]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.GetApplicationUserDetailsByUserName]
(
	@UserName nvarchar (50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Select 
		AULD.Password as currentPassword,
		AUD.Email
		
	FROM [msd.ApplicationUserLogInDetails] AULD
	INNER JOIN [msd.ApplicationUserDetails] AUD ON AUD.UserId= AULD.UserId
	WHERE AULD.UserName = @UserName

	
	
END
GO
