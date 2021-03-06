USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllAdvancePaymentDetails]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllAdvancePaymentDetails]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	       AP.BusinessPartnerId,
		  BP.DisplayName AS BusinessPartnerName ,
	      SUM( AP.TotalPrice) AS TotalPrice,
		  BP.NIC,
		  BP.CompanyName
	FROM [dbo].[csh.AdvancePayment] AP 
	INNER JOIN [bsp.BusinessPartner] BP ON BP.BusinessPartnerId = AP.BusinessPartnerId
	INNER JOIN [msd.PaymentMethod] PM ON PM.PaymentMethodId = AP.PaymentMethodId
	GROUP BY AP.BusinessPartnerId, BP.DisplayName, BP.NIC, BP.CompanyName
END 
GO
