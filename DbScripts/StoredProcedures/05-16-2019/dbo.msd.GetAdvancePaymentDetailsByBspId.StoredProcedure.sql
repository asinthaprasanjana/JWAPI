USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetAdvancePaymentDetailsByBspId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetAdvancePaymentDetailsByBspId]
(
@BspId varchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT SUM(AP.TotalPrice) as TotalPrice
	FROM [dbo].[csh.AdvancePayment] AP
	WHERE BusinessPartnerId = @BspId
END 
GO
