USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllBusinessPartnerPayementDetailsByBusinessPartnerId]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE  PROCEDURE [dbo].[csh.GetAllBusinessPartnerPayementDetailsByBusinessPartnerId]
(
 @BusinessPartnerId INT
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
	WHERE BP.BusinessPartnerId = @BusinessPartnerId

END 
GO
