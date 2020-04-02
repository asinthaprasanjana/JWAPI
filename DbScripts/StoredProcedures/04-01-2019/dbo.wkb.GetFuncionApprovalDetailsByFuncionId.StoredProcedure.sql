USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[wkb.GetFuncionApprovalDetailsByFuncionId]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[wkb.GetFuncionApprovalDetailsByFuncionId] 
	@CompanyId    SMALLINT,
	@FunctionId    SMALLINT
AS
BEGIN

       
     SELECT TOP 1
	 AT.ApprovalTypeId,
	 AT.IsActive,
	 ATD.ApprovalOfficersId
	 FROM [wkb.ApprovalTypes] AT 
	 INNER JOIN [wkb.ApprovalTypeOwnDetails] ATD ON AT.ApprovalTypeId =ATD.ApprovalTypeId
	 WHERE AT.CompanyId = @CompanyId AND AT.ApprovalTypeId = @FunctionId
END

GO
