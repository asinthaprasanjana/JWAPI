USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.PurchaseOrderBilled]    Script Date: 28/06/2019 4:47:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.PurchaseOrderBilled](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[DocumentNo] [varchar](20) NOT NULL,
	[PurchaseOrderNo] [varchar](20) NOT NULL,
	[SupplierBillNo] [varchar](25) NOT NULL,
	[BillDate] [date] NULL,
	[TotalPrice] [decimal](18, 0) NOT NULL,
	[PaidPrice] [decimal](18, 0) NOT NULL,
	[PaymentStatus] [tinyint] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[csh.PurchaseOrderBilled] ADD  DEFAULT ((0)) FOR [PaidPrice]
GO
ALTER TABLE [dbo].[csh.PurchaseOrderBilled] ADD  DEFAULT ((0)) FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[csh.PurchaseOrderBilled] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
