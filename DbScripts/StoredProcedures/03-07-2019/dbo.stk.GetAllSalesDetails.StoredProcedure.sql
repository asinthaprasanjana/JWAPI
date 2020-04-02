USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllSalesDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
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
