USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetProductDetailsById]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetProductDetailsById]
(
@ProductId INT 
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT *
	FROM [dbo].[msd_Product] P 
	WHERE P.ProductId = @ProductId
END 
GO
