USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetCurrencyByCurrencyID]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetCurrencyByCurrencyID]
(

 @CompanyID INT 
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
		currency.id,
		currency.CurrencyId,
		currency.CreatedUserId,
		currency.CreatedDateTime,
		currency.DisplayName
	FROM [msd.Currency] currency
	where currency.CompanyId=@CompanyID
END 
GO
