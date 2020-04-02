USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewInvoiceDetails]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddNewInvoiceDetails]
(
            @CompanyId INT
           ,@BranchId SMALLINT
           ,@SupplierId VARCHAR(30)
           ,@BillLocationId INT
           ,@ShipLocationId INT
           ,@StockDue DATE
           ,@PayementDue DATE
           ,@CurrencyId INT
           ,@GrossTotal MONEY
           ,@Tax MONEY
           ,@Discount MONEY
           ,@NetTotal MONEY
           ,@ApprovalStatus TINYINT
           ,@Status VARCHAR(10)
           ,@Recieved TINYINT
           ,@Billed TINYINT
           ,@CreditPeriod INT
           ,@Email VARCHAR(50)
           ,@Remarks VARCHAR(100)
           ,@CreatedUserId SMALLINT
           ,@LastModifiedUserId SMALLINT
          
)	
	
AS
BEGIN
		INSERT INTO [dbo].[stk.PurchaseOrder]
           ([CompanyId]
           ,[BranchId]
           ,[SupplierId]
           ,[BillLocationId]
           ,[ShipLocationId]
           ,[StockDue]
           ,[PayementDue]
           ,[CurrencyId]
           ,[GrossTotal]
           ,[Tax]
           ,[Discount]
           ,[NetTotal]
           ,[ApprovalStatus]
           ,[Status]
           ,[Recieved]
           ,[Billed]
           ,[CreditPeriod]
           ,[Email]
           ,[Remarks]
           ,[CreatedUserId]
           ,[CreatedDateTime]
           ,[LastModifiedUserId]
           ,[LastModifiedDateTime])
     VALUES
		( 
			
            @CompanyId
           ,@BranchId
           ,@SupplierId
           ,@BillLocationId
           ,@ShipLocationId
           ,@StockDue
           ,@PayementDue
           ,@CurrencyId
           ,@GrossTotal
           ,@Tax
           ,@Discount
           ,@NetTotal
           ,@ApprovalStatus
           ,@Status
           ,@Recieved
           ,@Billed
           ,@CreditPeriod
           ,@Email
           ,@Remarks
           ,@CreatedUserId
		   ,GETDATE()
           ,@LastModifiedUserId 
		   ,GETDATE()
		)
END
GO
