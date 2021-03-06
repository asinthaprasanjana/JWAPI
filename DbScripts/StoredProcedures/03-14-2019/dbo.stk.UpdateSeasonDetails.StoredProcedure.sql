USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateSeasonDetails]    Script Date: 14/03/2019 11:47:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.UpdateSeasonDetails]
(
	 @Id INT,
	@Name nvarchar(50),
	@StartDate datetime,
	@EndDate datetime,
	@CreatedUserId int,
	@LastModifiedUserId int
	
	
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [stk.StockSeason] SET
	             Id =@Id ,
				Name = @Name,
				StartDate = @StartDate,
				EndDate =@EndDate ,
				CreatedUserId = @CreatedUserId,
			    CreatedDateTime =GETDATE(),
				LastModifiedUserId = @LastModifiedUserId,
				LastModifiedDateTime = GETDATE()
	    WHERE CreatedUserId = @CreatedUserId 
	

END
GO
