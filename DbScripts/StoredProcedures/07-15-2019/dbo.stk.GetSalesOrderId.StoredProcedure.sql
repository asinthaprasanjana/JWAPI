USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderId]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetSalesOrderId]
	@CompanyId INT
AS
BEGIN
	Select TOP 1 *
	FROM [stk.SalesOrder] SO
	WHERE SO.CompanyId = @CompanyId
	ORDER by SO.Id DESC 

END
GO
