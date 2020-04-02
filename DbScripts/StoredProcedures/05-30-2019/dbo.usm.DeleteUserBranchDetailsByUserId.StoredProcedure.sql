USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.DeleteUserBranchDetailsByUserId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[usm.DeleteUserBranchDetailsByUserId]
(
  @UserId            SMALLINT,
  @CreatedUserId     SMALLINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 
	 IF EXISTS ( SELECT 1 FROM [usm.ApplicationUserBranches] AUB WHERE AUB.UserId = @UserId )
	    BEGIN
		 UPDATE [usm.ApplicationUserBranches] 
		  SET
		  Branches = '',
		  LastModifiedUserId = @CreatedUserId,
		  LastModifiedDateTime = GETDATE()
		  WHERE UserId = @UserId

		
		END
	
	
END 
GO
