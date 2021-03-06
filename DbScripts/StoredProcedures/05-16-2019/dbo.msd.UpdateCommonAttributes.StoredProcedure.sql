USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateCommonAttributes]    Script Date: 16/05/2019 12:39:09 PM ******/
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
@Values VARCHAR(1500),
@showAttribute TINYINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [msd.CommonAttributes]  SET
			AttributeName = @AttributeName,
			[Values] = @Values,
			[showAttribute] = @showAttribute
      
	WHERE Id = @Id

	SELECT * FROM [msd.CommonAttributes]
	WHERE Id = @Id
END 
GO
