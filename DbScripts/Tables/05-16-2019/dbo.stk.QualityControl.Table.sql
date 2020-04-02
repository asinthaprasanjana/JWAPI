USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.QualityControl]    Script Date: 16/05/2019 12:00:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.QualityControl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [smallint] NULL,
	[PurchaseNo] [varchar](20) NOT NULL,
	[PurchaseOrderItemId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[PackSizeId] [int] NULL,
	[TotalQuantity] [float] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.QualityControl] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
