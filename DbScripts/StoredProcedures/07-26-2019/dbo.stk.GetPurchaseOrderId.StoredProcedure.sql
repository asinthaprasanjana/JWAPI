USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderId]
	@CompanyID INT
AS
BEGIN
				DECLARE	@purchaseNo                    VARCHAR(20),
				        @PurchaseOrderDocumentTypeId   TINYINT = 1;

				--EXEC [dbo].[stk.GetDocumentIdByDocumentTypeId] @PurchaseOrderDocumentTypeId, @purchaseNo OUTPUT

	--Select @purchaseNo AS 'PurchaseNo'

END
GO
