USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPriceLevelBranchDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPriceLevelBranchDetails]
(
@UserId SMALLINT,
@PriceLevelId SMALLINT,
@ProductIdId INT
)	
AS
BEGIN

 SELECT 
  DISTINCT PL.BranchId,
 B.BranchName
 FROM [msd.ProductPriceLevelItems] PL
 INNER JOIN [msd.Branch] B ON B.BranchId = PL.BranchId
 --ORDER BY B.BranchId
	    
END 
GO
