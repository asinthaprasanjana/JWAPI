USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllSalesDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAllSalesDetails]
(
	@OrderId INT
)
AS
BEGIN
	Select  *
	FROM [dbo].[stk.SalesReturn] SR
	WHERE SR.OrderId = @OrderId


END
GO
