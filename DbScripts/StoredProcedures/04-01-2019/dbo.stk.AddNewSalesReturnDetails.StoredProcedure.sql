USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewSalesReturnDetails]    Script Date: 01/04/2019 9:46:08 AM ******/
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
   @CreatedUserId INT,
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
