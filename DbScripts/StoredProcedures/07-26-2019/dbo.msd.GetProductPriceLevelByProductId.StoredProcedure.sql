USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetProductPriceLevelByProductId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetProductPriceLevelByProductId]
(
@ProductId INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 500
	PL.Id,
	Pl.ProductId,
	PL.PriceLevelName,
	AU.UserName,
	 CONVERT(VARCHAR(19), PL.CreatedDateTime, 100)  AS 'Date'	
	FROM [dbo].[msd.ProductPriceLevel] PL
	INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserId = PL.CreatedUserId
	WHERE ProductId = @ProductId
	ORDER BY PL.Id DESC

END
GO
