USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddDocumentNumberDetails]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddDocumentNumberDetails]
(
@DocumentTypeId INT,
@DocumentTypeName VARCHAR(100),
@Number INT,
@Text VARCHAR(100),
@UserId INT

)
	
AS
BEGIN

  --    IF NOT EXISTS (SELECT 1 FROM [msd.ApplicationPages] WHERE RouterLink = @RouterLink)
	--    BEGIN
		
	
INSERT INTO [dbo].[msd.DocumentTypeDetails]
           (
		    [DocumentTypeId]
           ,[DocumentTypeName]
           ,[Number]
           ,[Text]
           ,[UserId]
		  )

     VALUES(
			 @DocumentTypeId,
			 @DocumentTypeName,
			 @Number,
			 @Text,
			 @UserId
	      )

		--END
	 -- ELSE
	  --  BEGIN
		--  	RAISERROR('This Page Is Already Exists', 16, 1);

		--END
		--SELECT * FROM [msd.ApplicationPages]
END
GO
