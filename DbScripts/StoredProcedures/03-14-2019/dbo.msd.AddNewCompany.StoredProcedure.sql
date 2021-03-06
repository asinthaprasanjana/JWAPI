USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddNewCompany]    Script Date: 14/03/2019 11:47:02 AM ******/
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
@CreatedUserId int

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
