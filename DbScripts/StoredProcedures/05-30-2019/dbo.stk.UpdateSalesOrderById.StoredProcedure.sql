USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateSalesOrderById]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdateSalesOrderById]
(
@SaleNo VARCHAR(20),
@GrossTotal MONEY,
@Tax    MONEY,   
@Discount  MONEY,
@NetTotal  MONEY,
@UserId SMALLINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS( SELECT ID FROM  [stk.SalesOrderDraftDetails]  Where SaleNo = @SaleNo)
	    BEGIN TRY
	---	BEGIN TRANSACTION

			DECLARE @LastInsertedSalesID			INT,
		            @LastInsertedSalesNo			NVARCHAR(30),
					@ErrorMessage					NVARCHAR(200),
					@ErrorSeverity					INT,  
					@ErrorState						INT,
					@SalesOrderApprovalTypeId       SMALLINT = 8,
					@ApprovalStatus                 TINYINT,
					@CompanyId						TINYINT = 1;
;  
			UPDATE [stk.SalesOrderDraftDetails] SET
					   GrossTotal = @GrossTotal,
					   Tax = @Tax,
					   Discount= @Discount,
					   NetTotal = @NetTotal,
					   LastModifiedUserId = @UserId
					   WHERE SaleNo = @SaleNo;

					     IF EXISTS (SELECT 1 FROM [wkb.ApprovalTypes] AT WHERE AT.ApprovalTypeId = @SalesOrderApprovalTypeId AND AT.IsActive = 1)
						   BEGIN 
							 SET @ApprovalStatus =1;
						   END

				   ELSE
						 BEGIN
						 SET @ApprovalStatus = 0;
						 END

			INSERT INTO [dbo].[stk.SalesOrder]
					   ([CompanyId]
					   ,[CustomerId]
					   ,[BillLocationId]
					   ,[ShipLocationId]
					   ,[PayementDue]
					   ,[CurrencyId]
					    ,[ApprovalStatus]
					   ,[GrossTotal]
					   ,[NetTotal]
					   ,[Tax]
					   ,[Discount]
					   ,[Invoiced]
					   ,[CreditPeriod]
					   ,[Email]
					   ,[Remarks]
					   ,[CreatedUserId]
					   ,[CreatedDateTime]
					   ,[LastModifiedUserId]
					   ,[LastModifiedDateTime])
			   (
					   SELECT
						SO.CompanyId,
						SO.CustomerId,
						SO.BillLocationId,
						SO.ShipLocationId,
						SO.PayementDue,
						SO.CurrencyId,
						@ApprovalStatus,
						SO.GrossTotal,
						SO.NetTotal,
						SO.Tax,
						SO.Discount,
						SO.Invoiced,
						SO.CreditPeriod,
						SO.Email,
						SO.Remarks,
						@UserId,
						GETDATE(),
						@UserId,
						GETDATE()
						FROM [stk.SalesOrderDraftDetails] SO
						WHERE SO.SaleNo = @SaleNo);
			SELECT	@LastInsertedSalesID = SCOPE_IDENTITY() 

			   SELECT @LastInsertedSalesNo = SO.SaleNo 
			    FROM [stk.SalesOrder] SO WHERE SO.Id = @LastInsertedSalesID
			
			INSERT INTO [dbo].[stk.SalesOrderItems]
					   ([Id]
					   ,[CompanyId]
					   ,[SaleNo]
					   ,[ProductId]
					   ,[ProductName]
					   ,[Quantity]
					   ,[ItemCost]
					   ,[Discount]
					   ,[Tax]
					   ,[TotalCost]
					   ,[Status]
					   ,[CreatedUserId]
					   ,[CreatedDateTime]
					   ,[LastModifiedUserId]
					   ,[LastModifiedDateTime])

			(		   SELECT
					   SOD.Id,
					   SOD.CompanyId,
					   @LastInsertedSalesNo,
					   SOD.ProductId,
					   SOD.ProductName,
					   SOD.Quantity,
					   SOD.ItemCost,
					   SOD.Discount,
					   SOD.Tax,
					   SOD.TotalCost,
					   SOD.Status,
					   @UserId,
						 GETDATE(),
					   @UserId,
						 GETDATE()
					   FROM [dbo].[stk.SalesOrderItemsDraftDetails]SOD
					   WHERE SOD.SaleNo = @SaleNo);

			DELETE	[stk.SalesOrderItemsDraftDetails]
			FROM [dbo].[stk.SalesOrderItemsDraftDetails]SOD
			WHERE SOD.SaleNo=@SaleNo
			
			  SELECT @LastInsertedSalesNo = SO.SaleNo 
			    FROM [stk.SalesOrder] SO WHERE SO.Id = @LastInsertedSalesID
			  SELECT @LastInsertedSalesNo AS 'SaleNo'

                 
         --  COMMIT TRANSACTION
	    END TRY

		BEGIN CATCH 

	--	ROLLBACK TRANSACTION
		 SET @ErrorMessage  = ERROR_MESSAGE()
         SET @ErrorSeverity = ERROR_SEVERITY()
         SET @ErrorState    = ERROR_STATE()
    RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
		END CATCH
    ELSE
     BEGIN
	      RAISERROR('This Sales Order Details Does Not Exists!', 16, 1);
	 END
END
GO
