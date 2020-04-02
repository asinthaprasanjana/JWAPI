USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.GetApplicationUserDetails]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usm.GetApplicationUserDetails]
(
@UserName nvarchar(50),
@Password nvarchar(20)

)
 
AS

IF EXISTS (SELECT * FROM  dbo.[msd.ApplicationUserLogInDetails] AULD WHERE AULD.UserName= @UserName  AND AULD.password = @Password) 
   BEGIN
      PRINT('SUCCESS');
    END

ELSE
   BEGIN  
   RAISERROR ('INVALID USER',16,1 );

   END 
 




GO
