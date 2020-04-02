USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderDetailsGroupByApprovalRecieved]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderDetailsGroupByApprovalRecieved]
(

@CompanyId INT

)
	
AS
BEGIN
 
	SELECT Recieved AS Status, COUNT(*) AS Count
	FROM  [dbo].[stk.PurchaseOrder]
	WHERE CompanyId = @CompanyId
	GROUP BY Recieved
	
END
GO
