USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.GetBusinessPartnerDetailsByBSPName]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bsp.GetBusinessPartnerDetailsByBSPName]
(
@Name NVARCHAR(50),
@BusinessPartnerTypeId INT

)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT BusinessPartnerId,BusinessPartnerTypeId,CompanyName,DisplayName,MobileNo,NIC,Email
	FROM [dbo].[bsp.BusinessPartner]
	WHERE BusinessPartnerTypeId = @BusinessPartnerTypeId AND  DisplayName like '%' + @Name + '%'
END
GO
