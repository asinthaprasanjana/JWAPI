USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PriceLevel]    Script Date: 30/05/2019 11:35:29 AM ******/
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
