USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.CheckPermissionByUserId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[usm.CheckPermissionByUserId]
(

  @BusinessProcessId SMALLINT,
  @BranchId          SMALLINT,
  @UserId            SMALLINT

)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @PriviledgIds VARCHAR (150) ,
	         @Branches VARCHAR(150);

	SELECT @PriviledgIds = PrivilegeId FROM [msd.ApplicationUserPrivilegesDetails] WHERE UserId = @UserId


	IF NOT EXISTS (
		SELECT 1 FROM [msd.ApplicationUserPrivilegesDetails] AP
		WHERE UserId = @UserId AND
		@BusinessProcessId IN (SELECT * FROM dbo.splitstring( @PriviledgIds)))
	    
       BEGIN
	     RAISERROR('You do not have permission to perform this action', 16, 1);
		 RETURN 0
	   END


	IF ( @BranchId > 0)

	    BEGIN
		  
			DECLARE  @TempBranchTable TABLE(Id INT NOT NULL)
					

			SELECT  @Branches  = AUB.Branches
	        FROM [usm.ApplicationUserBranches] AUB
	        WHERE AUB.UserId = @UserId AND AUB.BusinessProcessId = @BusinessProcessId

   
           
			INSERT INTO @TempBranchTable
			(Id)
			
			 (SELECT BranchId
			FROM [msd.Branch]
			WHERE BranchId IN(SELECT * FROM dbo.splitstring(@Branches) ))

            IF NOT EXISTS ( SELECT 1 FROM @TempBranchTable WHERE Id = @BranchId)
			 BEGIN
			       RAISERROR('You can not perform this action for this branch', 16, 1);
				   RETURN 0

			 END
		   ELSE
		    BEGIN
			   RETURN 1
			END
		END

	
		
	
END 
GO
