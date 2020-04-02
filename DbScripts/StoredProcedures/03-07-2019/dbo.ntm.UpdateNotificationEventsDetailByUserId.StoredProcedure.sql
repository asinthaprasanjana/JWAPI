USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[ntm.UpdateNotificationEventsDetailByUserId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ntm.UpdateNotificationEventsDetailByUserId]
(
  @Id INT,
  @IsActive TINYINT
 )

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	UPDATE  [dbo].[ntm.NotificationEvents] SET
		IsActive= @IsActive
	    WHERE Id = @Id

END
GO
