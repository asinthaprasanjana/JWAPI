USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransferSummeryDraftDetails]    Script Date: 26/07/2019 10:08:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransferSummeryDraftDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransferId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[CompanyID] [int] NULL,
	[SourceLocationId] [int] NULL,
	[SourceLocationName] [varchar](30) NULL,
	[DestinationLocationId] [int] NULL,
	[DestinationLocationName] [varchar](30) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
