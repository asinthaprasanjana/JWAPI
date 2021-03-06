USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdatePurchaseOrderIssueStatusByPurchaseNo]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdatePurchaseOrderIssueStatusByPurchaseNo]
	@PurchaseNo VARCHAR (MAX),
	@UserId     INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @IssuedStatus TINYINT = 1;
	SET NOCOUNT ON;

     UPDATE [stk.PurchaseOrder] 
	 SET 
	 Status = @IssuedStatus,
	 LastModifiedUserId = @UserId,
	 LastModifiedDateTime = GETDATE()
	 WHERE  PurchaseNo IN (SELECT * FROM dbo.splitstring(@PurchaseNo))

END
GO
