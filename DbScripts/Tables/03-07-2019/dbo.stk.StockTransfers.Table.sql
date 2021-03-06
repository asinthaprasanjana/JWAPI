USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransfers]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransfers](
	[Id] [int] NULL,
	[CompanyID] [int] NULL,
	[StockTransferId] [int] NULL,
	[SourceLocationId] [int] NULL,
	[SourceLocationName] [nvarchar](30) NULL,
	[DestinationLocationId] [int] NULL,
	[DestinationLocationName] [nvarchar](30) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
