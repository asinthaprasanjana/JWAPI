USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.GetApprovalTaskCreatedUserIdbyTaskId]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.GetApprovalTaskCreatedUserIdbyTaskId]
(
	@ApprovalTaskId VARCHAR(208)
)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	  

	SET NOCOUNT ON;
	--DBCC DROPCLEANBUFFERS


	
	SELECT 
	    AT.ApprovalTaskId,
		AT.CreatedUserId
	FROM [dbo].[wkb.ApprovalTask] AT
	WHERE AT.ApprovalTaskId = @ApprovalTaskId
	

END
GO
