USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[csh.GetAdvancePaymentDetailsById]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[csh.GetAdvancePaymentDetailsById]
(
@AdvancePaymentId varchar(20)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT *
	FROM [dbo].[csh.AdvancePayment]
	WHERE AdvancePaymentId = @AdvancePaymentId
END 
GO
