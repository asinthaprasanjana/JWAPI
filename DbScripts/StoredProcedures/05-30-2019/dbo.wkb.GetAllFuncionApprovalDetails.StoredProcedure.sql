USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.GetAllFuncionApprovalDetails]    Script Date: 30/05/2019 11:36:25 AM ******/
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
