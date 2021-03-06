USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddNewWareHouseDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.AddNewWareHouseDetails]
(
@Id INT,
@WareHouseId INT,
@BranchId INT,
@Code VARCHAR(50),
@Volume INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[msd.WareHouse]
           ([Id]
           ,[WareHouseId]
           ,[BranchId]
           ,[Code]
           ,[Volume])
     VALUES(
			 @Id,
			 @WareHouseId,
			 @BranchId,
			 @Code,
			 @Volume
			 )

END
GO
