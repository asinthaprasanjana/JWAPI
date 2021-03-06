USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddBranch]    Script Date: 30/05/2019 11:36:25 AM ******/
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
	
	
	@BranchName VARCHAR(50),
	@DisplayName VARCHAR(50),
	@BranchTypeId INT,
	@PhoneNo INT,
	@Address VARCHAR(100),
	@City VARCHAR(50),
	@CompanyId INT,
	@CreatedUserId SMALLINT
	
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
