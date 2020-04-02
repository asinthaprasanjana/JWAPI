USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockDraftTransfersItem]    Script Date: 28/06/2019 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockDraftTransfersItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[TransferId] [varchar](30) NULL,
	[SourceLocationId] [int] NULL,
	[SourceLocationName] [varchar](30) NULL,
	[DestinationLocationId] [int] NULL,
	[DestinationLocationName] [varchar](30) NULL,
	[ItemId] [int] NULL,
	[ItemName] [varchar](50) NULL,
	[PackSizeId] [int] NULL,
	[Quantity] [int] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
