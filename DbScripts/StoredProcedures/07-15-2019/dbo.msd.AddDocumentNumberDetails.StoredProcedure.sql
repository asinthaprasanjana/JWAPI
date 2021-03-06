USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddDocumentNumberDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddDocumentNumberDetails]
(
@DocumentTypeId SMALLINT,
@DocumentTypeName VARCHAR(100),
@Number SMALLINT,
@Text VARCHAR(100),
@UserId SMALLINT

)
	
AS
BEGIN

  
		

		IF EXISTS ( SELECT 1 FROM  [dbo].[msd.DocumentTypeDetails] DT WHERE DT.DocumentTypeId = @DocumentTypeId AND DT.Text = @Text AND CONVERT(INT, Number)  >= @Number )
		  BEGIN
		     	 RAISERROR('You can not use this format. Duplicated Document Number', 16, 1);
		  END
		ELSE
		  BEGIN
		  
          INSERT INTO [dbo].[msd.DocumentTypeDetails]
           (
		    [DocumentTypeId]
           ,[DocumentTypeName]
           ,[Number]
           ,[Text]
           ,[CreatedUserId]
		  )

     VALUES(
			 @DocumentTypeId,
			 @DocumentTypeName,
			 @Number,
			 @Text,
			 @UserId
	      )

		  END

	
END
GO
