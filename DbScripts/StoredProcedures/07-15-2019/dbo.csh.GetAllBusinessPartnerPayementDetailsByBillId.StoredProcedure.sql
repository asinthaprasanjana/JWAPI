USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllBusinessPartnerPayementDetailsByBillId]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[csh.GetAllBusinessPartnerPayementDetailsByBillId]
(
 @BillId INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	 BP.BillId,
	BP.BusinessPartnerId,
	BP.TotalPrice AS TotalPrice ,
	B.DisplayName
	FROM [csh.BillPayment] BP
	INNER JOIN [bsp.BusinessPartner] B ON B.BusinessPartnerId = BP.BusinessPartnerId
	WHERE BP.BillId = @BillId

END 
GO
