USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddPurchaseOrderReturnDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pasindu Sanjana
-- Create date: Create Date,
-- Description:	Description,
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddPurchaseOrderReturnDetails]
(
@CompanyId INT,
@SupplierId INT,
@BillLocationId INT ,
@ShipLocationId INT ,
@Email VARCHAR(50) ,
@ReturningTotal INT,
@Remarks VARCHAR(50) ,
@UserId SMALLINT
)



AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS

	DECLARE @lastId INT;

  INSERT INTO [dbo].[stk.PurchaseOrderReturnDetails]
           (
		    [SupplierId]
           ,[BillLocationId]
           ,[ShipLocationId]
           ,[Email]
		   ,[ReturningTotal]
           ,[Remarks]
		   ,[CompanyId]
           ,[CreatedUserId]
           ,[CreatedDateTime]
		   )
     VALUES
           ( 
			@SupplierId,
            @BillLocationId,
            @ShipLocationId,
            @Email,
			@ReturningTotal,
            @Remarks,
			@CompanyId,
            @UserId,
            GetDate()
			)
			SELECT @lastId=SCOPE_IDENTITY()
			SELECT PurchaseReturnId
			FROM [stk.PurchaseOrderReturnDetails]
			WHERE id = @lastId

END
GO
