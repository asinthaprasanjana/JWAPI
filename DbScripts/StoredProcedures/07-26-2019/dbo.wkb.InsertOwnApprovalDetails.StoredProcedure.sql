USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.InsertOwnApprovalDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.InsertOwnApprovalDetails]
	@ID INT,
	@ApprovalTaskId INT,
	@ApprovalResponserId INT,
	@CreatedUserId INT,
	@CreatedDateTime DATETIME,
	@CompnayID INT
	
AS
BEGIN
		INSERT INTO wkb.OwnApprovalDetails 
		(Id,
		ApprovalTaskId,
		ApprovalResponserId,
		CreatedUserId,
		CreatedDateTime,
		CompnayID ) 
		values ( 
		@ID,
		@ApprovalTaskId,
		@ApprovalResponserId,
		@CreatedUserId,
		@CreatedDateTime,
		@CompnayID)  
END
GO
