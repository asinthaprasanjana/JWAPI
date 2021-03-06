USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransfersItem]    Script Date: 01/04/2019 9:42:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransfersItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [smallint] NULL,
	[TransferId] [int] NULL,
	[SourceLocationId] [smallint] NULL,
	[SourceLocationName] [varchar](30) NULL,
	[DestinationLocationId] [smallint] NULL,
	[DestinationLocationName] [varchar](30) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[ItemId] [int] NULL,
	[ItemName] [varchar](30) NULL,
	[Quantity] [int] NULL,
	[stockAdjusmentId] [varchar](5) NULL,
	[Status] [int] NULL
) ON [PRIMARY]
GO
