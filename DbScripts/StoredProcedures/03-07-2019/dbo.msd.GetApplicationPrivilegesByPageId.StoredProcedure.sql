USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetApplicationPrivilegesByPageId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetApplicationPrivilegesByPageId]
	@PageId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT
	AP.PrivilegeId,
	AP.PrivilegeName
	FROM dbo.[msd.ApplicationPrivileges] AP
	WHERE AP.PageId=@PageId
	ORDER BY CreatedDateTime ASC

	
	
END
GO
