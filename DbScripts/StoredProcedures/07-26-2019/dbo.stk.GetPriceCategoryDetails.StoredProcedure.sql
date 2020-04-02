USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPriceCategoryDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
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
	
AS
BEGIN
    -- Important Note : Do not Change the Order By Clause 
	-- Stored Procedure Owner  - Ruchika Madhubhashitha

	SELECT Id,CategoryId,CategoryName
	FROM [dbo].[msd.PriceCategoryDetails]
	ORDER BY CategoryName
	
END
GO
