USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddDocumentNumberDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
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
GO
