USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetBillPaymentDetailsByBillId]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetBillPaymentDetailsByBillId]
(
@BillId nvarchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	 BP.[BillPaymentId]
	,BP.[BillId]
	,BP.[BusinessPartnerId]
	,B.DisplayName AS BspDisplayName
	,BP.[TotalPrice]
	,CONVERT(VARCHAR(20), BP.[CreatedDateTime], 100 ) AS CreatedDateTime
	FROM [dbo].[csh.BillPayment]BP
	INNER JOIN [bsp.BusinessPartner] B ON B.BusinessPartnerId=BP.BusinessPartnerId
	WHERE BillId = @BillId
END 
GO
