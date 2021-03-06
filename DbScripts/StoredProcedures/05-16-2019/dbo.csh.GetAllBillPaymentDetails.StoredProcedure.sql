USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllBillPaymentDetails]    Script Date: 16/05/2019 12:39:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllBillPaymentDetails]


AS
BEGIN
	 --SET NOCOUNT ON added to prevent extra result sets from
	 --interfering with SELECT statements.
	SET NOCOUNT ON;

	Select B.BillId
	,SUM (B.[TotalPrice]) AS PaidAmount
	,B.[BusinessPartnerId]
	,BP.DisplayName AS BSPDisplayName
	FROM [dbo].[csh.BillPayment] B
	INNER JOIN [bsp.BusinessPartner] BP ON B.BusinessPartnerId=BP.BusinessPartnerId
	Group BY B.BillId,B.[BusinessPartnerId],BP.DisplayName
END 
GO
