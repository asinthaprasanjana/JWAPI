USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewPaymentMethodDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.AddNewPaymentMethodDetails]
(
		@PaymentMethodName VARCHAR(50),
		@StartDate DATETIME,
		@EndDate  DATETIME
)	
	
	
AS
BEGIN
	INSERT INTO [dbo].[msd.PaymentMethod]
           (

		    [PaymentMethodName]
           ,[StartDate]
           ,[EndDate]
		   
		   )

		values 
		( 
			@PaymentMethodName,
			@StartDate,
			@EndDate

		)
END
GO
