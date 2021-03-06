USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetAllApplicationUserDetails]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[msd.GetAllApplicationUserDetails]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT 
	AULD.UserId,
	AULD.UserName,
	UR.RoleName,
	UR.RoleId
	From [msd.ApplicationUserLogInDetails] AULD
	INNER JOIN [usm.UserRoles] UR ON AULD.RoleId=UR.RoleId
	--ORDER BY UR.RoleId
	ORDER BY AULD.Id ASC
	
END
GO
