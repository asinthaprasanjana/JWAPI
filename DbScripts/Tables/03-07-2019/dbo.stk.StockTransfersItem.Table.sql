USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransfersItem]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransfersItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[TransferId] [int] NULL,
	[SourceLocationId] [int] NULL,
	[SourceLocationName] [nvarchar](30) NULL,
	[DestinationLocationId] [int] NULL,
	[DestinationLocationName] [nvarchar](30) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[ItemId] [int] NULL,
	[ItemName] [nvarchar](30) NULL,
	[Quantity] [int] NULL,
	[stockAdjusmentId] [nvarchar](5) NULL,
	[Status] [int] NULL
) ON [PRIMARY]
GO
