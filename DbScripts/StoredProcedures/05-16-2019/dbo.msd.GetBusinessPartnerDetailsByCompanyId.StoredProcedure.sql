USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetBusinessPartnerDetailsByCompanyId]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetBusinessPartnerDetailsByCompanyId]
(
 @CompanyId INT,
 @BusinessPartnerTypeId INT

 )

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.



	SET NOCOUNT ON;
    SELECT
	BP.BusinessPartnerId,
	BP.DisplayName AS 'Name',
	BP.Email,
	( SUBSTRING (BP.FirstName, 1, 1 ) +SUBSTRING (BP.LastName, 1, 1 )) AS 'InitialName'
	FROM
	[bsp.BusinessPartner] BP
	WHERE BP.CompanyId = @CompanyId AND BP.BusinessPartnerTypeId = @BusinessPartnerTypeId
END
GO
