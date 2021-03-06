USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateSalesReturnDetails]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdateSalesReturnDetails]
(
  @OrderId INT,
   @CreatedUserId INT,
   @CreatedDateTime DATETIME
)	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM [stk.SalesReturn] WHERE OrderId = @OrderId
	UPDATE [stk.SalesReturn] SET
	    
		OrderId = @OrderId,
        CreatedUserId = @CreatedUserId,
		CreatedDateTime = @CreatedDateTime
	    WHERE  OrderId = @OrderId
	
	SELECT * FROM [stk.SalesReturn] WHERE OrderId = @OrderId

END
GO
