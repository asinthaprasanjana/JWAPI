USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.getUserPrivilegeDetailsByUserId]    Script Date: 15/07/2019 12:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.getUserPrivilegeDetailsByUserId]
(
	@UserId SMALLINT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT

	AUPD.UserId,
	AUPD.PrivilegeId

	FROM [msd.ApplicationUserPrivilegesDetails] AUPD
	WHERE AUPD.UserId=@UserId
END
GO
