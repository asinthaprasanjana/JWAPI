USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetBranchDetailsByUserId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[msd.GetBranchDetailsByUserId]
(

 @UserId SMALLINT,
 @BusinessProcessId INT

 )

AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @Branches VARCHAR(100);

	SELECT  @Branches  = AUB.Branches
	FROM [usm.ApplicationUserBranches] AUB
	WHERE AUB.UserId = @UserId AND AUB.BusinessProcessId = @BusinessProcessId

   

   SELECT *
   FROM [msd.Branch]
   WHERE BranchId IN(SELECT * FROM dbo.splitstring(@Branches) ) 
END
GO
