USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllPurchaseOrderReturnDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[stk.GetAllPurchaseOrderReturnDetails]
(
@CompanyId INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT 
	
	POR.PurchaseReturnId AS Id,
	BP.DisplayName AS businessPartnerName,
	POR.ReturningTotal,
	POR.Remarks,
	POR.CreatedDateTime
	From  [dbo].[stk.PurchaseOrderReturnDetails] POR
	INNER JOIN [bsp.BusinessPartner]BP ON BP.BusinessPartnerId=POR.SupplierId
	WHERE POR.CompanyId = @CompanyId
	
END
GO
