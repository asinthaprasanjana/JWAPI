USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddTransactionTypes]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddTransactionTypes]
	@Id CHAR(10),
	@TransactionTypeId INT,
	@TransactionName VARCHAR(20),
	@CreatedUserId SMALLINT,
	@CreatedDateTime DATETIME	
AS
BEGIN
		INSERT INTO stk.TransactionTypes
		(
			Id,
			TransactionTypeId,
			TransactionName,
			CreatedUserId,
			CreatedDateTime
	
		) 
		values 
		( 
			@Id ,
			@TransactionTypeId,
			@TransactionName ,
			@CreatedUserId ,
			@CreatedDateTime 	 	  
		)
END
GO
