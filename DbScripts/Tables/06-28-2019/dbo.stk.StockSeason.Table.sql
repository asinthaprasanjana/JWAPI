USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockSeason]    Script Date: 28/06/2019 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockSeason](
	[Id] [int] NULL,
	[Name] [varchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
