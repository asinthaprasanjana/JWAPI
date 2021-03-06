USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.AddUserRole]    Script Date: 01/04/2019 9:46:08 AM ******/
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
	@UserRoleName  nvarchar(30),
	@pageNameList  nvarchar(30),
	@pageIdList    nvarchar(50),
	@CreatedUserId INT
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
