USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetBranchDetailsByCompanyId]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[msd.GetBranchDetailsByCompanyId]
(
 @CompanyId INT
 )

AS
BEGIN

	SET NOCOUNT ON;
    SELECT 
	BR.Id,
	BR.BranchId,
	BTD.TypeDetail AS BranchType,
	BR.BranchName,
	BR.DisplayName,
	BR.BranchTypeId,
	BR.PhoneNo,
	BR.Address,
	BR.City,
	BR.CompanyId,
	BR.CreatedUserId
	FROM
	[msd.Branch] BR INNER JOIN [msd.BranchTypeDetails] BTD
	ON BR.BranchTypeId = BTD.Id
END
GO
