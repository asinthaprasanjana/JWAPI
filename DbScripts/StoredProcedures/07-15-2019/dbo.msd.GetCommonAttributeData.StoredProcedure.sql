USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetCommonAttributeData]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetCommonAttributeData]

@AttributeId INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT CD.Id as dataId,CD.AttributeId,CD.Value as Data
	FROM [msd.CommonAttributeData] CD
	WHERE CD.AttributeId = @AttributeId

END 
GO
