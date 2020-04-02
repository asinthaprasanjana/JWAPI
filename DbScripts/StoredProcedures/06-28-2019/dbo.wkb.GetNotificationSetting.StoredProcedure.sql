USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.GetNotificationSetting]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.GetNotificationSetting]
(
	@CompanyId int
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	DBCC DROPCLEANBUFFERS


	
	SELECT 
		NS.NotificationId,

		NS.NotificationName,
		NS.Status,
		NS.CreatedUserId,
		NS.CreatedDateTime
	FROM [dbo].[wkb.notificationSetting] NS
	INNER  JOIN [usm.ApplicationUser] AP on AP.UserID =NS.CreatedUserId
	WHERE NS.CompanyId = @CompanyId
	

END
GO
