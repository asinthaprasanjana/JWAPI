USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddPriceCategoryDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddPriceCategoryDetails]
	@Id INT,
	@CategoryId INT,
	@CategoryName Varchar(50),
	@CreatedUserId SMALLINT,
	@CreatedDateTime DateTime
	
		
AS
BEGIN

   -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		INSERT INTO [stk.PriceCategory]
		(	
			Id,
			CategoryId,
			CategoryName,
			CreatedUserId,
			CreatedDateTime
		) 
		values ( 
			@Id,
			@CategoryId,
			@CategoryName,
			@CreatedUserId,
			@CreatedDateTime
			 
		)

		
 
END
GO
