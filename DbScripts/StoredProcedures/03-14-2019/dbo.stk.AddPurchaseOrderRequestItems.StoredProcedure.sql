USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddPurchaseOrderRequestItems]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddPurchaseOrderRequestItems]
	(

	   @CompanyId int,
	   @PurchaseNo nvarchar(20),
	   @ProductId int,
	   @Quantity float,
	   @CreatedUserId int

	)
AS
BEGIN
       DECLARE @ProductName NVARCHAR(300);

		SELECT @ProductName = PO.ProductName
		FROM [dbo].[msd_Product] PO
		WHERE PO.ProductId = @ProductId 
	

		INSERT INTO [dbo].[stk.PurchaseOrderRequestItems]
           (
				
			   [CompanyId]
			   ,[PurchaseNo]
			   ,[ProductId]
			   ,[ProductName]
			   ,[Quantity]
			   ,[CreatedUserId]
			   ,[CreatedDateTime]
          
		   )
     VALUES
           (
		     
              @CompanyId, 
              @PurchaseNo,
              @ProductId,
			  @ProductName, 
              @Quantity, 
              @CreatedUserId,
              GETDATE()
             
		   )
	
END
GO
