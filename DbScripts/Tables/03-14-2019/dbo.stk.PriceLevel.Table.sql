USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PriceLevel]    Script Date: 14/03/2019 11:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PriceLevel](
	[Id] [int] NULL,
	[PriceLevelId] [int] NULL,
	[PriceLevelName] [nvarchar](50) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
