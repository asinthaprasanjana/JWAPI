USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetProductDetailsByProductId]    Script Date: 16/05/2019 12:39:09 PM ******/
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
@ProductId INT
)	
AS
BEGIN
	SELECT *
	FROM msd_Product P
	WHERE P.ProductId = @ProductId 
	
END
GO
