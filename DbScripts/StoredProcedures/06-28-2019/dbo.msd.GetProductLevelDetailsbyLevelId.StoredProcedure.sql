USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetProductLevelDetailsbyLevelId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetProductLevelDetailsbyLevelId]
(
 @LevelNo SMALLINT,
 @ParentId VARCHAR(1000)
-- @IsForFreezing BIT
 )
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 --  IF ( @IsForFreezing = 0)
	     BEGIN
		   IF  (LEN (@ParentId) <1) AND (@LevelNo>2)
	     BEGIN
		  RETURN 0
		 END

	       IF( LEN( @ParentId) > 0 AND @LevelNo>-1)
	     BEGIN
		  

		   SELECT 
		   PL.Id,
		   PL.ParentLevelId AS 'ParentLevelId',
		   PL.Level,
		   PL.AttributeName
		    FROM [msd.ProductLevels] PL 
		   WHERE PL.ParentLevelId IN ( SELECT * FROM dbo.splitstring(@ParentId)) AND PL.Level = @LevelNo
		   ORDER BY PL.ParentLevelId

		 END

	       IF( LEN(@ParentId) <0 AND @LevelNo > -1 )
	   BEGIN
	   		   

	     SELECT 
		   PL.Id,
		   PL.ParentLevelId AS 'ParentLevelId',
		   Pl.Level,
		   PL.AttributeName
		   FROM [msd.ProductLevels] PL WHERE PL.Level = @LevelNo
		   ORDER BY PL.ParentLevelId

	   END
	    
	       IF( LEN(@ParentId) > 0 AND @LevelNo = -1 )
		BEGIN
				   

		SELECT 
		   PL.Id,
		   PL.ParentLevelId AS 'ParentLevelId',
		   Pl.Level,
		   PL.AttributeName
		   FROM [msd.ProductLevels] PL WHERE PL.ParentLevelId = @ParentId
		   ORDER BY PL.ParentLevelId

		END
		 END
	--   ELSE

	   --   BEGIN
		  --SELECT
		  -- PL.Id,
		  -- PL.ParentLevelId AS 'ParentLevelId',
		  -- PL.Level,
		  -- PL.AttributeName
		  --  FROM [msd.ProductLevels] PL 
		  -- WHERE PL.ParentLevelId IN ( SELECT * FROM dbo.splitstring(@ParentId)) AND PL.Level = @LevelNo
		  -- ORDER BY PL.ParentLevelId 

		--  END
	 
	
	
END 
GO
