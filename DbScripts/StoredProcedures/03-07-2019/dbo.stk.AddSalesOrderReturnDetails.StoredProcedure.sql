USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSalesOrderReturnDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pasindu Sanjana
-- Create date: Create Date,
-- Description:	Description,
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddSalesOrderReturnDetails]
(
@SaleNo nvarchar(50),
@CompanyId INT,
@CustomerId INT,
@BillLocationId INT ,
@ShipLocationId INT ,
@CurrencyId INT ,
@Email NVARCHAR(50) ,
@ReturningTotal INT,
@Remarks NVARCHAR(50) ,
@LastModifiedUserId INT,
@UserId INT
)



AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS

	DECLARE @lastId INT;

  INSERT INTO [dbo].[stk.SalesOrderReturnDetails]
           (
		    [SaleNo]
		   ,[CustomerId]
           ,[BillLocationId]
           ,[ShipLocationId]
           ,[CurrencyId]
           ,[Email]
		   ,[ReturningTotal]
           ,[Remarks]
		   ,[CompanyId]
           ,[CreatedUserId]
           ,[CreatedDateTime]
           ,[LastModifiedUserId]
           ,[LastModifiedDateTime])
     VALUES
           ( 
		    @SaleNo,
			@CustomerId,
            @BillLocationId,
            @ShipLocationId,
            @CurrencyId,
            @Email,
			@ReturningTotal,
            @Remarks,
			@CompanyId,
            @UserId,
            GetDate(),
            @UserId,
            GetDate())

			SELECT @lastId=SCOPE_IDENTITY()
			SELECT SalesReturnId
			FROM [stk.SalesOrderReturnDetails]
			WHERE id = @lastId

END
GO
