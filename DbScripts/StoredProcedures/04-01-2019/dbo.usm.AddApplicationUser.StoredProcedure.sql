USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[usm.AddApplicationUser]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

-- =============================================
CREATE PROCEDURE [dbo].[usm.AddApplicationUser]
(

  @UserName nvarchar(50),
  @Password nvarchar(50),
  @RoleId int,
  @Token nvarchar (20),
  @UserID int, 
  @Branch int,
  @CompanyID int, 
  @FirstName nvarchar(150),
  @LastName nvarchar(150),
  @NIC nchar(10),
  @DateOfBirth datetime,
  @ContactNumber int,
  @Address nvarchar(50),
  @CreatedUserId int, 
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
