USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.UpdateOwnApprovalDetailsByApprovalID]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.UpdateOwnApprovalDetailsByApprovalID]
	@ID INT,
	@ApprovalTaskId INT,
	@ApprovalResponserId INT,
	@CreatedUserId INT,
	@CreatedDateTime DATETIME,
	@CompnayID INT
	
AS
BEGIN
	UPDATE wkb.OwnApprovalDetails SET  
		Id = @ID, 
		ApprovalResponserId = @ApprovalResponserId, 
		CreatedUserId = @CreatedUserId,  
		CreatedDateTime = @CreatedDateTime,
		  CompnayID =@CompnayID
		WHERE ApprovalTaskId = @ApprovalTaskId  
END
GO
