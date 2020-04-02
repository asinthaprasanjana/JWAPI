USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.UpdatePaymentDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
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
@PaymentMethodName NVARCHAR(50),
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
