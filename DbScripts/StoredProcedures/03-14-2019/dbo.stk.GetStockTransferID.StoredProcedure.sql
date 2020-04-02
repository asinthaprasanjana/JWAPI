USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetStockTransferID]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetStockTransferID]
	@CompanyID INT
AS
BEGIN
	SELECT Top 1
		ST.StockTransferId
	FROM [stk.StockTransfers] ST
	WHERE ST.CompanyId= @CompanyID
	ORDER BY StockTransferId DESC

END
GO
