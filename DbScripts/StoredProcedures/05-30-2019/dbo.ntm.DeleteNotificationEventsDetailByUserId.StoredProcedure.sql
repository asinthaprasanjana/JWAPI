USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[ntm.DeleteNotificationEventsDetailByUserId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ntm.DeleteNotificationEventsDetailByUserId]
(
@UserId int
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		DELETE FROM [ntm.NotificationEvents]
		 WHERE UserId =@UserId
	
	
END
GO
