USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddPriceLevelDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddPriceLevelDetails]
	@Id INT,
	@PriceLevelId INT,
	@PriceLevelName Varchar(50),
	@CreatedUserId SMALLINT,
	@CreatedDateTime DateTime
	
		
AS
BEGIN

   -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		INSERT INTO [stk.PriceLevel]
		(	
			Id,
			PriceLevelId,
			PriceLevelName,
			CreatedUserId,
			CreatedDateTime
		) 
		values ( 
			@Id,
			@PriceLevelId,
			@PriceLevelName,
			@CreatedUserId,
			@CreatedDateTime
			 
		)

		
 
END
GO
