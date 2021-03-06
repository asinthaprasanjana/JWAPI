USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecievedDetailsByCompanyId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderRecievedDetailsByCompanyId]
	(
	  @CompanyId TINYINT,
	  @Status    TINYINT,
	  @RecievedTypeId SMALLINT,
	  @PageId INT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	

	
	SELECT
	POR.RecievedId,
	POR.PurchaseNo,
	BP.DisplayName AS 'BusinessPartnerName',
	AU.UserName

	FROM  [stk.PurchaseOrderRecievedEvents] POR
	INNER JOIN [stk.PurchaseOrder] PO ON PO.PurchaseNo = POR.PurchaseNo
	INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = PO.SupplierId
	INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserId = POR.CreatedUserId
	WHERE POR.RecievedId >0 AND POR.RecievedTypeId = 3
	GROUP BY POR.RecievedId ,POR.PurchaseNo,BP.DisplayName,AU.UserName
	ORDER BY  POR.RecievedId DESC 



END
GO
