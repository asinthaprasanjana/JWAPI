USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSupplierItem]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddSupplierItem]
	@ID CHAR(50),
	@ItemId INT,
	@ItemName VARCHAR(50),
	@BusinessPartnerId INT,
	@CreatedUserId SMALLINT,
	@CreatedDateTime DATETIME

	
	
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
