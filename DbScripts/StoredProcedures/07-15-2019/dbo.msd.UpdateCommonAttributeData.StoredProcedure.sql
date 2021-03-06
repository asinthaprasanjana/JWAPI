USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateCommonAttributeData]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UpdateCommonAttributeData]
(
@AttributeId INT,
@Value VARCHAR(50)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF EXISTS (SELECT 1 FROM [msd.CommonAttributeData] WHERE AttributeId= @AttributeId AND Value = @Value )
	   BEGIN
			UPDATE [msd.CommonAttributeData]
			SET Value = @Value,
				isDeleted = 0
			WHERE AttributeId = @AttributeId AND Value = @Value COLLATE Latin1_General_CS_AS 
	   END
	ELSE
		BEGIN
			INSERT INTO [msd.CommonAttributeData]
			(
				AttributeId,
				Value
			) 
			VALUES 
			( 
				@AttributeId,
				@Value
			)
		END
	  

END 
GO
