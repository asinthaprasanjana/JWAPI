USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPriceCategoryDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPriceCategoryDetails]
(
@UserId SMALLINT
)	
AS
BEGIN
	SELECT *
	FROM [stk.PriceCategory] PC
	WHERE PC.CreatedUserId = @UserId
	
END
GO
