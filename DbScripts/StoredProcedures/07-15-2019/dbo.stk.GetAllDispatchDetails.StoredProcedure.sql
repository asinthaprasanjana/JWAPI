USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllDispatchDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.GetAllDispatchDetails]
(
@DispatchTypeId INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@DispatchTypeId=1)
		BEGIN
			SELECT D.ProductName,
			       D.PackSizeName,
				   D.Quantity,
				   D.ReasonName
			FROM [dbo].[stk.Dispatch] D
		END
    ELSE
		BEGIN
			 SELECT
			 g.Id,
			 g.DocumentNumber,
			 g.BusinessPartnerId,
			 g.BusinessPartnerTypeId,
			 g.RecieveStatus,
			 g.ContactDetail,
			 g.CreatedUserId,
			 b.DisplayName as BusinessPartnerName,
			 CONVERT(VARCHAR(12), g.CreatedDateTime, 100)  AS 'Date'
			 FROM [dbo].[stk.GatePassDetails] g inner join [dbo].[bsp.BusinessPartner] b on
			 g.BusinessPartnerId = b.BusinessPartnerId

		END
END
GO
