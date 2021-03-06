USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAllPaymentItemDetailsByDocumentNo]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAllPaymentItemDetailsByDocumentNo]
(
 @DocumentNo VARCHAR(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	PD.DocumentNo AS 'PayementDocumentNo',
	PD.PaidAmount,
	PD.Reference1,
	PD.Reference2,
	Pd.Reference3,
	PD.Reference4,
	(SELECT M.Name FROM [msd.MultipurposeTag] M WHERE ModuleId = 11 AND Data = PD.PaymentMethodTypeId) AS 'PaymentType'
	FROM [csh.PaymentDetailsItems] PD
	WHERE PD.DocumentNo = @DocumentNo;
	    
END 
GO
