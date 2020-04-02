USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddCommonAttributeValues]    Script Date: 16/05/2019 12:39:08 PM ******/
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
	@Value VARCHAR(50)
	
AS
BEGIN
		DECLARE @Id INT

		INSERT INTO [msd.CommonAttributeValues]
		(
			ProductId,
			AttributeId,
			Value
		) 
		values 
		( 
			@ProductId,
			@AttributeId,
			@Value
		)


END
GO
