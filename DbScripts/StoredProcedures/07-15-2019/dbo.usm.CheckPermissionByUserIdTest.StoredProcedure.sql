USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.CheckPermissionByUserIdTest]    Script Date: 15/07/2019 12:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[usm.CheckPermissionByUserIdTest]
(

  @BusinessProcessId SMALLINT,
  @UserId            SMALLINT

)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @Result SMALLINT ;
	SET NOCOUNT ON;

	   EXEC @Result= [usm.CheckPermissionByUserId] 1, 1

	   print @Result
	 RETURN 1

	
		
	
END 
GO
