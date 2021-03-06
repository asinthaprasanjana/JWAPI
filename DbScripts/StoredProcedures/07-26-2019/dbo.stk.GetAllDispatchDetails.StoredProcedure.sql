USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.GetAllDispatchDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
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
			SELECT
				   D.ReasonName
			FROM [dbo].[stk.Dispatch] D
		END
    ELSE
		BEGIN
			 SELECT 
			g.Id,
			b.DisplayName as BusinessPartnerName,
			g.RecieveStatus,
			g.Reason,
			CONVERT(VARCHAR(12), g.CreatedDateTime, 100)  AS 'Date',
			CONVERT(VARCHAR(12),g.ReturnDate,100) AS 'ReturnDate'
			FROM [dbo].[stk.GatePass] g inner join [dbo].[bsp.BusinessPartner] b on
			g.BusinessPartnerId = b.BusinessPartnerId

		END
END
GO
