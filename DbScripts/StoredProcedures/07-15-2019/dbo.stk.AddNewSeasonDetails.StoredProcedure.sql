USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewSeasonDetails]    Script Date: 15/07/2019 12:10:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[stk.AddNewSeasonDetails]
(	
    @Id INT,
	@Name char(50),
	@StartDate datetime,
	@EndDate datetime,
	@CreatedUserId SMALLINT,
	@CreatedDateTime datetime,
	@LastModifiedUserId SMALLINT,
	@LastModifiedDateTime datetime
)

AS
BEGIN
		INSERT INTO [dbo].[stk.StockSeason]
		(
				Id,
				Name,
				StartDate,
				EndDate,
				CreatedUserId,
			    CreatedDateTime,
				LastModifiedUserId,
				LastModifiedDateTime
		) 
		values ( 
			@ID ,
		    @Name,
			@StartDate,
			@EndDate,
			@CreatedUserId, 
			GETDATE() ,
			@LastModifiedUserId,
			GETDATE()	  
		 )
END
GO
