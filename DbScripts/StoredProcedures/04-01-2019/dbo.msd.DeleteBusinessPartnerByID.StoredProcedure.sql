USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.DeleteBusinessPartnerByID]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.DeleteBusinessPartnerByID]
	@BusinessPartnerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		DELETE FROM [bsp.BusinessPartner]
		 WHERE BusinessPartnerId = @BusinessPartnerId

	
	
END
GO
