USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetPaymentHistoryDetailsByDocumentNo]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetPaymentHistoryDetailsByDocumentNo]
(
@DocumentNo VARCHAR(20)
)	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	 PDI.DocumentNo,
	 PDI.BillId,
	 PDI.PaymentMethodTypeId,
	 PDI.PaidAmount,
	 PDI.Reference1,
	 PDI.Reference2,
	 PDI.Reference3,
	 PDI.Reference4
	FROM 
	[dbo].[csh.PaymentDetailsItems] PDI
	WHERE 
	PDI.DocumentNo = @DocumentNo
END
GO
