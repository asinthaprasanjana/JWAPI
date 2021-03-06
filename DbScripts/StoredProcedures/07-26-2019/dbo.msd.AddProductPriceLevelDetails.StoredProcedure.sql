USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddProductPriceLevelDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddProductPriceLevelDetails]
(
@ProductId INT,
@PriceLevelName VARCHAR(50),
@UserId INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Id INT

    -- Insert statements for procedure here

	    IF EXISTS ( SELECT 1 FROM  [msd.ProductPriceLevel] WHERE PriceLevelName = @PriceLevelName )
		   BEGIN
		      RAISERROR('This Name is already exists',16,1);
			  RETURN 0;

		   END

	INSERT INTO [dbo].[msd.ProductPriceLevel]
           ([ProductId]
           ,[PriceLevelName]
           ,[CreatedUserId]
           ,[CreatedDateTime])
     VALUES(
	   @ProductId,
	   @PriceLevelName,
	   @UserId,
	   GETDATE()     
	 )

	 SET @Id = SCOPE_IDENTITY()

	 SELECT @Id AS 'Id'

END
GO
