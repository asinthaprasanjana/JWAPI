USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd_Product]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd_Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductGroupId] [smallint] NULL,
	[LevelId01] [smallint] NOT NULL,
	[LevelId02] [smallint] NULL,
	[LevelId03] [smallint] NULL,
	[LevelId04] [smallint] NULL,
	[LevelId05] [smallint] NULL,
	[ProductName] [varchar](200) NOT NULL,
	[SKU] [varchar](50) NOT NULL,
	[ShortDescription] [varchar](100) NULL,
	[ProductDescription] [varchar](300) NOT NULL,
	[ProductType] [varchar](15) NULL,
	[IsTradingProduct] [bit] NULL,
	[CostingMethod] [varchar](15) NULL,
	[IncomeAccountId] [int] NULL,
	[CogsAccountId] [int] NULL,
	[AssestsAccountId] [int] NULL,
	[ReorderLevel] [decimal](18, 0) NULL,
	[ReorderQty] [decimal](18, 0) NULL,
	[UnitOfMeasure] [varchar](10) NULL,
	[CreatedUserId] [smallint] NULL,
	[CompanyId] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_msd_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd_Product] ADD  DEFAULT ((0)) FOR [LevelId01]
GO
ALTER TABLE [dbo].[msd_Product] ADD  DEFAULT ((0)) FOR [LevelId02]
GO
ALTER TABLE [dbo].[msd_Product] ADD  DEFAULT ((0)) FOR [LevelId03]
GO
ALTER TABLE [dbo].[msd_Product] ADD  DEFAULT ((0)) FOR [LevelId04]
GO
ALTER TABLE [dbo].[msd_Product] ADD  DEFAULT ((0)) FOR [LevelId05]
GO
ALTER TABLE [dbo].[msd_Product] ADD  CONSTRAINT [DF_msd_Product_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
