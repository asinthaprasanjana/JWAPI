USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.UpdateFunctionApprovalDetailsById]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.UpdateFunctionApprovalDetailsById]
@CompanyId int,
@ApprovalTypeId int,
@Status int
	
AS
BEGIN
	UPDATE [dbo].[wkb.ApprovalTypes] SET  
		IsActive=@Status,
		LastModifiedDateTime=GETDATE()
		WHERE CompanyId = @CompanyId  AND ApprovalTypeId=@ApprovalTypeId
END
GO
