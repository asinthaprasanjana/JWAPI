USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.AddApplicationUser]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[usm.AddApplicationUser]
(

  @UserName varchar(50),
  @Password varchar(50),
  @RoleId int,
  @Token varchar (20),
  @UserID smallint, 
  @Branch int,
  @CompanyID int, 
  @FirstName varchar(150),
  @LastName varchar(150),
  @NIC char(10),
  @DateOfBirth datetime,
  @ContactNumber int,
  @Address varchar(50),
  @CreatedUserId smallint, 
  @CreatedDateTime datetime
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO [usm.ApplicationUser]
	(
	
		FirstName,
		LastName,
		UserName,
		Password,
		NIC,
		BranchID,
		DateOfBirth,
		ContactNumber,
		Address,
		CompanyID,
		CreatedUserId,
		CreatedDateTime
	)
		values
	(
		  @FirstName ,
		  @LastName ,
		  @UserName ,
		  @Password ,
		  @NIC ,
		  @Branch,
		  @DateOfBirth ,
		  @ContactNumber ,
		  @Address ,
		  @CompanyID , 
		  @CreatedUserId, 
		  GETDATE()
	
	)
		
END 
GO
