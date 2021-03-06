USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddCurrencyDetails]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[msd.AddCurrencyDetails]
	@ID INT,
	@CompanyId INT,
	@CurrencyId INT,
	@CurrencyName nvarchar(20),
	@CreatedUserID int,
	@DisplayName nvarchar(10)
	
	
AS
BEGIN
		INSERT INTO msd.Currency
		(
			id,
			CompanyId,
			CurrencyId,
			CurrencyName,
			CreatedUserId,
			CreatedDateTime,
			DisplayName
		) 
		values 
		( 
				@ID ,
				@CompanyId ,
				@CurrencyId,
				@CurrencyName,
				@CreatedUserID,
				GETDATE(),
				@DisplayName	  
		)
END
GO
