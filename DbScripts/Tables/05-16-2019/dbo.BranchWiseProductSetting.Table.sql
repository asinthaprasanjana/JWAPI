USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[BranchWiseProductSetting]    Script Date: 16/05/2019 12:00:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchWiseProductSetting](
	[BranchWiseProductDetailID] [int] NOT NULL,
	[BranchID] [smallint] NOT NULL,
	[SalesTranslock] [bit] NOT NULL,
	[PurchaseTransLock] [bit] NOT NULL,
	[TGNTransLock] [bit] NOT NULL,
	[DiscountAllow] [bit] NOT NULL,
	[ExchangeAllow] [bit] NOT NULL,
	[UnderCostAllow] [bit] NOT NULL,
	[FreeIssueAllow] [bit] NOT NULL,
	[IncomeAccID] [int] NULL,
	[AssetAccID] [int] NULL,
	[CostOfGoodSoldAccID] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BranchWiseProductSetting] ADD  CONSTRAINT [DF_BranchWiseProductSetting_SalesTranslock]  DEFAULT ((0)) FOR [SalesTranslock]
GO
ALTER TABLE [dbo].[BranchWiseProductSetting] ADD  CONSTRAINT [DF_BranchWiseProductSetting_PurchaseTransLock]  DEFAULT ((0)) FOR [PurchaseTransLock]
GO
ALTER TABLE [dbo].[BranchWiseProductSetting] ADD  CONSTRAINT [DF_BranchWiseProductSetting_TGNTransLock]  DEFAULT ((0)) FOR [TGNTransLock]
GO
ALTER TABLE [dbo].[BranchWiseProductSetting] ADD  CONSTRAINT [DF_BranchWiseProductSetting_DiscountAllow]  DEFAULT ((0)) FOR [DiscountAllow]
GO
ALTER TABLE [dbo].[BranchWiseProductSetting] ADD  CONSTRAINT [DF_BranchWiseProductSetting_ExchangeAllow]  DEFAULT ((0)) FOR [ExchangeAllow]
GO
ALTER TABLE [dbo].[BranchWiseProductSetting] ADD  CONSTRAINT [DF_BranchWiseProductSetting_UnderCostAllow]  DEFAULT ((0)) FOR [UnderCostAllow]
GO
ALTER TABLE [dbo].[BranchWiseProductSetting] ADD  CONSTRAINT [DF_BranchWiseProductSetting_FreeIssueAllow]  DEFAULT ((0)) FOR [FreeIssueAllow]
GO
