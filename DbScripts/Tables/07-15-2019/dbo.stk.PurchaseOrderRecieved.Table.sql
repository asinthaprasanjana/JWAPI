USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderRecieved]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderRecieved](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [smallint] NOT NULL,
	[PurchaseNo] [varchar](20) NOT NULL,
	[PurchaseOrderItemId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[PackSizeId] [int] NULL,
	[PackSizeName] [varchar](50) NULL,
	[TotalQuantity] [float] NOT NULL,
	[TempRecievedQuantity] [float] NOT NULL,
	[OrginalRecievedQuantity] [float] NOT NULL,
	[FreeQuantity] [float] NULL,
	[ReturningQuantity] [float] NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecieved] ADD  DEFAULT ((0)) FOR [TotalQuantity]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecieved] ADD  DEFAULT ((0)) FOR [TempRecievedQuantity]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecieved] ADD  DEFAULT ((0)) FOR [OrginalRecievedQuantity]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecieved] ADD  DEFAULT ((0)) FOR [FreeQuantity]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecieved] ADD  DEFAULT ((0)) FOR [ReturningQuantity]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecieved] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
