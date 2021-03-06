USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateBranchDetails]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.UpdateBranchDetails]
(
@Id INT,
@BranchId SMALLINT,
@BranchName VARCHAR(50),
@DisplayName VARCHAR (50),
@BranchType  VARCHAR (50),
@BranchTypeId SMALLINT,
@PhoneNo INT,
@Address VARCHAR(100),
@City VARCHAR(50),
@CompanyId SMALLINT,
@CreatedUserId SMALLINT


)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[msd.Branch] SET
		
        BranchName =@BranchName,
		DisplayName = @DisplayName,
		City =@City,
        PhoneNo = @PhoneNo,
		Address =  @Address,
		CompanyId =@CompanyId,
		CreatedUserId = @CreatedUserId,
		BranchTypeId = @BranchTypeId,
		CreatedDateTime = GETDATE()
	WHERE BranchId = @BranchId AND Id = @Id
END 
GO
