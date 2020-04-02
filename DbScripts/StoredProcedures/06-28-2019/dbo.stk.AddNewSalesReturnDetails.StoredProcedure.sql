USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewSalesReturnDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddNewSalesReturnDetails]
(
   @OrderId INT,
   @CreatedUserId SMALLINT,
   @CreatedDateTime DATETIME

)	
	
AS
BEGIN
		INSERT INTO [dbo].[stk.SalesReturn]
		(
			OrderId,
			CreatedUserId,
			CreatedDateTime
		) 
		values 
		( 
			@OrderId,
			@CreatedUserId,
			@CreatedDateTime 
		)
END
GO
