USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.DeleteSalesOrderItemDetailsBySalesOrderId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.DeleteSalesOrderItemDetailsBySalesOrderId]
(
@SalesOrderItemId INT
)

AS
SET NOCOUNT ON;
       IF EXISTS(SELECT * FROM [stk.SalesOrderItemsDraftDetails] WHERE Id = @SalesOrderItemId)
		 BEGIN
			  DELETE FROM [stk.SalesOrderItemsDraftDetails]  WHERE Id = @SalesOrderItemId
		 END
       ELSE
        BEGIN
          RAISERROR('This Purchase number does not exists', 16, 1);
        END
GO
