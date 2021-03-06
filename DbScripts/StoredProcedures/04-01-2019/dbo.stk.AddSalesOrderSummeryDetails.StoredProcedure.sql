USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesOrderSummeryDetails]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: Create Date,
-- Description:	Description,
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddSalesOrderSummeryDetails]
(
@SaleNo nvarchar(50),
@CompanyId INT,
@CustomerId INT,
@PaymentDue DATE,
@BillLocationId INT ,
@ShipLocationId INT ,
@CurrencyId INT ,
@CreditPeriod INT ,
@Email NVARCHAR(50) ,
@Remarks NVARCHAR(50) ,
@CreatedUserId INT, 
@GrossTotal MONEY, 
@Tax MONEY, 
@Discount MONEY,
@NetTotal MONEY,
@Status INT, 
@Invoiced INT,
@CreatedDAteTime Date,
@LastModifiedUserId INT,
@LastModifiedDateTime DATE
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS

	DECLARE @ApprovalStatus TINYINT = 0,
			@Recieved INT = 0 ,
			@LastSalesOrderId INT,
		    @InvoicedStatus INT = 0 ;

  INSERT INTO [dbo].[stk.SalesOrderDraftDetails]
           (
			[CustomerId]
           ,[BillLocationId]
           ,[ShipLocationId]
           ,[PayementDue]
           ,[CurrencyId]
           ,[Status]
           ,[Invoiced]
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
			@CustomerId,
            @BillLocationId,
            @ShipLocationId,
			@PaymentDue,
            @CurrencyId,
            @Recieved,
            @InvoicedStatus,
            @CreditPeriod,
            @Email,
            @Remarks,
			@CompanyId,
            @CreatedUserId,
            GetDate(),
            @CreatedUserId,
            GetDate())
	
		SELECT @LastSalesOrderId= SCOPE_IDENTITY() 
		SELECT @LastSalesOrderId AS SaleNo
END
GO
