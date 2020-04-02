USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PriceLevel]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PriceLevel](
	[Id] [int] NULL,
	[PriceLevelId] [int] NULL,
	[PriceLevelName] [varchar](50) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
