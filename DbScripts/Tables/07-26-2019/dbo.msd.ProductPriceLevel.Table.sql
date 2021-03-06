USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ProductPriceLevel]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.ProductPriceLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[PriceLevelName] [varchar](50) NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.ProductPriceLevel] ADD  CONSTRAINT [DF__msd.Produ__Creat__1B73E779]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
