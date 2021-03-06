USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.UpdateSeasonDetails]    Script Date: 15/07/2019 12:10:19 PM ******/
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
	@Id int,
	@Name varchar(50),
	@StartDate datetime,
	@EndDate datetime,
	@CreatedUserId smallint,
	@LastModifiedUserId smallint
	
	
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
