USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetSalesOrderId]    Script Date: 30/05/2019 11:36:25 AM ******/
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
