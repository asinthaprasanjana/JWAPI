USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllPaymentMethodDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllPaymentMethodDetails]


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		PM.PaymentMethodId,
		PM.PaymentMethodName,
		convert(nvarchar(11),PM.StartDate, 0)AS StartDate,
		convert(nvarchar(11),PM.EndDate, 0)AS EndDate

	--CONVERT(DATE,PM.StartDate) AS StartDate,
--	CONVERT(DATE,PM.EndDate) AS EndDate
	FROM [dbo].[msd.PaymentMethod] PM
END 
GO
