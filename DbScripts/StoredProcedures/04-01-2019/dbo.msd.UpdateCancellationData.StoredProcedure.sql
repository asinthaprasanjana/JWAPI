USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateCancellationData]    Script Date: 01/04/2019 9:46:08 AM ******/
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
	@isCancelled TINYINT,
	@userId smallint

)
AS
BEGIN

     IF(@cancellationTypeId = 1  ) --stock Transfer
	 BEGIN
		 UPDATE [stk.StockTransferSummeryDetails]
		 SET isCancelled = @isCancelled
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
		 SET isCancelled = @isCancelled
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
