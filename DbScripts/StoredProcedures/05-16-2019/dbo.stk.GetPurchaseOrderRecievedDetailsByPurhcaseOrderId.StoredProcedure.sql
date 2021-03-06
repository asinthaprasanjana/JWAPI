USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPurchaseOrderRecievedDetailsByPurhcaseOrderId]    Script Date: 16/05/2019 12:39:09 PM ******/
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
 @RecievedTypeId SMALLINT,
 @IsHistory      SMALLINT

)
AS
BEGIN


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	SET NOCOUNT ON;



	--IF( @IsHistory =1)
	--  BEGIN

	--     SELECT 	    
	--		P.RecievedQuantity AS 'RecievedQuantity' ,
	--		P.ProductId, 
	--		PR.ProductName,
	--		PP.PackSizeName,
	--		P.TotalQuantity AS 'Quantity',
	--		AUL.UserName,
	--		CONVERT(VARCHAR, P.CreatedDateTime, 100) AS CreatedDateTime

	--		FROM [stk.PurchaseOrderRecievedEvents]  P
	--		INNER JOIN [msd_Product] PR ON PR.ProductId =P.ProductId
	--		INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = P.PackSizeId
	--		LEFT JOIN [msd.ApplicationUserLogInDetails] AUL ON AUL.UserId = P.CreatedUserId
	--		WHERE P.PurchaseNo = @PurchaseOrderID AND P.RecievedTypeId = @RecievedTypeId
	
	--  END
	--ELSE
	--  BEGIN
	--      SELECT 
	--	    SUM(P.RecievedQuantity) AS 'RecievedQuantity' 
	--	   ,P.ProductId
	--	   ,P.PurchaseOrderItemId
	--	   ,PR.ProductName
	--	   ,PP.PackSizeName
	--	   ,P.TotalQuantity AS 'Quantity'
	--		FROM [stk.PurchaseOrderRecievedEvents]  P
	--		INNER JOIN [msd_Product] PR ON PR.ProductId =P.ProductId
	--		INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = P.PackSizeId
	--		WHERE P.PurchaseNo = @PurchaseOrderID AND P.RecievedTypeId = @RecievedTypeId
	--		GROUP BY
	--		P.ProductId,
	--		PR.ProductName,
	--		PP.PackSizeName,
	--	    P.TotalQuantity,
	--		P.PurchaseOrderItemId
		
	--  END



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
			  END
			ELSE
			  BEGIN
			     SELECT 	    
					P.ProductId, 
					PR.ProductName,
					P.PurchaseOrderItemId,
					PP.PackSizeName,
					P.TotalQuantity AS 'Quantity',
					P.OrginalRecievedQuantity AS 'RecievedQuantity' ,
					AUL.UserName,
					CONVERT(VARCHAR, P.CreatedDateTime, 100) AS CreatedDateTime
					FROM [stk.PurchaseOrderRecieved]  P
					INNER JOIN [msd_Product] PR ON PR.ProductId =P.ProductId
					INNER JOIN [msd_ProductPackSize] PP ON PP.PackSizeId = P.PackSizeId
					LEFT JOIN [msd.ApplicationUserLogInDetails] AUL ON AUL.UserId = P.CreatedUserId
					WHERE P.PurchaseNo = @PurchaseOrderID 
			  END
	     
	   END
      
END 

GO
