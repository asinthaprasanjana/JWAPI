USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddTransactionTypes]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[stk.AddTransactionTypes]
	@Id nchar(10),
	@TransactionTypeId int,
	@TransactionName nvarchar(20),
	@CreatedUserId int,
	@CreatedDateTime datetime	
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
