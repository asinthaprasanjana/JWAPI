USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[ntm.updateNotificationTypeDetail]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ntm.updateNotificationTypeDetail]
(	
  @companyId INT,
  @roles VARCHAR(50),
  @isActive INT,
  @notificationType VARCHAR(50)
)

AS
BEGIN
	DECLARE @id TINYINT
	SELECT TOP 1 @id = id FROM [ntm.NotificationTypeDetails] NTD WHERE NTD.NotificationType =  @notificationType

	IF(@id IS NULL)
	BEGIN
		
		INSERT INTO [dbo].[ntm.NotificationTypeDetails]
		(
			CompanyId,
			NotificationType,
			RoleIds,
			IsActive
		)
		VALUES
		(
			@companyId,
			@notificationType,
			@roles,
			@isActive
		) 
	END

	IF(@id != 0 )
	BEGIN
		
		IF(@isActive = 0) 
		BEGIN
			UPDATE [dbo].[ntm.NotificationTypeDetails]
			SET 
			isActive = @isActive
			WHERE NotificationType = @notificationType

		END

		IF(@isActive = 1)
		BEGIN 
			UPDATE [dbo].[ntm.NotificationTypeDetails]
			SET 
			roleids = @roles,
			isActive = @isActive
			WHERE NotificationType = @notificationType
		END

	END

	SELECT *
	FROM [ntm.NotificationTypeDetails]
	WHERE NotificationType = @notificationType
END
GO
