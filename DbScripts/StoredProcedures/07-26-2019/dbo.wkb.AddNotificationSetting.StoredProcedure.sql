USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.AddNotificationSetting]    Script Date: 26/07/2019 10:10:01 AM ******/
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
  @NotificationName VARCHAR(150),
  @Status TINYINT,
  @CreatedUserId SMALLINT,
  @CreatedDateTime DATETIME,
  @CategoryId INT,
  @CategoryName VARCHAR(100)

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
