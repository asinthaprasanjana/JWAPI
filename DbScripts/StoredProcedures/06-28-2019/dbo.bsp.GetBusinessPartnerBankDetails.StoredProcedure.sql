USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.GetBusinessPartnerBankDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bsp.GetBusinessPartnerBankDetails]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		BPB.BankId,
		BPB.BankName
	FROM [msd.BusinessPartnerBanks] BPB	
END
GO
