USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd_AddProductCheckingDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
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
