USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[ntm.UpdateUserNotificationReadByUserId]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ntm.UpdateUserNotificationReadByUserId]
(
  @UserId int
 
 )

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Seen TINYINT = 1;

	UPDATE  [dbo].[ntm.NotificationEvents] SET
		 Seen = @Seen
	    WHERE UserId = @UserId

END
GO
