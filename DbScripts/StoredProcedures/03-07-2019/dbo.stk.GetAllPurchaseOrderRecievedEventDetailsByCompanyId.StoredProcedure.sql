USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllPurchaseOrderRecievedEventDetailsByCompanyId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAllPurchaseOrderRecievedEventDetailsByCompanyId]
(
@CompanyId INT
)	
AS
BEGIN
	SELECT *
	FROM [dbo].[stk.PurchaseOrderRecievedEvents]
	WHERE CompanyId = @CompanyId
	
END
GO
