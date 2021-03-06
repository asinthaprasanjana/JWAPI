USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddPurchaseOrderRequest]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddPurchaseOrderRequest]
	(
	   @Remarks nvarchar(100),
	   @CreatedUserId SMALLINT
	)
AS
BEGIN

       DECLARE  @ReturnId INT,
	            @BranchId INT ;

	SELECT @BranchId =A.BranchID
	 FROM [msd.ApplicationUserDetails] a 
	 WHERE UserId = @CreatedUserId

		INSERT INTO [dbo].[stk.PurchaseOrderRequests]
           (
	        [Remarks]
           ,[CreatedUserId]
           ,[CreatedDateTime]
		   ,[BranchId]

		   )

     VALUES
           (
            @Remarks,
            @CreatedUserId, 
            GETDATE(),
			@BranchId

		   )



	 SET @ReturnId = SCOPE_IDENTITY()
	 SELECT PO.PurchaseNo AS 'PurchaseNo'
	 FROM [stk.PurchaseOrderRequests] PO
	 WHERE PO.Id =@ReturnId


	
END
GO
