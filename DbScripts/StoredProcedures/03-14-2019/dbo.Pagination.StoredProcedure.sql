USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[Pagination]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Pagination] 
(
  @PageNumber SMALLINT,
  @RowsPage   SMALLINT
   )

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT *
FROM [stk.purchaseOrder]ORDER BY id
OFFSET ((@PageNumber - 1) * @RowsPage) ROWS
FETCH NEXT @RowsPage ROWS ONLY;
END
GO
