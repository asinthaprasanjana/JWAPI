USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockSeason]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockSeason](
	[Id] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
