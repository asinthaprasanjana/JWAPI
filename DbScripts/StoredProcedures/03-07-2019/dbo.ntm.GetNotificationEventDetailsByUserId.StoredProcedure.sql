USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[ntm.GetNotificationEventDetailsByUserId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ntm.GetNotificationEventDetailsByUserId]
	(
	   @UserId INT 
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[ntm.NotificationEvents] WHERE UserId = @UserId
END
GO
