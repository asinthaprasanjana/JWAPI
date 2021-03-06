USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.getApplicationUserByCompanyID]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[usm.getApplicationUserByCompanyID]
(

 @CompanyID INT 
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
		AP.UserName,
		AP.Password,
		AP.UserID,
		AP.FirstName,
		AP.LastName,
		AP.NIC,
		AP.DateOfBirth,
		AP.ContactNumber,
		AP.Address,
		AP.CreatedUserId,
		AP.CreatedDateTime
	FROM [usm.ApplicationUser] AP
	WHERE  AP.CompanyID= @CompanyID
END 
GO
