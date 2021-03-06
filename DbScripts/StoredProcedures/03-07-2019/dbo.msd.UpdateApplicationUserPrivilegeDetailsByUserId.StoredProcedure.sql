USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateApplicationUserPrivilegeDetailsByUserId]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UpdateApplicationUserPrivilegeDetailsByUserId]
(
  @UserId INT,
  @PrivilegesId VARCHAR(100)
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--DECLARE @PrivilegesId INT;

	UPDATE [dbo].[msd.ApplicationUserPrivilegesDetail]  SET
		PrivilegesId =  @PrivilegesId
      
	WHERE UserId =@UserId
END 
GO
