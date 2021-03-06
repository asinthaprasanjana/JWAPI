USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddBranch]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.AddBranch]
	
	
	@BranchName NVARCHAR(50),
	@DisplayName NVARCHAR(50),
	@BranchTypeId INT,
	@PhoneNo INT,
	@Address NVARCHAR(100),
	@City NVARCHAR(50),
	@CompanyId INT,
	@CreatedUserId INT
	
AS
BEGIN
		INSERT INTO [dbo].[msd.Branch]
           (
            [BranchName]
           ,[DisplayName],
		   [BranchTypeId]
		   ,[PhoneNo]
		   ,[Address]
           ,[City]
           ,[CompanyId]
           ,[CreatedUserId]
           ,[CreatedDateTime])
		values 
		( 
			
			
			@BranchName,
			@DisplayName,
			@BranchTypeId,
			@PhoneNo,
			@Address,
			@City,
			@CompanyId,
			@CreatedUserId ,
			GETDATE() 	 	  
		)
END
GO
