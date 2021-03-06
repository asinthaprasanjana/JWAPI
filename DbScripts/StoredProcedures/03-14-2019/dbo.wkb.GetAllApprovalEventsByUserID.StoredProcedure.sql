USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.GetAllApprovalEventsByUserID]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.GetAllApprovalEventsByUserID]
(
 @UserID INT,
 @PageId SMALLINT

)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	   AE.ApprovalTaskId,
		AE.UserId,
		AE.ReferenceNo,
		AULD.UserName AS SenderName,
		AE.ApprovalTypeId,
		AE.ApprovalTypeName,
		AE.CreatedUserId,
		 CONVERT(VARCHAR(20),AE.CreatedDateTime, 100)  AS 'CreatedDateTime',
		AE.Status,
		 CASE AE.Status 
             WHEN 1 THEN 'Pending'
             WHEN 2 THEN 'Approved'
			  WHEN 3 THEN 'Rejected'
          END  AS 'StatusType'
		
	FROM [wkb.ApprovalEvents] AE
	INNER JOIN [msd.ApplicationUserLogInDetails] AULD ON AE.ApprovalSenderId=AULD.UserId
	WHERE AE.UserId =@UserID 
	ORDER BY AE.CreatedDateTime DESC
	
	
END 

GO
