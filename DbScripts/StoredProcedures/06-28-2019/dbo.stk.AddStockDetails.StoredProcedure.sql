USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddStockDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddStockDetails]
	@ID char(50),
	@CompanyId char(50),
	@TransactionId char(50)

	
	
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
