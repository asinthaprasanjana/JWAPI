USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[rptstk.GetAllPurchaseOrderReportDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[rptstk.GetAllPurchaseOrderReportDetails]

	
AS
BEGIN
	SELECT *
	FROM [dbo].[rptstk.PurchaseOrderReport] PR
	
	
END
GO
