USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetApprovaltypeOwnDetailsById]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetApprovaltypeOwnDetailsById]
(
@ApprovalTypeId INT
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Select 
	ATOD.Id,
	ATOD.ApprovalTypeId,
	ATOD.ApprovalOfficersId
	FROM [wkb.ApprovalTypeOwnDetails] ATOD
	WHERE ATOD.ApprovalTypeId=@ApprovalTypeId

	
	
END
GO
