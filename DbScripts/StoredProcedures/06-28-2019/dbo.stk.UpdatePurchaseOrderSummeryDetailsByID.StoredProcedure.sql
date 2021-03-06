USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePurchaseOrderSummeryDetailsByID]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdatePurchaseOrderSummeryDetailsByID]
	@ID int,
	@PurchaseNO varchar(30),
	@BranchId int, 
	@SupplierId int, 
	@BillLocationId int,
	@ShipLocationId int,
	@StockDue date,
	@PaymentDue date,
	@CurrencyId int,
	@Status nvarchar(10),
	@Recieved tinyint,
	@Billed tinyint,
	@CreditPeriod int,
	@Email varchar(50),
	@Remarks varchar(100),
	@CreatedUserId smallint,
	@LastModifiedUserId smallint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	UPDATE [stk.PurchaseOrder] SET
		@ID=@ID,
		BranchId=@BranchId,
		SupplierId=@SupplierId,
		BillLocationId=@BillLocationId,
		ShipLocationId=@ShipLocationId,
		StockDue=@StockDue,
		PayementDue=@PaymentDue,
		CurrencyId=@CurrencyId,
		Status= @Status,
		Recieved=@Recieved,
		Billed=@Billed,
		Email=@Email,
		Remarks=@Remarks,
		CreatedUserId=@CreatedUserId,
		CreatedDateTime=GETDATE(),
		LastModifiedUserId=@LastModifiedUserId,
		LastModifiedDateTime= GETDATE()
	WHERE PurchaseNo =@PurchaseNO
	
	
END
GO
