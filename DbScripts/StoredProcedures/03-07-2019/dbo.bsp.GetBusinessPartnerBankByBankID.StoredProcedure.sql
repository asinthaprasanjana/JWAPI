USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.GetBusinessPartnerBankByBankID]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bsp.GetBusinessPartnerBankByBankID]
(
    @BankID INT
 )	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
		BPB.Id,
		BPB.BankName,
		BPB.CreatedUserId,
		BPB.CreatedDateTime
	FROM [msd.BusinessPartnerBanks] BPB	
	where BPB.BankId= @BankID
END
GO
