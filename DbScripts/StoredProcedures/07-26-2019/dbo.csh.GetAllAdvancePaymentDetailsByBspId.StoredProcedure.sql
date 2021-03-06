USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllAdvancePaymentDetailsByBspId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllAdvancePaymentDetailsByBspId]
(
@BspId varchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	AP.AdvancePaymentId,
	CONVERT(VARCHAR(20), AP.[CreatedDateTime], 100 ) AS CreatedDateTime,
	AP.PaymentMethodId,
	BP.DisplayName +' ('+ BP.BusinessPartnerId + ')' as BusinessPartnerName,
	PM.PaymentMethodName,
	AP.BusinessPartnerId,
	AP.TotalPrice,
	AULD.UserName
	FROM [dbo].[csh.AdvancePayment] AP
	INNER JOIN [msd.PaymentMethod] PM ON PM.PaymentMethodId = AP.PaymentMethodId
	INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = AP.BusinessPartnerId
	INNER JOIN [msd.ApplicationUserLogInDetails] AULD ON AULD.UserId = AP.CreatedUserId
	WHERE AP.BusinessPartnerId = @BspId
	ORDER BY AP.CreatedDateTime DESC
END 
GO
