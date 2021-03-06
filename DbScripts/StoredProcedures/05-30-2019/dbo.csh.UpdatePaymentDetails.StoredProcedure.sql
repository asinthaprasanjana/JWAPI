USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.UpdatePaymentDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.UpdatePaymentDetails]
(
@PaymentMethodId INT ,
@PaymentMethodName VARCHAR(50),
@StartDate DATETIME,
@EndDate DATETIME

)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE[dbo].[msd.PaymentMethod]  SET
	PaymentMethodName = @PaymentMethodName	,
     StartDate = @StartDate,
	 EndDate = @EndDate
	WHERE PaymentMethodId = @PaymentMethodId
END 
GO
