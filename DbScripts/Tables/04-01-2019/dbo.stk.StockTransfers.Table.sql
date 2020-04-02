USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransfers]    Script Date: 01/04/2019 9:42:50 AM ******/
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
