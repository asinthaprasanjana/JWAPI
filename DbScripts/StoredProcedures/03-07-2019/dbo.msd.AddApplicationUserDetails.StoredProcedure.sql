USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddApplicationUserDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.AddApplicationUserDetails]
	@roleId INT,
	@userID INT,
	@Branch INT,
	@UserName nvarchar(30),
	@Token nvarchar(30),
	@password nvarchar(20),
	@CompanyId INT,
	@FirstName  nvarchar(20),
	@LastName nvarchar(20),
	@NicNo nvarchar(15),
	@BirthDay date,
	@MobileNo INT,
	@Email nvarchar(50),
	@roleName nvarchar(50),
	@Address nvarchar(100),
	@ExpirationDate date


AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		DECLARE @Id INT,
		        @ErrorMessage				VARCHAR(200),
				@IsApproved					TINYINT,
				@IsActive                   TINYINT,
				@UserCreationApprovalTypeId TINYINT =4,
				@list VARCHAR(100) = '',
                @CurrentRowNumber  INT     = 1,
                @TempTableRowCount INT;
				


		IF EXISTS (Select 1 FROM  [msd.ApplicationUserLogInDetails] WHERE UserName = @UserName)
		         BEGIN
				  RAISERROR('This User Name Is Already Exists', 16, 1);
				 END

		INSERT INTO [msd.ApplicationUserDetails]
	(
			FirstName,
			LastName,
			NicNo,
			BranchID,
			Birthday,
			ExpirationDate,
			MobileNo,
			Email,
			Address
	)
	VALUES
	(
		   @FirstName,
		   @LastName,
		   @NicNo,
		   @Branch,
		   @Birthday,
		   @ExpirationDate,
		   @MobileNo,
		   @Email,
		   @Address
	)

	SET @Id = SCOPE_IDENTITY();

	SELECT @IsActive = AT.IsActive FROM [wkb.ApprovalTypes] AT WHERE ApprovalTypeId = @UserCreationApprovalTypeId

	IF(@IsActive =1)
	   BEGIN
	      SET @IsApproved = 0
	   END
	ELSE
	  BEGIN
	   SET @IsApproved = 1
	  END



	INSERT INTO [msd.ApplicationUserLogInDetails]
	(
		UserId,
		UserName,
		Password,
		RoleId,
		BranchId,
		IsApproved

	)
	VALUES
	(
		(SELECT UserId from [msd.ApplicationUserDetails] WHERE Id=@id ),
		@UserName,
		@password,
		@roleId,
		@Branch,
		@IsApproved
	)


	 DECLARE  @tempTable TABLE ( Id int Identity(1,1), PrivilegeId VARCHAR(15) )  

	             INSERT INTO @tempTable 
				      (PrivilegeId) 
					  (
					    SELECT  convert(varchar,UP.PrivilegeId)  FROM [usm.UserRolePrivileges] UP WHERE @roleId IN (SELECT * FROM dbo.splitstring(UP.RoleIds))
					   )

			      SELECT @TempTableRowCount =  COUNT( TT.Id) FROM @tempTable TT

				  WHILE @CurrentRowNumber <= @TempTableRowCount
					 BEGIN
								    DECLARE @templist VARCHAR(10)
									   SELECT @templist = T.PrivilegeId FROM @tempTable T WHERE ID = @CurrentRowNumber;

									   IF(@CurrentRowNumber <2)
									     BEGIN
										 SET @list =  @templist;

										 END
									   ELSE
									     BEGIN
										  SET @list = @list  +','+ @templist;

										 END
								

								   SET @CurrentRowNumber = @CurrentRowNumber+1;
								  END

                  INSERT INTO [msd.ApplicationUserPrivilegesDetails]
	(
		UserId,
		PrivilegeId,
		CreatedDateTime
	)
	VALUES
	(
		  (SELECT UserId from [msd.ApplicationUserDetails] WHERE Id=@id),
		  @list,
		 GETDATE()
	)

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	      SET  @ErrorMessage = ERROR_MESSAGE();
		  RAISERROR (@ErrorMessage, 16,1 );

		ROLLBACK TRANSACTION
	END CATCH
	
END
GO
