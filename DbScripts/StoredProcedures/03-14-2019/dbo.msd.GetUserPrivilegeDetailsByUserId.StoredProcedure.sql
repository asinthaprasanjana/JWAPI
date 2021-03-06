USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetUserPrivilegeDetailsByUserId]    Script Date: 14/03/2019 11:47:02 AM ******/
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
@UserId INT
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
