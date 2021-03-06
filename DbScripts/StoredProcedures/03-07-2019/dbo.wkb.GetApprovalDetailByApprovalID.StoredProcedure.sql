USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.GetApprovalDetailByApprovalID]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.GetApprovalDetailByApprovalID]
(
 @ApprovalTypeId INT,
 @CompanyID INT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	

	SET NOCOUNT ON;

	
    SELECT 
    AT.Id,
	 AT.ApprovalName,
	 AT.IsActive,
	 AT.CreatedUserId,
	 CONVERT(VARCHAR(10), AT.CreatedDateTime, 110)  AS 'CreatedDateTime'
	FROM [wkb.ApprovalTypes] AT
	WHERE AT.CompanyId =  @CompanyID AND AT.ApprovalTypeId = @ApprovalTypeId 
END 
GO
