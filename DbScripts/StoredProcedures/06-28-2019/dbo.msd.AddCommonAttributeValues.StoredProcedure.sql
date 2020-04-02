USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddCommonAttributeValues]    Script Date: 28/06/2019 4:49:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.AddCommonAttributeValues]
	@ProductId INT,
	@AttributeId INT,
	@Data VARCHAR(50),
	@DataId INT
	
AS
BEGIN
		DECLARE @Id INT

		INSERT INTO [msd.CommonAttributeValues]
		(
			ProductId,
			AttributeId,
			DataId,
			Data
		) 
		values 
		( 
			@ProductId,
			@AttributeId,
			@DataId,
			@Data
		)


END
GO
