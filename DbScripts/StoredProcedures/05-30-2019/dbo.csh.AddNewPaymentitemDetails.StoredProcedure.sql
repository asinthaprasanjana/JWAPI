USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewPaymentitemDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.AddNewPaymentitemDetails]
(
  @PayementDocumentNo  VARCHAR(20),
  @PaidAmount          DECIMAL,
  @PayementMethodTypeId      SMALLINT,
  @Reference1          VARCHAR(20),
  @Reference2          VARCHAR(20),
  @Reference3          VARCHAR(20),
  @Reference4          VARCHAR(20),
  @CreatedUserId       SMALLINT
)	
	
	
AS
BEGIN


  INSERT INTO [csh.PaymentDetailsItems]
       (
	    PaymentNo,
		PaymentMethodTypeId,
		PaidAmount,
		Reference1,
		Reference2,
		Reference3,
		Reference4,
		CreatedUserId,
		CreatedDateTime )
		VALUES 
		(
		  @PayementDocumentNo,
		  @PayementMethodTypeId,
		  @PaidAmount,
		  @Reference1,
		  @Reference2,
		  @Reference3,
		  @Reference4,
		  @CreatedUserId,
		  GETDATE()
		)
          

END
GO
