USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddCommonGroup]    Script Date: 30/05/2019 11:36:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.AddCommonGroup]
	@GroupName VARCHAR(50)
AS
BEGIN
		DECLARE @Id INT

		INSERT INTO [msd.CommonGroups]
		(
			GroupName
		) 
		values 
		( 
			@GroupName
		)

		SELECT @Id=SCOPE_IDENTITY()

		SELECT * 
		FROM [msd.CommonGroups] CG 
		WHERE CG.Id = @Id


END
GO
