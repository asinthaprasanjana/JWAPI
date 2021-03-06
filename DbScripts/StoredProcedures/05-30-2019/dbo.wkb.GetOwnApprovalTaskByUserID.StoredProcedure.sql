USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.GetOwnApprovalTaskByUserID]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.GetOwnApprovalTaskByUserID]
(
 @UserID SMALLINT,
 @CompanyID SMALLINT,
 @PageId SMALLINT 
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT 
	DISTINCT 
	AT.ApprovalTaskId ,
	AT.ApprovalTypeId,
	AT.Id,
	   --AT.UserId
		AE.ReferenceNo,
	   ISNULL( ATR.ApprovalResponserName, 'Pending')  AS SenderName,
        AE.ApprovalTypeName,
	    AE.CreatedUserId,
	    CONVERT(VARCHAR(20),AE.CreatedDateTime, 100)  AS 'CreatedDateTime',
		AE.Status,
	      CASE AE.Status 
            WHEN 1 THEN 'Pending'
            WHEN 2 THEN 'Approved'
		    WHEN 3 THEN 'Rejected'
        END  AS 'StatusType'		
	FROM [wkb.ApprovalTask] AT
	INNER JOIN [msd.ApplicationUserLogInDetails] AULD ON AT.ApprovalSenderId=AULD.UserId
	INNER  JOIN [wkb.ApprovalEvents] AE ON AE.ApprovalTaskId = AT.ApprovalTaskId
	LEFT  JOIN [wkb.ApprovalTaskResult] ATR ON ATR.ApprovalTaskId= AT.ApprovalTaskId

	WHERE AE.CreatedUserId =@UserID 
    ORDER BY AT.Id DESC

		
	
		
END 
GO
