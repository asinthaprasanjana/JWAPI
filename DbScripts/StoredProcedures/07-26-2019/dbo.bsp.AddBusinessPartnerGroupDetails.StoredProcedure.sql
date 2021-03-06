USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[bsp.AddBusinessPartnerGroupDetails]    Script Date: 26/07/2019 10:10:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[bsp.AddBusinessPartnerGroupDetails]
(
@GroupId Varchar(30),
@GroupName VARCHAR(50),
@BusinessPartnerTypeId INT,
@BusinessPartnerTypeName VARCHAR(50),
@CreatedUserId INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	INSERT INTO [dbo].[bsp.BusinessPartnerGroup]
           (
            [GroupId]
           ,[GroupName]
           ,[BusinessPartnerTypeId]
		   ,[BusinessPartnerTypeName]
           ,[CreatedUserId]
           ,[CreatedDateTime])
     VALUES
           (
		     @GroupId,
			 @GroupName,
			 @BusinessPartnerTypeId,
			 @BusinessPartnerTypeName,
			 @CreatedUserId,
			 GETDATE()
		   )


END
GO
