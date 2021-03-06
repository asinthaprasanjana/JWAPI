USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetPaymentHistoryDetailsByDocumentNo]    Script Date: 26/07/2019 10:10:01 AM ******/
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

	DECLARE @PaymentTypeMulitipurposeTagModuleId SMALLINT = 11;

    -- Insert statements for procedure here
	SELECT
	 PDI.DocumentNo,
	 PDI.BillId,
	 PDI.PaymentMethodTypeId,
	 M.Name AS 'PaymentType',
	 PDI.PaidAmount,
	 PDI.Reference1,
	 PDI.Reference2,
	 PDI.Reference3,
	 PDI.Reference4
	FROM 
	[dbo].[csh.PaymentDetailsItems] PDI
	INNER JOIN [msd.MultipurposeTag] M ON M.Data = PDI.PaymentMethodTypeId
	WHERE 
	PDI.DocumentNo = @DocumentNo AND M.ModuleId = @PaymentTypeMulitipurposeTagModuleId
END
GO
