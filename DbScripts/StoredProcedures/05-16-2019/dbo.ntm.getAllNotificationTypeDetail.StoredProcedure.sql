USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[ntm.getAllNotificationTypeDetail]    Script Date: 16/05/2019 12:39:09 PM ******/
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
