USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewPaymentDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
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
  @ReferenceNo VARCHAR(20),
  @TotalPaidAmount DECIMAL,
  @Balance DECIMAL,
  @BusinessPartnerId INT,
  @PayementType      SMALLINT,
  @CreatedUserId     SMALLINT
)	
	
	
AS
BEGIN

            DECLARE @PayementDocumentNo VARCHAR(20),
					@Id                 VARCHAR(20),

			        @LastInsertedId     INT;

					EXEC	 [dbo].[stk.GetDocumentIdByDocumentTypeId] @PayementType, @Id OUTPUT
			        SET @PayementDocumentNo = @Id


	  INSERT INTO [csh.PaymentDetails] 
	   ( 
	     ReferenceNo,
		 PaymentNo,
		 PaymentTypeId,
		 BusinessPartnerId,
		 TotalPaid,
		 Balance,
		 CreatedUserId,
		 CreatedDateTime

		)
		 VALUES (
		   @ReferenceNo,
		   @PayementDocumentNo,
		   @PayementType,
		   @BusinessPartnerId,
		   @TotalPaidAmount,
		   @Balance,
		   @CreatedUserId,
		   GETDATE()
		 )

	SET @LastInsertedId = SCOPE_IDENTITY()

	SELECT PD.PaymentNo AS 'ReferenceNo' FROM [csh.PaymentDetails] PD WHERE PD.Id = @LastInsertedId;
END
GO
