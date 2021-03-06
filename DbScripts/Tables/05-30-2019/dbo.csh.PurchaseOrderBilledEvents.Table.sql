USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.PurchaseOrderBilledEvents]    Script Date: 30/05/2019 11:35:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.PurchaseOrderBilledEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[RecievingId] [int] NULL,
	[PurchaseOrderNo] [varchar](10) NULL,
	[PurchaseOrderItemId] [int] NULL,
	[ProductId] [int] NULL,
	[BilledQuantity] [float] NULL,
	[BilledPrice] [float] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
