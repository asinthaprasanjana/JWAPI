USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.AddNotificationSetting]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.AddNotificationSetting]
(	
  @NotificationId INT,
  @CompanyId INT,
  @NotificationName NVARCHAR(150),
  @Status TINYINT,
  @CreatedUserId INT,
  @CreatedDateTime DATETIME,
  @CategoryId INT,
  @CategoryName NVARCHAR(100)

)

AS
BEGIN
		INSERT INTO [dbo].[wkb.notificationSetting]
			(
				[NotificationId]
			   ,[CompanyId]
			   ,[NotificationName]
			   ,[Status]
			   ,[CreatedUserId]
			   ,[CreatedDateTime]
			   ,[CategoryId]
			   ,[CategoryName]
		   )
		values ( 
			@NotificationId,
			@CompanyId,
			@NotificationName,
			@Status,
			@CreatedUserId,
			@CreatedDateTime,
			@CategoryId,
			@CategoryName
		 )
END
GO
