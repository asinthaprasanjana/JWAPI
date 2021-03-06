USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddNewCompany]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddNewCompany]
(

@CompanyName varchar(100),
@Address varchar(150),
@VATNo varchar(20),
@RegistrationNo varchar(50),
@PhoneNo int,
@CreatedUserId SMALLINT

)
AS
BEGIN
		
INSERT INTO [dbo].[msd.Company]
           (
            [CompanyName]
           ,[Address]
           ,[VATNo]
           ,[RegistrationNo]
           ,[PhoneNo]
		   ,[CreatedUserId]
		   ,[CreatedDateTime]
		   )

		VALUES 
		( 
		   @CompanyName,
		   @Address,
		   @VATNo,
		   @RegistrationNo,
		   @PhoneNo ,
		   @CreatedUserId,
		   GETDATE() 
		)

END
GO
