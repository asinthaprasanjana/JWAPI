USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.AddNewApproveByApprovalId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[wkb.AddNewApproveByApprovalId]
(

	 @ApprovalTypeId INT,
	 @ReferenceNo VARCHAR(30),
	 @CreatedUserId SMALLINT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @ApprovalPendingStatus TINYINT = 1,
	        @CompanyId TINYINT =1 ,
			@LastApprovalTaskId  INT;

  BEGIN	TRY 
      BEGIN TRANSACTION

	  DECLARE 	 @ApprovalRecieversId VARCHAR(MAX);

	   SELECT  @ApprovalRecieversId = ATOD.ApprovalOfficersId 
	   FROM [wkb.ApprovalTypeOwnDetails] ATOD WHERE ATOD.ApprovalTypeId = @ApprovalTypeId

	  INSERT INTO [dbo].[wkb.ApprovalTask]
			   (
					[CompanyId],
					[ReferenceNo]
				   ,[ApprovalTypeId]
				   ,[ApprovalSenderId]
				   ,[ApprovalRecieversId]
				   ,[Status]
				   ,[CreatedUserId]
				   ,[CreatedDateTime]
			   )
			  values
			  (
				 @CompanyId,
				 @ReferenceNo,
				 @ApprovalTypeId,
				 @CreatedUserId,
				 @ApprovalRecieversId,
				 @ApprovalPendingStatus,
				 @CreatedUserId, 
				  GETDATE()
			 )


			 SELECT @LastApprovalTaskId = SCOPE_IDENTITY() 

			 SELECT AT.ApprovalTaskId
			 FROM [wkb.ApprovalTask] AT WHERE AT.Id = @LastApprovalTaskId

			COMMIT TRANSACTION
		  END TRY

          BEGIN CATCH
            ROLLBACK TRANSACTION
          END CATCH
	
		
END 
GO
