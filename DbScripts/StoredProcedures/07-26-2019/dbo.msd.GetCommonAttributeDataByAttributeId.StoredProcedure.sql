USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetCommonAttributeDataByAttributeId]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetCommonAttributeDataByAttributeId]
	@AttributeId INT
AS
BEGIN
		SELECT CD.Id as DataId,
				CD.Value as Data,
				CD.AttributeId as AttributeId
		 FROM [msd.CommonAttributeData] CD
		WHERE CD.AttributeId = @AttributeId
END
GO
