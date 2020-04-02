USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.PurchaseOrderBilledEvents]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.PurchaseOrderBilledEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[RecievingId] [int] NULL,
	[PurchaseOrderNo] [nvarchar](10) NULL,
	[PurchaseOrderItemId] [int] NULL,
	[ProductId] [int] NULL,
	[BilledQuantity] [float] NULL,
	[BilledPrice] [float] NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
