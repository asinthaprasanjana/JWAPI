USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetApplicationUserDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetApplicationUserDetails]
(
@UserName nvarchar(50),
@Password nvarchar(20)
)
 
AS

IF EXISTS (
SELECT * 
FROM  dbo.[msd.ApplicationUserLogInDetails] AULD 
WHERE AULD.UserName= @UserName  AND AULD.password = @Password) 
   
   
   BEGIN
     
			  DECLARE @IsLogedIn        TINYINT =1,
			          @isDuplicateLogIn TINYINT  = 0,
					  @ApprovedStatus   TINYINT  = 1,
					  @TodaysDate       DATETIME = GETDATE(),
					  @UserId           INT ;
          
			  SELECT @UserId= UserId
			  FROM [msd.ApplicationUserLogInDetails] AU
			  WHERE AU.UserName =@UserName AND IsApproved = @ApprovedStatus --AND ExpireDate = @TodaysDate
          
			  IF  EXISTS (SELECT 1 FROM [dbo].[msd.CurrentUserLoginDetails] CULD WHERE CULD.UserId =@UserId) 
				 BEGIN 
						   IF  EXISTS (SELECT * FROM [dbo].[msd.CurrentUserLoginDetails] CULD WHERE CULD.UserId =@UserId AND CULD.IsLogedIn = @IsLogedIn) 
							   BEGIN
									 SET @isDuplicateLogIn = 1;

							   END
						   ELSE 
							  BEGIN
								  UPDATE [msd.CurrentUserLoginDetails]
								  SET IsLogedIn = @IsLogedIn
								  WHERE UserId = @UserId
							  END
				 END
			--  ELSE
				-- BEGIN
					--INSERT INTO [msd.CurrentUserLoginDetails] 
					-- (
					--  UserId,
					--  IsLogedIn,
					--  CreatedDateTime)
					--  VALUES
					--  (
					--   @UserId,
					--   @IsLogedIn,
					--   GETDATE()
					--   )
		 
			--	 END
		  
		  IF (@UserId IS NOT NULL)
		      BEGIN
			   SELECT
			  AU.UserName,
			  AU.BranchId,
			  @isDuplicateLogIn AS 'DuplicateLogIn',
			  AU.UserId,
			  AUD.Email,
			  AUD.Address,
			  AUD.MobileNo,
			  UR.RoleName,
			  AU.RoleId,
			  AU.BranchID 
			  FROM  [msd.ApplicationUserLogInDetails] AU
			  LEFT JOIN [msd.ApplicationUserDetails] AUD ON AUD.Id = AU.UserId
			  INNER JOIN [usm.UserRoles] UR ON au.RoleId = UR.RoleId
			  WHERE AU.UserName = @UserName AND AU.Password = @Password
			  END
			 
			 
    END

ELSE
   BEGIN  
   RAISERROR ('INVALID USER',16,1 );

   END 
 

GO
