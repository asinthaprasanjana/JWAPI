USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPriceCategoryDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
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
