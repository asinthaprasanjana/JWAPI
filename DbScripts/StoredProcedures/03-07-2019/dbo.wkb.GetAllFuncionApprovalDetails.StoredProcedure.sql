USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.GetAllFuncionApprovalDetails]    Script Date: 07/03/2019 10:02:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.GetAllFuncionApprovalDetails] 
AS
BEGIN

       
     SELECT 
	 AT.ApprovalTypeId,
	 AT.ApprovalName,
	 AT.CompanyId,
	 AT.IsActive,
	 ATOD.ApprovalOfficersId
	 FROM [wkb.ApprovalTypes] AT 
	 INNER JOIN [wkb.ApprovalTypeOwnDetails] ATOD ON ATOD.ApprovalTypeId = AT.ApprovalTypeId
END 

GO
