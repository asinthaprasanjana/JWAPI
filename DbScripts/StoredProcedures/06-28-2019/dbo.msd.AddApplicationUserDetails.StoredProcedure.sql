USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddApplicationUserDetails]    Script Date: 28/06/2019 4:49:03 PM ******/
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
	@roleId SMALLINT,
	@userID SMALLINT,
	@Branch SMALLINT,
	@UserName varchar(30),
	@Token varchar(30),
	@password nvarchar(20),
	@CompanyId SMALLINT,
	@FirstName  varchar(20),
	@LastName varchar(20),
	@NicNo varchar(15),
	@BirthDay date,
	@MobileNo INT,
	@Email varchar(50),
	@roleName varchar(50),
	@Address varchar(100),
	@ExpirationDate date


AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		DECLARE @Id INT,
		        @ErrorMessage				VARCHAR(200),
				@IsApproved					TINYINT = 1,
				@IsActive                   TINYINT = 1,
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

	--SELECT @IsActive = AT.IsActive FROM [wkb.ApprovalTypes] AT WHERE ApprovalTypeId = @UserCreationApprovalTypeId

	--IF(@IsActive =1)
	--   BEGIN
	--      SET @IsApproved = 0
	--   END
	--ELSE
	--  BEGIN
	--   SET @IsApproved = 1
	--  END



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
