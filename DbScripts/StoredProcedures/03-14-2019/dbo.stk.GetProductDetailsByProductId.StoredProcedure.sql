USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetProductDetailsByProductId]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetProductDetailsByProductId]
(
@ProductId INT,
@CompanyId INT
)	
AS
BEGIN
	SELECT *
	FROM dbo.Product pr
	WHERE pr.ProductID = @ProductId 
	
END
GO
