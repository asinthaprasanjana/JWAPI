USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[ntm.AddNotificationEvents]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ntm.AddNotificationEvents]
(	
  @Id INT,
  @CompanyId INT,
  @UserId INT,
  @ReferenceNo NVARCHAR(15),
  @Header NVARCHAR(15),
  @Message NVARCHAR(200),
  @Url NVARCHAR(100),
  @Is TINYINT ,
  @Seen TINYINT ,
  @IsActive TINYINT,
  @Sender INT,
  @CreatedDateTime DATETIME

)

AS
BEGIN
	INSERT INTO [dbo].[ntm.NotificationEvents]
       (
		   [CompanyId]
           ,[UserId]
           ,[ReferenceNo]
           ,[Header]
           ,[Message]
           ,[Url]
           ,[Seen]
           ,[IsActive]
           ,[Sender]
		   ,[CreatedUserId]
           ,[CreatedDateTime]
		
		)

		values 
		( 
			@CompanyId,
			@UserId,
			@ReferenceNo,
			@Header,
			@Message,
			@Url,
			@Seen,
			@IsActive,
			@Sender,
			@Sender,
			GETDATE()
		
		 )
END
GO
