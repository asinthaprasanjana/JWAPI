USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.PurchaseOrderBilledEvents]    Script Date: 28/06/2019 4:47:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.PurchaseOrderBilledEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[CompanyId] [smallint] NULL,
	[RecievingId] [int] NULL,
	[PurchaseOrderNo] [varchar](10) NULL,
	[PurchaseOrderItemId] [int] NULL,
	[ProductId] [int] NULL,
	[BilledQuantity] [float] NULL,
	[BilledPrice] [decimal](18, 0) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[csh.PurchaseOrderBilledEvents] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
