USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.AddNewApprovalEventDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.AddNewApprovalEventDetails]
(
@ReferenceNo VARCHAR(20),
@ApprovalTaskId  VARCHAR(20),
@UserId SMALLINT,
@ApprovalTypeId SMALLINT,
@NotificationTypeId SMALLINT,
@CreatedUserId SMALLINT 
)

AS
BEGIN

      DECLARE @ApprovalPendingStatus TINYINT =1,
	          @ApprovalName NVARCHAR(30),
			  @CompanyId INT = 1,
			  @IsActive TINYINT = 1,
			  @Header NVARCHAR(50) ,
			  @Message NVARCHAR(100),
			  @Url NVARCHAR(100),
			  @Seen TINYINT = 0;
			

			  SELECT @ApprovalName = AT.ApprovalName
			  FROM  [dbo].[wkb.ApprovalTypes] AT
			  WHERE  AT.ApprovalTypeId = @ApprovalTypeId

			  SELECT @Header =NS.Header,
			         @Message = NS.Message
					 FROM [ntm.NotificationSetting] NS
			        WHERE NS.NotificationTypeId = @NotificationTypeId
			 SET @Message = @Message + ''+ @ReferenceNo;
			   
	          
	INSERT INTO [dbo].[wkb.ApprovalEvents]
           (
			    [ReferenceNo]
			   ,[ApprovalTaskId]
			   ,[UserId]
			   ,[ApprovalTypeId]
			   ,[ApprovalTypeName]
			   ,[ApprovalSenderId]
			   ,[Status]
			   ,[CreatedUserId]
			   ,[CreatedDateTime]
		   )
		values ( 
			@ReferenceNo,
			@ApprovalTaskId,
			@UserId,
			@ApprovalTypeId,
			@ApprovalName,
			@CreatedUserId,
			@ApprovalPendingStatus,
			@CreatedUserId,
			GETDATE()
		 )

		 INSERT INTO [dbo].[ntm.NotificationEvents]
           ([CompanyId]
           ,[UserId]
           ,[ReferenceNo]
           ,[Header]
           ,[Message]
           ,[Url]
           ,[Seen]
           ,[IsActive]
           ,[Sender]
           ,[CreatedDateTime])

		 VALUES
		 (
		    @CompanyId,
			@UserId,
			@ReferenceNo,
			@Header,
			@Message,
            @Url,
			@Seen,
            @IsActive,
			@CreatedUserId,
			GETDATE()
		  )
END
GO
