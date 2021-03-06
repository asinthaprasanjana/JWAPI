USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[GetAllDashBoardDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllDashBoardDetails]
(
@TypeId INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

IF(@TypeId = 1)
	BEGIN
		SELECT b.BranchName,SUM(SO.NetTotal) AS Total
		FROM [stk.SalesOrder]  SO
		 INNER JOIN [dbo].[msd.Branch] B
		 ON SO.BillLocationId = B.BranchId
		GROUP BY SO.BillLocationId,B.BranchName
	END

ELSE IF(@TypeId = 2)
	BEGIN
	SELECT B.BranchName,SUM(PO.NetTotal) AS Total
	FROM [dbo].[stk.PurchaseOrder] PO INNER JOIN [msd.Branch] B
	ON PO.BranchId = B.BranchId
	GROUP BY PO.BillLocationId,B.BranchName
	END

END
GO
