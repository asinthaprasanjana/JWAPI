USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetIdByStockTransactionTypeId]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetIdByStockTransactionTypeId]
	(
	  @TransactionTypeId INT,
	  @ReferenceNo       VARCHAR(20),
	  @UserId            SMALLINT
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Data INT=0;

	
	SELECT @Data = TT.Data
		   FROM [dbo].[stk.TransactionTypes] TT
	WHERE TransactionTypeId = @TransactionTypeId

	  IF (@Data IS NULL)
	     BEGIN
	      SET @Data = 1;
		 END
	  ELSE
	    BEGIN
		 SET @Data = @Data+1;
		END

	INSERT INTO [stk.TransactionTypes]
	    ( 
		TransactionTypeId,
		Data,
		ReferenceNo,
		CreatedUserId,
		CreatedDateTime
		)
		VALUES
		(
		 @TransactionTypeId,
		 @Data,
		 @ReferenceNo,
		 @userId,
		 GETDATE()
		 )

	SELECT TOP 1 TT.TransactionName,
	        @Data AS 'Id'
		   FROM [dbo].[stk.TransactionTypes] TT
	WHERE TransactionTypeId = @TransactionTypeId AND @ReferenceNo = @ReferenceNo
	ORDER BY ID DESC


	


END

GO
