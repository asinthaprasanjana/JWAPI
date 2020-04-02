USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewPaymentDetails]    Script Date: 16/05/2019 12:39:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.AddNewPaymentDetails]
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
