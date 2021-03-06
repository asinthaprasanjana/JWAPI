USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.UpdateApplicationUserBranchDetailsByUserId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[usm.UpdateApplicationUserBranchDetailsByUserId]
(

  @BusinessProcessId INT,
  @UserId            INT,
  @Branches          VARCHAR(150),
  @CreatedUserId     INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 
	 IF EXISTS ( SELECT 1 FROM [usm.ApplicationUserBranches] AUB WHERE AUB.UserId = @UserId AND AUB.BusinessProcessId = @BusinessProcessId)
	    BEGIN
		  UPDATE [usm.ApplicationUserBranches] 
		  SET
		  Branches = @Branches,
		  LastModifiedUserId = @CreatedUserId,
		  LastModifiedDateTime = GETDATE()
		  WHERE UserId = @UserId AND BusinessProcessId = @BusinessProcessId
		END
	ELSE
	  BEGIN
	     INSERT INTO [usm.ApplicationUserBranches] 
		  (
		    BusinessProcessId,
			UserId,
			Branches,
			CreatedUserId
			)
			VALUES
			 (
			  @BusinessProcessId,
			  @UserId,
			  @Branches,
			  @CreatedUserId
			  )
	  END

	
		
	
END 
GO
