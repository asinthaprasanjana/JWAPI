USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.AddNewCancellationDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
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
