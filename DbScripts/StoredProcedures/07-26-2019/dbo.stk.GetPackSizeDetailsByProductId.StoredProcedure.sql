USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetPackSizeDetailsByProductId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetPackSizeDetailsByProductId]
(
@ProductId INT
)	
AS
BEGIN
	SELECT 
		PPS.PackSizeId,
		PPS.ProductId,
		PPS.PackSizeName,
		PPS.PackQty,
		PPS.CreatedUserId,
		PPS.CreatedDate
	FROM [msd_ProductPackSize] PPS
	WHERE PPS.ProductID = @ProductId 
	
END
GO
