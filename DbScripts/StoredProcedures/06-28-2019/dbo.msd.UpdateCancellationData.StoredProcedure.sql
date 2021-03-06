USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateCancellationData]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UpdateCancellationData] 
(
	@cancellationTypeId SMALLINT,
	@id varchar(20),
	@userId smallint
)
AS
BEGIN

         DECLARE @Cancelled TINYINT =1
     IF(@cancellationTypeId = 1  ) --stock Transfer
	 BEGIN
		 UPDATE [stk.StockTransferSummeryDetails]
		 SET isCancelled = @Cancelled
		 WHERE TransferId = @id;
	 END
    
	 IF(@cancellationTypeId = 2 ) --Bill payment
	 BEGIN
		 SELECT POB.id as id,
				POB.PurchaseOrderNo,
				AL.UserName,
				POB.TotalPrice as netTotal,
				POB.BillDate,
				POB.CreatedDateTime

		 FROM [csh.PurchaseOrderBilled] POB
		 INNER JOIN [msd.ApplicationUserLogInDetails] AL ON AL.UserId = POB.CreatedUserId
	 END

	 IF(@cancellationTypeId = 3 ) --purchase Order
	 BEGIN
		 
		 UPDATE [stk.PurchaseOrder]
		 SET isCancelled = @Cancelled
		 WHERE PurchaseNo = @id
		
	 END

	 INSERT INTO [msd.Cancellation]
	 (
		CancellationTypeId,
		ReferenceNumber,
		CreatedUserId

	 ) 
	 VALUES (
		@cancellationTypeId,
		@id,
		@userId
	 )
	 
END 

GO
