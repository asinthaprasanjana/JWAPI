USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddCurrencyDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.AddCurrencyDetails]
	@ID INT,
	@CompanyId INT,
	@CurrencyId INT,
	@CurrencyName varchar(20),
	@CreatedUserID SMALLINT,
	@DisplayName varchar(10)
	
	
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
