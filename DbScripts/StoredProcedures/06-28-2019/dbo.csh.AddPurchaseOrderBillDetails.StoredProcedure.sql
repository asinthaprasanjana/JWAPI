USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddPurchaseOrderBillDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
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
@CreatedUserId SMALLINT
)
	
AS
BEGIN

 	   	

		
    DECLARE @LastPurchaseOrderBillId INT,
	        @BillDocumentTypeId      SMALLINT = 5,
			@Id                      VARCHAR(20),
	        @BillDocumentNo          VARCHAR(20);

	IF EXISTS (SELECT 1 FROM [csh.PurchaseOrderBilled] WHERE SupplierBillNo = @SupplierBillNo)
	  BEGIN
	   		  RAISERROR('Duplicate Bill No. Bill Creation Failed', 16, 1);
			  RETURN 0

	  END
	     
		EXEC	 [dbo].[stk.GetDocumentIdByDocumentTypeId] @BillDocumentTypeId, @Id OUTPUT
			        SET @BillDocumentNo = @Id

	INSERT INTO [dbo].[csh.PurchaseOrderBilled]
           ([CompanyId]
		    ,[DocumentNo]
           ,[PurchaseOrderNo]
		   ,[SupplierBillNo]
		   ,[BillDate]
           ,[TotalPrice]
           ,[CreatedUserId]
           ,[CreatedDateTime])

    VAlUES(

			  @CompanyId,
			  @BillDocumentNo,
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
