USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.GetUserBranchDetailsByUserId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.GetUserBranchDetailsByUserId]
( 
  @UserId SMALLINT,
  @BusinessProcessId SMALLINT
  )

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT AUB.BusinessProcessId , AUB.Branches AS BranchId
	FROM [usm.ApplicationUserBranches] AUB
	WHERE AUB.UserId = @UserId
END
GO
