USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderDraftSummeryDetailsByUserId]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderDraftSummeryDetailsByUserId]
(
 @CompanyId INT,
 @UserId INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

IF(@UserId IS NULL)
	BEGIN

	 SELECT 
	
	POD.NetTotal,
	BP.DisplayName,
	3 as 'COUNT',
	convert(varchar(10), POD.CreatedDateTime, 120) AS CreatedDateTime
	FROM [stk.PurchaseOrderDraftDetails] POD
    INNER JOIN [bsp.BusinessPartner] BP ON POD.SupplierId=BP.BusinessPartnerId
	WHERE  POD.CompanyId = @CompanyId
	ORDER BY POD.CreatedDateTime DESC

	END
ELSE
   BEGIN

    SELECT 
	POD.PurchaseNo,
	POD.NetTotal,
	BP.DisplayName,
	COUNT(PID.Id) AS COUNT,
	convert(varchar(10), POD.CreatedDateTime, 120) AS CreatedDateTime
	FROM [stk.PurchaseOrderDraftDetails] POD
    INNER JOIN [bsp.BusinessPartner] BP ON POD.SupplierId=BP.BusinessPartnerId 
	INNER JOIN  [stk.PurchaseOrderItemsDraftDetails] PID ON PID.PurchaseNo= POD.PurchaseNo 
	WHERE POD.CreatedUserId = @UserId AND POD.CompanyId = @CompanyId
	GROUP BY POD.PurchaseNo,POD.NetTotal,BP.DisplayName,POD.CreatedDateTime
	ORDER BY POD.CreatedDateTime DESC

    END
END
GO
