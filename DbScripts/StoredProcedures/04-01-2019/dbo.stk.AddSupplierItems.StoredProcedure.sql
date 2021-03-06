USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddSupplierItems]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[stk.AddSupplierItems]
(

 @ItemId INT,
 @Id int,
 @ItemName nvarchar(50),
 @BusinessPartnerId int,
 @CreatedUserId int,
 @CreatedDateTime datetime 
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		INSERT INTO [stk.SupplierItems]
		(
			Id,
			ItemId,
			ItemName,
			BusinessPartnerId,
			CreatedUserId,
			CreatedDateTime
		)
		VALUES
		(
			@Id,
			@ItemId,
			@ItemName,
			@BusinessPartnerId,
			@CreatedUserId,
			@CreatedDateTime
		)	
END 
GO
