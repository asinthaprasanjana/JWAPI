USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewSalesReturnDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
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
