USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetBranchDetailsByUserId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[msd.GetBranchDetailsByUserId]
(

 @UserId INT,
 @BusinessProcessId INT

 )

AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @Branches VARCHAR(100);

	SELECT  @Branches  = AUB.Branches
	FROM [msd.ApplicationUserBranches] AUB
	WHERE AUB.UserId = @UserId AND AUB.BusinessProcessId = @BusinessProcessId

   

   SELECT *
   FROM [msd.Branch]
   WHERE BranchId IN(SELECT * FROM dbo.splitstring(@Branches) ) 
END
GO
