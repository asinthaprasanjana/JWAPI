USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetApplicationUserDetailsById]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[msd.GetApplicationUserDetailsById]
@UserId SMALLINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT TOP 1
	AULD.UserId,
	AULD.UserName,
	UR.RoleName,
	AUD.Address,
	AUD.Email,
	AUD.MobileNo
	From [msd.ApplicationUserLogInDetails] AULD
	INNER JOIN [usm.UserRoles] UR ON AULD.RoleId=UR.RoleId
	INNER JOIN [msd.ApplicationUserDetails] AUD ON AUD.UserId = AULD.UserId
	WHERE AULD.UserId=@UserId AND AULD.IsApproved = 1 AND AULD.IsActive = 1

	
END
GO
