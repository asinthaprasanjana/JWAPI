USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd_AddProductCheckingDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd_AddProductCheckingDetails]
	@ProductId INT,
	@ProductCheckingId INT,
	@BranchId INT,
	@CreatedUserId INT
AS
BEGIN
		INSERT INTO [msd_ProductChecking]
		(
			ProductId,
			ProductCheckingId,
			BranchId,
			CreatedUserId
		) 
		values 
		( 
			@ProductId,
			@ProductCheckingId,
			@BranchId,
			@CreatedUserId	
		)
		
END
GO
