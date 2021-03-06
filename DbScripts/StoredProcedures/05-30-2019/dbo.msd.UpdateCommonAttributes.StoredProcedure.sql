USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateCommonAttributes]    Script Date: 30/05/2019 11:36:25 AM ******/
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
