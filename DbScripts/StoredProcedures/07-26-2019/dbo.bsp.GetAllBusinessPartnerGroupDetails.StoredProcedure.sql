USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.GetAllBusinessPartnerGroupDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bsp.GetAllBusinessPartnerGroupDetails]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT 
	BPG.Id,
	BPG.GroupId,
	BPG.GroupName,
	CASE BPG.[BusinessPartnerTypeId]
	   WHEN 1 THEN 'Supplier'
	   WHEN 2 THEN 'Customer'
	   END AS 'BusinessPartnerTypeName',
   BPG.CreatedUserId,
   CONVERT(VARCHAR(12),BPG.CreatedDateTime,100) AS CreatedDateTime
   FROM [dbo].[bsp.BusinessPartnerGroup] BPG


END
GO
