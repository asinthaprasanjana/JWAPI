USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddPurchaseOrderReturnItem]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pasindu Sanjana>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddPurchaseOrderReturnItem]
	@ItemId INT,
	@ReturningQuantity INT,
	@PurchaseOrderReturnId INT,
	@ReturningPrice money,
	@UserId SMALLINT,
	@CompanyId INT,
	@Reason varchar(20)

		
AS
BEGIN


		INSERT INTO [stk.PurchaseOrderReturnItems]
		(	
		    CompanyId,
			PurchaseOrderReturnId,
			ProductId,
			ReturningQuantity,
			ReturningPrice,
			Reason,
			CreatedUserId,
			CreatedDateTime
		) 
		values ( 
		    @CompanyId,
			@PurchaseOrderReturnId,
			@ItemId ,
			@ReturningQuantity ,
			@ReturningPrice,
			@Reason,
			@UserId ,
			GETDATE()	 
		)

 
END
GO
