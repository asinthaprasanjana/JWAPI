USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddPurchaseOrderBillDetails]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[csh.AddPurchaseOrderBillDetails]
(
@CompanyId INT,
@PurchaseOrderNo VARCHAR(20),
@SupplierBillNo VARCHAR(20),
@BillDate DATE,
@TotalPrice FLOAT,
@CreatedUserId INT
)
	
AS
BEGIN

 
		
    DECLARE @LastPurchaseOrderBillId INT;

	IF EXISTS (SELECT 1 FROM [csh.PurchaseOrderBilled] WHERE SupplierBillNo = @SupplierBillNo)
	  BEGIN
	   		  RAISERROR('Duplicate Bill No. Bill Creation Failed', 16, 1);
			  RETURN 0

	  END
	     

	INSERT INTO [dbo].[csh.PurchaseOrderBilled]
           ([CompanyId]
           ,[PurchaseOrderNo]
		   ,[SupplierBillNo]
		   ,[BillDate]
           ,[TotalPrice]
           ,[CreatedUserId]
           ,[CreatedDateTime])

    VAlUES(

			  @CompanyId,
			  @PurchaseOrderNo,
			  @SupplierBillNo,
			  @BillDate,
			  @TotalPrice,
			  @CreatedUserId,
			  GETDATE()
	      )

		

		  
		SELECT @LastPurchaseOrderBillId = SCOPE_IDENTITY() 
		SELECT @LastPurchaseOrderBillId AS Id
		
END


GO
