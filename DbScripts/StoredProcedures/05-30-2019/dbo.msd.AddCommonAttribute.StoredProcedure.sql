USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddCommonAttribute]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[msd.AddCommonAttribute]
(

 @AttributeName VARCHAR(100),
 @Type VARCHAR(40),
 @showAttribute TINYINT


)
AS
BEGIN
		DECLARE @id INT

INSERT INTO [dbo].[msd.CommonAttributes]
           ([AttributeName]
           ,[Type]
		   ,[showAttribute])
     VALUES
		( 
		   @AttributeName,
		   @Type,
		   @showAttribute
		)

		SELECT @id= SCOPE_IDENTITY() 

		SELECT *
		FROM [msd.CommonAttributes] CA
		WHERE  CA.Id = @id

END
GO
