USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.DeleteCommonAttributeData]    Script Date: 28/06/2019 4:49:03 PM ******/
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
