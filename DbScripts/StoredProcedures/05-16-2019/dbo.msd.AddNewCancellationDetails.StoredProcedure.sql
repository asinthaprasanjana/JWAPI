USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddNewCancellationDetails]    Script Date: 16/05/2019 12:39:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[msd.AddNewCancellationDetails]
(
 @CancellationTypeId INT,
 @ReferenceNumber VARCHAR(20),
 @Reason VARCHAR(100),
 @CreatedUserId SMALLINT
 )
AS
BEGIN
		INSERT INTO [dbo].[msd.Cancellation]
           (
		    [CancellationTypeId]
           ,[ReferenceNumber]
           ,[Reason]
           ,[CreatedUserId]
           ,[CreatedDateTime]
		   
		   )
     VALUES
		( 
		   @CancellationTypeId,
		   @ReferenceNumber,
		   @Reason,
		   @CreatedUserId,
		   GETDATE()
		)

END
GO
