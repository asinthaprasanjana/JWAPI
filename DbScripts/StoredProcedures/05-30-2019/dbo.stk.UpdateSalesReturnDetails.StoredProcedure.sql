USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateSalesReturnDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
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
   @CreatedUserId SMALLINT,
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
