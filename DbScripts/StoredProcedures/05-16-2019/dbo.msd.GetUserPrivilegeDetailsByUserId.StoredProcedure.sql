USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetUserPrivilegeDetailsByUserId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetUserPrivilegeDetailsByUserId]
(
@UserId SMALLINT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
		AUPD.UserId,
		AUPD.PrivilegeId AS PrivilegesId
		
	FROM [msd.ApplicationUserPrivilegesDetails] AUPD
	WHERE AUPD.UserId = @UserId
END 
GO
