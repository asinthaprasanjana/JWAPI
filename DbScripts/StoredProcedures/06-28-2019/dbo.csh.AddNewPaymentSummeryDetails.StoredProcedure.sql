USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.AddNewPaymentSummeryDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.AddNewPaymentSummeryDetails]
(
  @ReferenceNo       VARCHAR(20),
  @TotalPaidAmount   DECIMAL,
  @BusinessPartnerId INT,
  @PayementType      SMALLINT,
  @CreatedUserId     SMALLINT
)	
	
	
AS
BEGIN

            DECLARE @PayementDocumentNo VARCHAR(20),
					@Id                 VARCHAR(20),
					@Balance            DECIMAL,
					@DocumentTypeId     TINYINT,
			        @LastInsertedId     INT;

					IF ( @PayementType = 1 )
					   BEGIN
					     SET @DocumentTypeId = 8
					   END
					ELSE IF ( @PayementType = 2 )
					   BEGIN
					       SET @DocumentTypeId = 9
					   END
					  




					EXEC	 [dbo].[stk.GetDocumentIdByDocumentTypeId] @DocumentTypeId, @Id OUTPUT
			        SET @PayementDocumentNo = @Id


	  INSERT INTO [csh.PaymentDetails] 
	   ( 
	     ReferenceNo,
		 DocumentNo,
		 PaymentTypeId,
		 BusinessPartnerId,
		 TotalPaid,
		 CreatedUserId,
		 CreatedDateTime

		)
		 VALUES (
		   @ReferenceNo,
		   @PayementDocumentNo,
		   @PayementType,
		   @BusinessPartnerId,
		   @TotalPaidAmount,
		   @CreatedUserId,
		   GETDATE()
		 )

	SET @LastInsertedId = SCOPE_IDENTITY()

	SELECT PD.DocumentNo AS 'ReferenceNo' FROM [csh.PaymentDetails] PD WHERE PD.Id = @LastInsertedId;
END
GO
