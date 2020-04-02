USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.BusinessPartnerBankByBankID]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[bsp.BusinessPartnerBankByBankID]
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
