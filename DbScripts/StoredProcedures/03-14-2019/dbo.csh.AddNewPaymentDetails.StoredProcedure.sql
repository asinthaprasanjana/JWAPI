USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewPaymentDetails]    Script Date: 14/03/2019 11:47:02 AM ******/
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
		@PaymentMethodName NVARCHAR(50),
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
