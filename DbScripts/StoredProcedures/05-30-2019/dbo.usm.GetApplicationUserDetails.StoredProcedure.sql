USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.GetApplicationUserDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
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
@UserName varchar(50),
@Password varchar(20)

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
