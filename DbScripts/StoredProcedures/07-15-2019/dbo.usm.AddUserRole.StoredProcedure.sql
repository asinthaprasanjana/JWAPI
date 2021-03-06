USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.AddUserRole]    Script Date: 15/07/2019 12:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.AddUserRole]
    @Id            INT,
	@RoleId        INT,
	@CompanyId    INT,
	@UserRoleName  VARCHAR(30),
	@pageNameList  VARCHAR(30),
	@pageIdList    VARCHAR(50),
	@CreatedUserId SMALLINT
AS
BEGIN

        DECLARE @InsertedUserRoleId INT;

IF EXISTS (SELECT * FROM [usm.UserRoles] UR WHERE UR.RoleName = @UserRoleName)
BEGIN 

       RAISERROR(N'This user role already exists', 16, 1);


END

ELSE
BEGIN
		INSERT INTO [usm.UserRoles]
		(
			CompanyID,
			RoleName,
			PageIds ,
			CreatedUserId,
			CreatedDateTime
		) 
		values 
		( 
			@CompanyId,
			@UserRoleName ,
			@pageIdList ,
			@CreatedUserId ,
			GETDATE() 	 	  
		)
END
		SELECT @InsertedUserRoleId= SCOPE_IDENTITY() 

		
		SELECT 
		 UR.Id AS 'Id',
		 UR.RoleName AS 'UserRoleName',
		 UR.PageIds AS 'PageIdList'
		 FROM [usm.UserRoles] UR 
		WHERE UR.Id = @InsertedUserRoleId


		

END 
GO
