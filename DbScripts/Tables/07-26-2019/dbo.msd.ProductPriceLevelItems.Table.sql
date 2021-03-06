USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ProductPriceLevelItems]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.ProductPriceLevelItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductPriceLevelId] [int] NOT NULL,
	[BranchId] [smallint] NOT NULL,
	[ProductId] [int] NULL,
	[PackSizeId] [int] NOT NULL,
	[PriceType] [smallint] NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.ProductPriceLevelItems] ADD  CONSTRAINT [DF__msd.Produ__Price__1E505424]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[msd.ProductPriceLevelItems] ADD  CONSTRAINT [DF__msd.Produ__Creat__1D5C2FEB]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
