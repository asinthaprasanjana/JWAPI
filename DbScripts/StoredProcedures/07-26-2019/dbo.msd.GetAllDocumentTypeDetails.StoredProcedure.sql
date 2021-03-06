USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.GetAllDocumentTypeDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Ruchika Perera
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.GetAllDocumentTypeDetails]


AS
BEGIN
	 --SET NOCOUNT ON added to prevent extra result sets from
	 --interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT 
	DT.DocumentTypeId,
	DT.DocumentTypeName,

	CONVERT(VARCHAR(12), ( SELECT TOP 1 D.CreatedDateTime FROM [msd.DocumentTypeDetails] D WHERE D.DocumentTypeId = DT.DocumentTypeId ORDER BY D.Id DESC ), 100) AS 'Date',
	( SELECT TOP 1 D.Text FROM [msd.DocumentTypeDetails] D WHERE D.DocumentTypeId = DT.DocumentTypeId ORDER BY D.Id DESC ) AS 'Text',
	( SELECT TOP 1 D.Number FROM [msd.DocumentTypeDetails] D WHERE D.DocumentTypeId = DT.DocumentTypeId  ORDER BY D.Id DESC) AS 'Number'

	FROM [dbo].[msd.DocumentTypeDetails] DT
--	INNER JOIN [msd.ApplicationUserLogInDetails] AU ON AU.UserId = DT.CreatedUserId
	GROUP BY DT.DocumentTypeId , DT.DocumentTypeName   --,DT.CreatedDateTime 
	ORDER BY DT.DocumentTypeId
	
END 
GO
