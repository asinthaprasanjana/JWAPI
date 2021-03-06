USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddApplicationPage]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddApplicationPage]
	@PageName nvarchar(30),
	@RouterLink nvarchar(30),
	@Icon nvarchar(20),
	@IsMainMenu tinyint,
	@MainMenuId tinyint,
	@ExpirationDate DATETIME

AS
BEGIN

      IF NOT EXISTS (SELECT 1 FROM [msd.ApplicationPages] WHERE RouterLink = @RouterLink)
	    BEGIN
		
		INSERT INTO [msd.ApplicationPages]
		(	
				PageName,
				RouterLink,
				Icon,
				IsMainMenu,
				MainMenuId	,
				ExpirationDate				 
		) 
		values 
		( 
			@PageName,
			@RouterLink,
			@Icon,
			@IsMainMenu,
			@MainMenuId	,
			@ExpirationDate
		)

		END
	  ELSE
	    BEGIN
		  	RAISERROR('This Page Is Already Exists', 16, 1);

		END
END
GO
