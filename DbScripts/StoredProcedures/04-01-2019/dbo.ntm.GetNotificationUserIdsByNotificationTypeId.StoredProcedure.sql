USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[ntm.GetNotificationUserIdsByNotificationTypeId]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ntm.GetNotificationUserIdsByNotificationTypeId]
	(
	   @NotificationTypeId SMALLINT,
	   @BranchId  VARCHAR(150),
	   @TransactionNo VARCHAR(20),
	   @UserId INT 
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @RoleIds VARCHAR(150),
	        @Header  VARCHAR(100),
			@Message VARCHAR(250),
			@TempTableRowCount SMALLINT,
			@CurrentRowNumber  SMALLINT = 1;

			
	SELECT @RoleIds= NT.RoleIds FROM [ntm.NotificationTypeDetails]
	NT WHERE NT.NotificationTypeId = @NotificationTypeId



	SELECT AU.UserId,AU.UserName FROM [msd.ApplicationUserLogInDetails] AU
--	WHERE RoleId IN ( SELECT * FROM dbo.splitstring(@RoleIds)) AND BranchId IN ( SELECT * FROM dbo.splitstring(@BranchId))

     SELECT @Header= NS.Header, @Message = NS.Message
	 FROM [ntm.NotificationSetting] NS
	 WHERE NS.NotificationTypeId = @NotificationTypeId

	 SET @Message = @Message +' '+ @TransactionNo;


	  DECLARE  @tempTable TABLE ( Id int Identity(1,1), userId int  )  
	 
			    INSERT INTO @tempTable 
				      ( userId					   
					  ) 
					  (
					    SELECT AU.UserId FROM [msd.ApplicationUserLogInDetails] AU
                   --	WHERE RoleId IN ( SELECT * FROM dbo.splitstring(@RoleIds)) AND BranchId IN ( SELECT * FROM dbo.splitstring(@BranchId))o
						)
           
		    SELECT* FROM @tempTable
			    SELECT @TempTableRowCount =  COUNT( T.Id) FROM @tempTable T

				WHILE @CurrentRowNumber <= @TempTableRowCount
				   BEGIN
				      DECLARE @NotificationRecieverUserId SMALLINT

					  SELECT @NotificationRecieverUserId= T.userId FROM @tempTable T WHERE T.Id = @CurrentRowNumber
                     INSERT INTO [dbo].[ntm.NotificationEvents]
					   ([CompanyId]
					   ,[UserId]
					   ,[ReferenceNo]
					   ,[Header]
					   ,[Message]
					   ,[Seen]
					   ,[IsActive]
					   ,[Sender]
					   ,[CreatedUserId]
					   ,[CreatedDateTime])
					 VALUES
				   (
					   1,
					   @NotificationRecieverUserId,
					   @TransactionNo,
					   @Header,
					   @Message,
					   0,
					   1,
					   1,
					   @UserId,
					  GETDATE()

					 )

					  SET @CurrentRowNumber = @CurrentRowNumber+1;
			      
				  END
END
GO
