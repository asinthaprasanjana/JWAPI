USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddApplicationUserPrivilegeDetail]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddApplicationUserPrivilegeDetail]
	(
	 
      @UserId SMALLINT,
	  @PrivilegesId VARCHAR(100),
	  @CreatedUserId SMALLINT,
	  @LastCreatedUserId SMALLINT
	)

AS
BEGIN

	  INSERT INTO [dbo].[msd.ApplicationUserPrivilegesDetail]
           (
		         [UserId]
			   ,[PrivilegesId]
			   ,[CreatedUserId]
			   ,[CreatedDateTime]
			   ,[LastCreatedUserId]
			   ,[LastCreatedDateTime]
		   
		   )
		values 
		( 
			@UserId,
			@PrivilegesId,
			@CreatedUserId,
			GETDATE(),
			@LastCreatedUserId,
			GETDATE()
		)

		
	 
END
GO
