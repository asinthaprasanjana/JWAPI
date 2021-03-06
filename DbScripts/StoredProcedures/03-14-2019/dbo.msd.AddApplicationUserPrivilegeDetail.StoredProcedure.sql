USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddApplicationUserPrivilegeDetail]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddApplicationUserPrivilegeDetail]
	(
	 
      @UserId INT,
	  @PrivilegesId VARCHAR(100),
	  @CreatedUserId INT,
	  @LastCreatedUserId INT
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
