USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PriceLevel]    Script Date: 07/03/2019 10:01:20 AM ******/
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
