USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.UpdateApprovalRejectOrAcceptByTaskId]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.UpdateApprovalRejectOrAcceptByTaskId]
(
  @ApprovalTaskId int,
  @IsApproved tinyint,
  @UserId tinyint,
  @UserComment varchar (350)

 )

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	    DECLARE @ApprovalTypeId               TINYINT,
		        @PurchaseOrderApprovalTypeId  TINYINT = 1,
				@StockAdjusmentApprovalTypeId TINYINT = 3,

				@ReferenceNo				 VARCHAR(25),
				@NotificationHeader          VARCHAR(100),
				@NotificationBody            VARCHAR(200),
			    @ApprovalResponder           VARCHAR(20) ,
				@ApprovalOwnerId             SMALLINT,
				@ApprovalMessage             VARCHAR(10),
				@ApprovalStatus              TINYINT; 

		IF EXISTS ( SELECT 1 FROM [wkb.ApprovalEvents] AE WHERE AE.ApprovalTaskId = @ApprovalTaskId)
		   BEGIN

		        IF(@IsApproved = 1)
				  BEGIN
				   SET @ApprovalStatus = 2  -- approval approved status
				   SET @ApprovalMessage = 'Approved by'
				  END
				ELSE IF(@IsApproved = 0)
				  BEGIN
				    SET @ApprovalStatus = 3 -- approval rejected status
					SET @ApprovalMessage = 'Rejected by'

				  END

					   UPDATE [dbo].[wkb.ApprovalEvents]  SET
					    UserComment= @UserComment,
					   Status = @ApprovalStatus
					   WHERE ApprovalTaskId = @ApprovalTaskId 

					   UPDATE [wkb.ApprovalTask] SET 
					   Status = @ApprovalStatus 
					   WHERE ApprovalTaskId = @ApprovalTaskId
			 
					  SELECT @ApprovalResponder = AUL.UserName
					  FROM [msd.ApplicationUserLogInDetails] AUL
					  WHERE UserId = @UserId;


			   IF NOT EXISTS ( SELECT 1 FROM [wkb.ApprovalTaskResult] WHERE ApprovalTaskId = @ApprovalTaskId)
			       BEGIN
				     

					  SELECT @ReferenceNo = AT.ReferenceNo FROM [wkb.ApprovalTask] AT 
					  WHERE AT.ApprovalTaskId = @ApprovalTaskId;

					  IF(@ReferenceNo IS NULL)
					    BEGIN
						  RAISERROR('Reference No Is Not Valid', 16, 1);

						return 0 
						END

					   INSERT INTO [wkb.ApprovalTaskResult]
						( 
						  ApprovalTaskId,
						  ApprovalResponserId,
						  ApprovalResponserName,
						  CreatedUserId,
						  CreatedDateTime)
						  VALUES 
						  (
						   @ApprovalTaskId,
						   @UserId,
						   @ApprovalResponder,
						   @UserId,
						   GETDATE()
						   )
					
				END
			   ELSE
			      BEGIN
				  RAISERROR('This Approval has been already Approved or Rejected by someone', 16, 1);

				 END

			   SELECT @ApprovalTypeId= AE.ApprovalTypeId ,
			          @ApprovalOwnerId = AE.CreatedUserId 
			          FROM  [wkb.ApprovalEvents] AE 
			          WHERE AE.ApprovalTaskId = @ApprovalTaskId

			   IF(@ApprovalTypeId = @PurchaseOrderApprovalTypeId)
			      BEGIN
				    DECLARE @PurchaseNo INT

					SELECT @PurchaseNo= AT.ReferenceNo
					FROM [wkb.ApprovalTask] AT
					WHERE @ApprovalTaskId = @ApprovalTaskId

					SET @NotificationHeader = 'Purchase Order Approval'
					SET @NotificationBody   =  'Your purchase order has been '+ @ApprovalMessage+ ' '+ @ApprovalResponder +' '+ ' Reference '+ @ReferenceNo

					UPDATE [stk.PurchaseOrder]
					SET ApprovalStatus   = @ApprovalStatus,
					LastModifiedUserId   = @UserId,
					LastModifiedDateTime = GETDATE()
					WHERE PurchaseNo = @ReferenceNo
				  END
				ELSE IF (@ApprovalTypeId = @StockAdjusmentApprovalTypeId)
				    BEGIN
				
				      IF EXISTS ( SELECT 1 FROM  [stk.StockAdjustmentSummery] SA WHERE SA.StockAdjustmentId = @ReferenceNo)
					      BEGIN
						     UPDATE [stk.StockAdjustmentSummery]
						       SET ApprovalStatus = @ApprovalStatus
						    WHERE StockAdjustmentId = @ReferenceNo;
					      SET @NotificationHeader = 'Stock Adjusment Approval'
					      SET @NotificationBody   =  'Your Stock Adjusment has been '+ @ApprovalMessage+ ' '+ @ApprovalResponder +' '+ ' Reference '+ @ReferenceNo
						  END
					 
					END
				ELSE
				   BEGIN
				   print ('test')
				   END

			  INSERT INTO [dbo].[ntm.NotificationEvents]
					   (
					    [UserId]
					   ,[ReferenceNo]
					   ,[Header]
					   ,[Message]
					   ,[Url]
					   ,[Seen]
					   ,[IsActive]
					   ,[Sender]
					   ,[CreatedUserId]
					   ,[CreatedDateTime])
						 VALUES
							(
							 @ApprovalOwnerId,
							 @ReferenceNo,
							 @NotificationHeader,
							 @NotificationBody,
							 NULL,
							 0,
							 1,
							  @UserId,
							  @UserId,
							  GETDATE())


		   END
		ELSE
		   BEGIN
		   	  RAISERROR('Approval Task No Is Not Valid', 16, 1);
		   END
	

END
GO
