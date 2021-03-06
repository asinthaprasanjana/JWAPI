USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSupplierItem]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[stk.AddSupplierItem]
	@ID nchar(50),
	@ItemId int,
	@ItemName nvarchar(50),
	@BusinessPartnerId int,
	@CreatedUserId nvarchar(30),
	@CreatedDateTime datetime

	
	
AS
BEGIN
		INSERT INTO stk.[stk.SupplierItems]
		(
			ID,
			ItemId,
			ItemName,
			BusinessPartnerId,
			CreatedUserId,
			CreatedDateTime
		) 
		values 
		( 
			@ID,
			@ItemId,
			@ItemName,
			@BusinessPartnerId,
			@CreatedUserId,
			@CreatedDateTime 
		)
END
GO
