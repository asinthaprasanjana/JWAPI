USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddCommonAttribute]    Script Date: 16/05/2019 12:39:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[msd.AddCommonAttribute]
(

 @AttributeName VARCHAR(50),
 @Values VARCHAR(1500),
 @showAttribute TINYINT


)
AS
BEGIN
		DECLARE @id INT

INSERT INTO [dbo].[msd.CommonAttributes]
           ([AttributeName]
           ,[Values]
		   ,[showAttribute])
     VALUES
		( 
		   @AttributeName,
		   @Values  ,
		   @showAttribute
		)

		SELECT @id= SCOPE_IDENTITY() 

		SELECT *
		FROM [msd.CommonAttributes] CA
		WHERE  CA.Id = @id

END
GO
