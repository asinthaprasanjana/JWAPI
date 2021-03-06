USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockDraftTransfersItem]    Script Date: 01/04/2019 9:42:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockDraftTransfersItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[TransferId] [nvarchar](30) NULL,
	[SourceLocationId] [int] NULL,
	[SourceLocationName] [nvarchar](30) NULL,
	[DestinationLocationId] [int] NULL,
	[DestinationLocationName] [nvarchar](30) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[ItemId] [int] NULL,
	[ItemName] [nvarchar](30) NULL,
	[Quantity] [int] NULL
) ON [PRIMARY]
GO
