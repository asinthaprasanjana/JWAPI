USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetWareHouseDetailsByBranchId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetWareHouseDetailsByBranchId]
(
@BranchId INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM [msd.WareHouse]
	WHERE BranchId  = @BranchId


END
GO
