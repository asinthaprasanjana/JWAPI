USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[GetBusinessPartnerDetailByBusinessPartnerTypeID]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBusinessPartnerDetailByBusinessPartnerTypeID]
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
	BP.DisplayName ,
	BP.Email,
	( SUBSTRING (BP.FirstName, 1, 1 ) +SUBSTRING (BP.LastName, 1, 1 )) AS 'InitialName'
	FROM
	[bsp.BusinessPartner] BP
	WHERE BP.CompanyId = @CompanyId AND BP.BusinessPartnerTypeId = @BusinessPartnerTypeId
END
GO
