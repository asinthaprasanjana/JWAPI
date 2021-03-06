USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetDocumentIdByDocumentTypeId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetDocumentIdByDocumentTypeId]
(
  @DocumentTypeId SMALLINT,
  @NewNumber VARCHAR(20) OUTPUT
)

	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  DECLARE @Text VARCHAR(10),
	          @Number INT,
			  @Id INT,
			--  @NewNumber VARCHAR(20) ='',
			  @DocId  VARCHAR(20),
			  @Length SMALLINT,
			  @Count  SMALLINT = 0,
			  @Difference SMALLINT = 0,
			  @NumberDataLength SMALLINT

	SET NOCOUNT ON;

	SELECT TOP 1
	@Id = DT.Id,
	@Text= DT.Text ,
	@Length = LEN(DT.Number),
	@Number = CONVERT(int, DT.Number),
	@NumberDataLength = LEN (CONVERT(int,DT.Number))
	FROM [msd.DocumentTypeDetails] DT
	WHERE DT.DocumentTypeId = @DocumentTypeId
	ORDER BY DT.CreatedDateTime DESC

	SET @Number = @Number +1;
	SET @Difference = @Length - @NumberDataLength

	IF(@Difference>0)
	   BEGIN
	        WHILE ( @Count<  @Difference)
			  BEGIN
			  	     SET @NewNumber = @NewNumber+ '0' 

			     SET @Count = @Count+1;
			  END
		 SET @NewNumber =  @NewNumber+ CONVERT(VARCHAR, @Number)

		  UPDATE [msd.DocumentTypeDetails] 
	      SET Number = @NewNumber
	      WHERE DocumentTypeId = @DocumentTypeId AND Id = @Id

		SET @NewNumber = @Text+ @NewNumber 
		SELECT @NewNumber AS 'Id'

	   END
	ELSE 
	  BEGIN
	  		SET @NewNumber =  @Number 

	     UPDATE [msd.DocumentTypeDetails] 
	      SET Number = @NewNumber
	      WHERE DocumentTypeId = @DocumentTypeId AND Id = @Id
		  		SET @NewNumber = @Text+ @NewNumber 

		SELECT @NewNumber AS 'DocumentNo'
	  END


	--  RETURN @NewNumber
END
GO
