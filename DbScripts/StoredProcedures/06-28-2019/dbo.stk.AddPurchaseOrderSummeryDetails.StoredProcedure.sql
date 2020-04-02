USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddPurchaseOrderSummeryDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: Create Date,
-- Description:	Description,
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddPurchaseOrderSummeryDetails]
(
@CompanyId INT,
@PurchaseNo VARCHAR(20),
@BranchId  SMALLINT,
@SupplierId INT,
@StockDue DATE,
@PayementDue DATE,
@TotalsAre INT,
@BillTo INT ,
@ShipTo INT ,
@CurrencyId INT ,
@CreditPeriod INT ,
@Email NVARCHAR(50) ,
@Remarks NVARCHAR(50) ,
@CreatedUserId SMALLINT 
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS

	DECLARE @ApprovalStatus TINYINT = 0,
			@Recieved INT = 0 ,
			@LastPurchaseOrderId INT,
		    @Billed INT = 0 ;

  INSERT INTO [dbo].[stk.PurchaseOrderDraftDetails]
           (
            [BranchId]
           ,[SupplierId]
           ,[BillLocationId]
           ,[ShipLocationId]
           ,[StockDue]
           ,[PayementDue]
           ,[CurrencyId]
           ,[Status]
           ,[Recieved]
           ,[Billed]
           ,[CreditPeriod]
           ,[Email]
           ,[Remarks]
		   ,[CompanyId]
           ,[CreatedUserId]
           ,[CreatedDateTime]
           ,[LastModifiedUserId]
           ,[LastModifiedDateTime])
     VALUES
           ( 
          
            @BranchId,
            @SupplierId,
            @BillTo,
            @ShipTo,
            @StockDue,
			@PayementDue,
            @CurrencyId,
            @ApprovalStatus,
            @Recieved,
            @Billed,
            @CreditPeriod,
            @Email,
            @Remarks,
			@CompanyId,
            @CreatedUserId,
            GetDate(),
            @CreatedUserId,
            GetDate())
	
	  	SELECT @LastPurchaseOrderId= SCOPE_IDENTITY() 
		SELECT @LastPurchaseOrderId AS PurchaseNo

END
GO
