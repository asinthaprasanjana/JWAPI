USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPriceLevelDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPriceLevelDetails]
(
@UserId SMALLINT
)	
AS
BEGIN
	SELECT *
	FROM [stk.PriceLevel] PL
	WHERE PL.CreatedUserId = @UserId
	
END
GO
