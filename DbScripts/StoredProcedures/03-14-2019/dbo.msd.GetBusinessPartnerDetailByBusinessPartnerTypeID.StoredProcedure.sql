USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetBusinessPartnerDetailByBusinessPartnerTypeID]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetBusinessPartnerDetailByBusinessPartnerTypeID]
(
 @CompanyId SMALLINT,
 @BusinessPartnerTypeId SMALLINT,
 @PageId SMALLINT

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
	BP.FirstName,
	BP.LastName
	FROM
	[bsp.BusinessPartner] BP
	WHERE BP.CompanyId = @CompanyId AND BP.BusinessPartnerTypeId = @BusinessPartnerTypeId
END
GO
