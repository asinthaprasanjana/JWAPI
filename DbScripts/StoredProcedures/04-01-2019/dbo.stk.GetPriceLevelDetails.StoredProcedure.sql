USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPriceLevelDetails]    Script Date: 01/04/2019 9:46:08 AM ******/
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
@UserId INT
)	
AS
BEGIN
	SELECT *
	FROM [stk.PriceLevel] PL
	WHERE PL.CreatedUserId = @UserId
	
END
GO
