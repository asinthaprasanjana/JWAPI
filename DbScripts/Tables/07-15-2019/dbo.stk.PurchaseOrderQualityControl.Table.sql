USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderQualityControl]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderQualityControl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseNo] [varchar](20) NOT NULL,
	[PurchaseOrderItemId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[PackSizeId] [int] NOT NULL,
	[TotalQuantity] [float] NOT NULL,
	[ReturnningQuantity] [float] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderQualityControl] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
