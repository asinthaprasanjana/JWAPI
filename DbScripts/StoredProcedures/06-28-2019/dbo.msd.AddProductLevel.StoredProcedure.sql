USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddProductLevel]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.AddProductLevel]
	@ParentLevelId INT,
	@AttributeName VARCHAR(50),
	@Level INT
	
AS
BEGIN
		DECLARE @Id INT

		INSERT INTO [msd.ProductLevels]
		(
			ParentLevelId,
			AttributeName,
			Level
		) 
		values 
		( 
			@ParentLevelId,
			@AttributeName,
			@Level
		)

		SELECT @Id= SCOPE_IDENTITY() 
		SELECT id,
				ParentLevelId,
				AttributeName,
				Level
		FROM [msd.ProductLevels]
		WHERE Id = @Id
END
GO
