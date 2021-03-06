USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransferSummeryDraftDetails]    Script Date: 01/04/2019 9:42:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransferSummeryDraftDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransferId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[CompanyID] [int] NULL,
	[SourceLocationId] [int] NULL,
	[SourceLocationName] [nvarchar](30) NULL,
	[DestinationLocationId] [int] NULL,
	[DestinationLocationName] [nvarchar](30) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
