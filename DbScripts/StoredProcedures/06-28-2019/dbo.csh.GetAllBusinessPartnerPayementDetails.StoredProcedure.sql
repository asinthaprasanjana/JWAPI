USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllBusinessPartnerPayementDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[csh.GetAllBusinessPartnerPayementDetails]
(
 @companyId SMALLINT,
 @Status    TINYINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	  BP.BillId,
	BP.BusinessPartnerId,
	SUM(BP.TotalPrice) AS TotalPrice ,
	B.DisplayName
	FROM [csh.BillPayment] BP
	INNER JOIN [bsp.BusinessPartner] B ON B.BusinessPartnerId = BP.BusinessPartnerId
	GROUP BY BP.BillId, BP.BusinessPartnerId, B.DisplayName


END 
GO
