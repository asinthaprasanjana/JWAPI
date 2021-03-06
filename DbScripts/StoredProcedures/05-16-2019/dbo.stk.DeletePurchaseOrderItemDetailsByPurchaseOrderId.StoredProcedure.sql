USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.DeletePurchaseOrderItemDetailsByPurchaseOrderId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.DeletePurchaseOrderItemDetailsByPurchaseOrderId]
(
@PurchaseOrderItemId int
)

AS
SET NOCOUNT ON;
       IF EXISTS(SELECT * FROM [stk.PurchaseOrderItemsDraftDetails] WHERE Id = @PurchaseOrderItemId)
		 BEGIN
			  DELETE FROM [stk.PurchaseOrderItemsDraftDetails]  WHERE Id = @PurchaseOrderItemId
		 END
       ELSE
        BEGIN
          RAISERROR('This Purchase number does not exists', 16, 1);
        END
GO
