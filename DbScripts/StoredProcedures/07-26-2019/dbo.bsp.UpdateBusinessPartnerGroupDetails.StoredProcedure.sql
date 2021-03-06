USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.UpdateBusinessPartnerGroupDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bsp.UpdateBusinessPartnerGroupDetails]
(
@Id INT,
@GroupId INT,
@GroupName VARCHAR(50),
@BusinessPartnerTypeId INT,
@CreatedUserId INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	UPDATE [dbo].[bsp.BusinessPartnerGroup]
	SET
	GroupId = @GroupId,
	GroupName= @GroupName,
	BusinessPartnerTypeId = @BusinessPartnerTypeId,
	CreatedUserId = @CreatedUserId,
	CreatedDateTime = GETDATE()
	WHERE Id = @Id
	



END
GO
