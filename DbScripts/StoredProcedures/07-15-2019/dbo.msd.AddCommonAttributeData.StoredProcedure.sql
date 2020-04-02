USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddCommonAttributeData]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.AddCommonAttributeData]
	@AttributeId INT,
	@Value VARCHAR(50)
	
AS
BEGIN
		DECLARE @Id INT

		INSERT INTO [msd.CommonAttributeData]
		(
			AttributeId,
			Value
		) 
		values 
		( 
			@AttributeId,
			@Value
		)


END
GO
