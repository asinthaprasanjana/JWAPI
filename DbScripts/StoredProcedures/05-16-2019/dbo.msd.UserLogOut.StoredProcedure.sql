USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UserLogOut]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UserLogOut]
(
@UserId SMALLINT

)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @IsLogedIn TINYINT  = 0;
		  RAISERROR ('DuplicateLogIn - ' , @UserId ,16,1 );


	UPDATE  [dbo].[msd.CurrentUserLoginDetails]
	SET
	[IsLogedIn] = @IsLogedIn
	WHERE UserId = @UserId

END
GO
