USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransfers]    Script Date: 26/07/2019 10:08:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransfers](
	[Id] [int] NULL,
	[CompanyID] [int] NULL,
	[StockTransferId] [int] NULL,
	[SourceLocationId] [int] NULL,
	[SourceLocationName] [varchar](30) NULL,
	[DestinationLocationId] [int] NULL,
	[DestinationLocationName] [varchar](30) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
