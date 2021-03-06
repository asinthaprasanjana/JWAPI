USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddApplicationPage]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddApplicationPage]
	@PageName varchar(30),
	@RouterLink varchar(40),
	@Icon varchar(30),
	@IsActive TINYINT,
	@IsMainMenu tinyint,
	@PriorityNo SMALLINT,
	@MainMenuId SMALLINT,
	@ExpirationDate DATETIME

AS
BEGIN

      IF NOT EXISTS (SELECT 1 FROM [msd.ApplicationPages] WHERE RouterLink = @RouterLink)
	    BEGIN
		
		IF ( @IsMainMenu = 0)
		    BEGIN
			   IF NOT EXISTS (SELECT 1 FROM [msd.ApplicationPages] WHERE Id = @MainMenuId )
			       BEGIN
				   		  	RAISERROR('Invalid Main Menu Id', 16, 1);
							RETURN 0
				   END
			END
		INSERT INTO [msd.ApplicationPages]
		(	
				PageName,
				RouterLink,
				Icon,
				IsActive,
				PriorityNo,
				IsMainMenu,
				MainMenuId	,
				ExpirationDate				 
		) 
		values 
		( 
			@PageName,
			@RouterLink,
			@Icon,
			@IsActive,
			@PriorityNo,
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
