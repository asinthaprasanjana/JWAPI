USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderReportDetailsGroupByApprovalStatus]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderReportDetailsGroupByApprovalStatus]
(

@CompanyId INT

)
	
AS
BEGIN
 
	SELECT Status AS Status, COUNT(*) AS Count
	FROM  [dbo].[stk.PurchaseOrder]
	WHERE CompanyId = @CompanyId
	GROUP BY Status
	
END
GO
