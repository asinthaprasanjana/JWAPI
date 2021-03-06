USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[stk.AddNewSeasonDetails]    Script Date: 14/03/2019 11:47:02 AM ******/
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
	@Name nchar(50),
	@StartDate datetime,
	@EndDate datetime,
	@CreatedUserId int,
	@CreatedDateTime datetime,
	@LastModifiedUserId int,
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
