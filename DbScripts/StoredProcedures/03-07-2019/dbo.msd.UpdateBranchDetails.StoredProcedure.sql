USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.UpdateBranchDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
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
@BranchId INT,
@BranchName NVARCHAR(50),
@DisplayName NVARCHAR (50),
@PhoneNo INT,
@Address NVARCHAR(100),
@City NVARCHAR(50),
@CompanyId INT,
@CreatedUserId INT


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
		CreatedDateTime = GETDATE()
	WHERE BranchId = @BranchId AND Id = @Id
END 
GO
