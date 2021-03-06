USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecievedDetailsByPurhcaseOrderId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPurchaseOrderRecievedDetailsByPurhcaseOrderId]
(

 @PurchaseOrderID VARCHAR(20),
 @RecievedTypeId INT,
 @IsHistory      SMALLINT

)
AS
BEGIN


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	SET NOCOUNT ON;



	IF ( @RecievedTypeId = 2)
	   BEGIN
	    			   
	     SELECT 	    
			P.ProductId,
			P.PurchaseOrderItemId,
			PR.ProductName,
			PP.PackSizeName,
			P.TotalQuantity AS 'Quantity',
			P.TempRecievedQuantity AS 'RecievedQuantity' ,
			AUL.UserName,
			CONVERT(VARCHAR, P.CreatedDateTime, 100) AS CreatedDateTime

			FROM [stk.PurchaseOrderRecieved]  P
			INNER JOIN [msd_Product] PR ON PR.ProductId =P.ProductId
			INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = P.PackSizeId
			LEFT JOIN [msd.ApplicationUserLogInDetails] AUL ON AUL.UserId = P.CreatedUserId
			WHERE P.PurchaseNo = @PurchaseOrderID 
			ORDER BY P.PurchaseOrderItemId ASC;

	  
	   END
   ELSE IF ( @RecievedTypeId = 3 )
       BEGIN

	        IF EXISTS ( SELECT 1 FROM [stk.PurchaseOrder] WHERE PurchaseNo = @PurchaseOrderID AND QcAvailable = 1)
			  BEGIN
			    
			      SELECT 	    
					P.ProductId, 
					PR.ProductName,
					P.PurchaseOrderItemId,
					PP.PackSizeName,
					P.TempRecievedQuantity AS 'Quantity',
					P.OrginalRecievedQuantity AS 'RecievedQuantity' ,
					AUL.UserName,
					CONVERT(VARCHAR, P.CreatedDateTime, 100) AS CreatedDateTime

					FROM [stk.PurchaseOrderRecieved]  P
					INNER JOIN [msd_Product] PR ON PR.ProductId =P.ProductId
					INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = P.PackSizeId
					LEFT JOIN [msd.ApplicationUserLogInDetails] AUL ON AUL.UserId = P.CreatedUserId
					WHERE P.PurchaseNo = @PurchaseOrderID 
					ORDER BY P.PurchaseOrderItemId ASC;

			  END
			ELSE
			  BEGIN

			       

			        SELECT 	    
					P.ProductId, 
					PR.ProductName,
					P.PurchaseOrderItemId,
					PP.PackSizeName,
					P.TotalQuantity AS 'Quantity',
					P.OrginalRecievedQuantity AS 'RecievedQuantity' ,  -- dont change  
					AUL.UserName,
					CONVERT(VARCHAR, P.CreatedDateTime, 100) AS CreatedDateTime
					FROM [stk.PurchaseOrderRecieved]  P
					INNER JOIN [msd_Product] PR ON PR.ProductId =P.ProductId
					INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = P.PackSizeId
					LEFT JOIN [msd.ApplicationUserLogInDetails] AUL ON AUL.UserId = P.CreatedUserId
					WHERE P.PurchaseNo = @PurchaseOrderID 
					ORDER BY P.PurchaseOrderItemId ASC;

			  END
	     
	   END
      
END 

GO
