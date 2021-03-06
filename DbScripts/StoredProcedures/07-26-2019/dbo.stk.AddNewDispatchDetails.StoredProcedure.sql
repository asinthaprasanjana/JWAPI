USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewDispatchDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddNewDispatchDetails]
(
@TypeId INT,
@BusinessPartnerId INT,
@DispatchTypeId INT,
@BusinessPartnerTypeId INT,
@ReasonId INT,
@ReasonName VARCHAR(50),
@Comment VARCHAR(200),
@ReturnDate VARCHAR(15),
@RecieveStatus VARCHAR(50),
@ContactDetail VARCHAR(100),
@Reason VARCHAR(50),
@CreatedUserId INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @CompanyId TINYINT =1,
	        @DispatchDocumentTypeId SMALLINT = 14,
			@DocumentNumber VARCHAR(30),
			@Id VARCHAR(30),
			@GatePassDocumentTypeId SMALLINT = 15 ;

	IF(@DispatchTypeId=1)
		BEGIN

		   	EXEC	 [dbo].[stk.GetDocumentIdByDocumentTypeId] @DispatchDocumentTypeId, @Id OUTPUT
			    SET @DocumentNumber = @Id
			INSERT INTO [dbo].[stk.Dispatch]
					   (
						[DispatchTypeId]
					   ,[DocumentNumber]
					   ,[BusinessPartnerTypeId]
					   ,[ReasonId]
					   ,[ReasonName]
					   ,[Comment]
					   ,[CreatedUserId]
					   ,[CreatedDateTime]
					   )
				 VALUES(
				 @DispatchTypeId,
				 @DocumentNumber,
				 @BusinessPartnerTypeId,
				 @ReasonId,
				 @ReasonName,
				 @Comment,
				 @CreatedUserId,
				 GETDATE()
	           )
		END
ELSE
	BEGIN
		EXEC	 [dbo].[stk.GetDocumentIdByDocumentTypeId] @GatePassDocumentTypeId, @Id OUTPUT
			    SET @DocumentNumber = @Id

	INSERT INTO [dbo].[stk.GatePass]
           ([TypeId]
		   ,[DocumentNumber]
           ,[BusinessPartnerId]
           ,[BusinessPartnerTypeId]
           ,[ReturnDate]
           ,[RecieveStatus]
           ,[ContactDetail]
           ,[Reason]
           ,[CreatedUserId]
           ,[CreatedDateTime])
     VALUES(
	     @TypeId,
		 @DocumentNumber,
		 @BusinessPartnerId,
		 @BusinessPartnerTypeId,
		 @ReturnDate,
		 @RecieveStatus,
		 @ContactDetail,
		 @Reason,
		 @CreatedUserId,
		 GETDATE()
	 )
	END        

END
GO
