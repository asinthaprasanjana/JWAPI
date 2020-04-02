USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[stk.AddStockDetails]
	@ID nchar(50),
	@CompanyId nchar(50),
	@TransactionId nchar(50)

	
	
AS
BEGIN
		INSERT INTO stk.StockDetails
		(
			Id,
			CompanyId,
			TransactionId
		) 
		values 
		( 
				@ID ,
				@CompanyId ,
				@TransactionId 	  
		)
END
GO
