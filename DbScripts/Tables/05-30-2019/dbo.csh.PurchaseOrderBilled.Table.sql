USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.PurchaseOrderBilled]    Script Date: 30/05/2019 11:35:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.PurchaseOrderBilled](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[PurchaseOrderNo] [varchar](20) NOT NULL,
	[SupplierBillNo] [varchar](25) NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[BillDate] [date] NULL,
	[PaymentStatus] [tinyint] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[csh.PurchaseOrderBilled] ADD  DEFAULT ((0)) FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[csh.PurchaseOrderBilled] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
