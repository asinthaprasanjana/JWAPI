USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewSalesReturnDetails]    Script Date: 16/05/2019 12:39:09 PM ******/
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
