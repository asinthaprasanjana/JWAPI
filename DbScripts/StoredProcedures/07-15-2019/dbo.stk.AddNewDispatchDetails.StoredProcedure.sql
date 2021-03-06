USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewDispatchDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddNewDispatchDetails]
(
@TypeId INT,
@BusinessPartnerId INT,
@DispatchTypeId INT,
@BusinessPartnerTypeId INT,
@ProductId INT,
@ProductName VARCHAR(50),
@Quantity INT,
@PackSizeName VARCHAR(50),
@PackSizeId INT,
@DocumentNumber VARCHAR(50),
@ReasonId INT,
@ReasonName VARCHAR(50),
@Comment VARCHAR(200),
@CreatedUserId INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@DispatchTypeId=1)
		BEGIN
			INSERT INTO [dbo].[stk.Dispatch]
					   (
						[DispatchTypeId]
					   ,[BusinessPartnerTypeId]
					   ,[ProductId]
					   ,[ProductName]
					   ,[Quantity]
					   ,[PackSizeName]
					   ,[PackSizeId]
					   ,[DocumentNumber]
					   ,[ReasonId]
					   ,[ReasonName]
					   ,[Comment]
					   ,[CreatedUserId]
					   ,[CreatedDateTime]
					   )
				 VALUES(
				 @DispatchTypeId,
				 @BusinessPartnerTypeId,
				 @ProductId,
				 @ProductName,
				 @Quantity,
				 @PackSizeName,
				 @PackSizeId,
				 @DocumentNumber,
				 @ReasonId,
				 @ReasonName,
				 @Comment,
				 @CreatedUserId,
				 GETDATE()
				 )
		END
ELSE
	BEGIN
	INSERT INTO [dbo].[stk.GatePass]
           ([TypeId]
           ,[BusinessPartnerId]
           ,[BusinessPartnerTypeId]
           ,[ProductId]
           ,[ProductName]
           ,[Quantity]
           ,[PackSizeName]
           ,[PackSizeId]
           ,[CreatedUserId]
           ,[CreatedDateTime])
     VALUES(
	     @TypeId,
		 @BusinessPartnerId,
		 @BusinessPartnerTypeId,
		 @ProductId,
		 @ProductName,
		 @Quantity,
		 @PackSizeName,
		 @PackSizeId,
		 @CreatedUserId,
		 GETDATE()
	 )
	END        

END
GO
