USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.DeleteCommonAttributeData]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.DeleteCommonAttributeData]
	@AttributeId INT
AS
BEGIN
		UPDATE [msd.CommonAttributeData]
		SET isDeleted = 1
		WHERE AttributeId = @AttributeId
END
GO
