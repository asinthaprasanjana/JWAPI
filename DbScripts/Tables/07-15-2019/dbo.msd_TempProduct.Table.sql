USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd_TempProduct]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd_TempProduct](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductGroupId] [int] NULL,
	[ProductName] [varchar](300) NOT NULL,
	[SKU] [varchar](50) NOT NULL,
	[ShortDescription] [varchar](100) NULL,
	[ProductDescription] [varchar](500) NOT NULL,
	[ProductType] [varchar](15) NULL,
	[IsTradingProduct] [bit] NULL,
	[CostingMethod] [varchar](15) NULL,
	[IncomeAccountId] [int] NULL,
	[CogsAccountId] [int] NULL,
	[AssestsAccountId] [int] NULL,
	[ReorderLevel] [decimal](18, 3) NULL,
	[ReorderQty] [decimal](18, 3) NULL,
	[UnitOfMeasure] [varchar](10) NULL,
	[CreatedUserId] [smallint] NULL,
	[CompanyId] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_msd_TempProduct] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
