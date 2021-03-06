USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.GetBusinessPartnerDetailsByBSPName]    Script Date: 15/07/2019 12:10:18 PM ******/
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
@BusinessPartnerTypeId SMALLINT,
@Name VARCHAR(20)
)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@BusinessPartnerTypeId =0)
	    BEGIN
		    SELECT BusinessPartnerId,BusinessPartnerTypeId,CompanyName,DisplayName,MobileNo,NIC,Email
			FROM [dbo].[bsp.BusinessPartner]
			WHERE  DisplayName like '%' + @Name + '%'
		END
	ELSE IF(@BusinessPartnerTypeId =3)
	    BEGIN
		 
		 SELECT A.UserName AS DisplayName,A.UserId AS BusinessPartnerId
		 FROM [dbo].[msd.ApplicationUserLogInDetails] A
		 WHERE A.UserName LIKE '%' + @Name +'%'
		END
  
	ELSE 
	    BEGIN
	  
			SELECT BusinessPartnerId,BusinessPartnerTypeId,CompanyName,DisplayName,MobileNo,NIC,Email
			FROM [dbo].[bsp.BusinessPartner]
			WHERE BusinessPartnerTypeId = @BusinessPartnerTypeId AND  DisplayName like '%' + @Name + '%'
	    END
END
GO
