USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[rptstk.GetReportDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rptstk.GetReportDetails]
(
@ReportTypeId INT,
@BranchId INT,
@FromDate DATETIME,
@ToDate DATETIME
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

IF(@ReportTypeId = 1)
	BEGIN

		SELECT 
		  CASE PO.[Billed] 
				 WHEN 0 THEN 'Pending Billed'
				 WHEN 1 THEN 'Fully Billed'
				 WHEN 2 THEN 'Partially Billed'
			  END  AS 'Reference1',
		 COUNT(PO.Billed) AS Reference2
		FROM [dbo].[stk.PurchaseOrder] PO
		GROUP BY PO.Billed
	END

ELSE IF(@ReportTypeId=2)
	BEGIN

	 SELECT 
	 CASE PO.Recieved
		WHEN 0 THEN 'Pending Recieved'
		WHEN 1 THEN 'Fully Recieved'
		WHEN 2 THEN 'Partially Recieved'
		END AS 'Reference1',
	 COUNT(PO.Recieved) AS Reference2
	 FROM [dbo].[stk.PurchaseOrder] PO
	 GROUP BY PO.Recieved

	END

ELSE IF(@ReportTypeId=3)
	BEGIN

	SELECT 
	CASE PO.ApprovalStatus 
	    WHEN 0 THEN 'Pending Approval Status'
		WHEN 1 THEN 'Full Approval Status'
		WHEN 2 THEN 'Partial Approval Status'
	END AS 'Reference1'
	,COUNT(PO.ApprovalStatus) AS Reference2
	FROM [dbo].[stk.PurchaseOrder] PO
	GROUP BY PO.ApprovalStatus

	END
ELSE IF(@ReportTypeId=4)
	BEGIN
	 
	SELECT 
		CASE PO.Status
		 WHEN 0 THEN 'Not Issued'
		 WHEN 1 THEN 'Issued'
		 END AS 'Reference1',
	   COUNT(PO.Status) AS Reference2
	FROM [dbo].[stk.PurchaseOrder] PO
	GROUP BY PO.Status

	END

ELSE IF(@ReportTypeId=5)
	BEGIN

		SELECT 
			 CASE PO.IsCancelled
			 WHEN 0 THEN 'Active'
			 WHEN 1 THEN 'Canceled'
			 END AS 'Reference1',
			 COUNT(PO.IsCancelled) AS Reference2
		FROM [dbo].[stk.PurchaseOrder] PO
		GROUP BY PO.IsCancelled

	END

ELSE IF(@ReportTypeId=6)
	BEGIN

	SELECT 
		CASE PO.TempRecieved
		WHEN 0 THEN 'Pending Temporary Recieved'
		WHEN 1 THEN 'Fully Temporary Recieved'
		END AS 'Reference1',
		COUNT(PO.TempRecieved) AS 'Reference2'
	FROM [dbo].[stk.PurchaseOrder] PO
	WHERE PO.Recieved = 0 AND PO.QcAvailable=1
	GROUP BY PO.TempRecieved

	END

ELSE IF(@ReportTypeId=7)
	BEGIN
	 PRINT('aaaa')
	END

ELSE IF(@ReportTypeId=8)
	BEGIN
	 PRINT('vvv')
	END

ELSE
	BEGIN
	PRINT('ERROR')
	END

END 
GO
