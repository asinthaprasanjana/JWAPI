USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[ntm.getAllNotificationTypeDetail]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ntm.getAllNotificationTypeDetail]
(	
  @CompanyId INT

)

AS
BEGIN
	SELECT * 
	FROM [ntm.NotificationTypeDetails]
	WHERE CompanyId = @companyId
END
GO
