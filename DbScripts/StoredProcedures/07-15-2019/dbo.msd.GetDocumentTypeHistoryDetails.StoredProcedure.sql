USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetDocumentTypeHistoryDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetDocumentTypeHistoryDetails]
(
@DocumentTypeId SMALLINT,
@UserId SMALLINT
)
AS
BEGIN
	 --SET NOCOUNT ON added to prevent extra result sets from
	 --interfering with SELECT statements.
	SET NOCOUNT ON;

	Select *
	FROM [dbo].[msd.DocumentTypeDetails]
	WHERE DocumentTypeId = @DocumentTypeId 
END 
GO
