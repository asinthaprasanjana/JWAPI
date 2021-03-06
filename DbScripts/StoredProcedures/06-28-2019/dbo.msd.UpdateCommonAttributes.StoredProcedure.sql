USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateCommonAttributes]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UpdateCommonAttributes]
(
@Id INT,
@AttributeName VARCHAR(50),
@Type VARCHAR(20),
@showAttribute TINYINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [msd.CommonAttributes]  SET
			AttributeName = @AttributeName,
			Type = @Type,
			[showAttribute] = @showAttribute
      
	WHERE Id = @Id
END 
GO
