USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.SalesOrderInvoiced]    Script Date: 26/07/2019 10:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.SalesOrderInvoiced](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[InvoiceType] [smallint] NULL,
	[InvoiceNo] [varchar](25) NOT NULL,
	[SaleNo] [varchar](20) NULL,
	[CustomerId] [varchar](25) NOT NULL,
	[GrossTotal] [decimal](18, 0) NOT NULL,
	[NetTotal] [decimal](18, 0) NOT NULL,
	[PaidPrice] [decimal](18, 0) NOT NULL,
	[TotalTax] [decimal](18, 0) NULL,
	[TotalDiscounts] [decimal](18, 0) NULL,
	[ApprovalStatus] [smallint] NULL,
	[InvoiceDate] [date] NULL,
	[PaymentStatus] [tinyint] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[csh.SalesOrderInvoiced] ADD  DEFAULT ((0)) FOR [PaidPrice]
GO
ALTER TABLE [dbo].[csh.SalesOrderInvoiced] ADD  DEFAULT ((0)) FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[csh.SalesOrderInvoiced] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
