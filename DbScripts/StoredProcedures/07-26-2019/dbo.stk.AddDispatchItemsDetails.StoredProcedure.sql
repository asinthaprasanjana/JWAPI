USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddDispatchItemsDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddDispatchItemsDetails]
(
@DispatchTypeId INT,
@DocumentNumber VARCHAR(50),
@ProductId INT,
@ProductName VARCHAR(50),
@PackSizeId INT,
@PackSizeName VARCHAR(50),
@Quantity INT
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

IF(@DispatchTypeId = 1)
BEGIN
   INSERT INTO [dbo].[stk.DispatchItems]
           (
            [DocumentNumber]
           ,[ProductId]
           ,[ProductName]
           ,[PackSizeId]
           ,[PackSizeName]
           ,[Quantity])
     VALUES
           (
		   @DocumentNumber,
		   @ProductId,
		   @ProductName,
		   @PackSizeId,
		   @PackSizeName,
		   @Quantity
		   )
END
ELSE
BEGIN
INSERT INTO [dbo].[stk.GatePassItems]
           ([DocumentNumber]
           ,[ProductId]
           ,[ProductName]
           ,[Quantity]
           ,[PackSizeName]
           ,[PackSizeId])

		   VALUES(
		   @DocumentNumber,
		   @ProductId,
		   @ProductName,
		   @Quantity,
		   @PackSizeName,
		   @PackSizeId
		   )
END
END
GO
