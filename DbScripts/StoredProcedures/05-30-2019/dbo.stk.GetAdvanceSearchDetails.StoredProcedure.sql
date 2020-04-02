USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAdvanceSearchDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAdvanceSearchDetails]
(
@BusinessPartnerId NVARCHAR(30),
@FromDate DATETIME,
@ToDate  DATETIME,
@BillStatus TINYINT,
@RecieveStatus TINYINT,
@Total INT,
@AdvanceSearchTypeId TINYINT

)

AS
BEGIN

		IF ( @AdvanceSearchTypeId = 1)
		BEGIN
		     IF(@BusinessPartnerId IS NOT NULL AND @FromDate IS NUll AND @BillStatus IS NULL AND @ToDate IS NULL AND @RecieveStatus IS NULL AND @Total IS NULL )
			  BEGIN
			   SELECT *
			   FROM [stk.PurchaseOrder] PO
			   WHERE PO.SupplierId = @BusinessPartnerId
			  END
			
		END

		ELSE
		BEGIN
     
		PRINT 'RR'
		END
END
GO
