USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateApprovaltypeOwnDetailsById]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UpdateApprovaltypeOwnDetailsById]
(
@ApprovalTypeId INT,
@CompanyId INT,
@IdList nvarchar(1000)
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	UPDATE  [wkb.ApprovalTypeOwnDetails]
	
	SET
	ApprovalOfficersId=@IdList

	WHERE ApprovalTypeId=@ApprovalTypeId

END
GO
