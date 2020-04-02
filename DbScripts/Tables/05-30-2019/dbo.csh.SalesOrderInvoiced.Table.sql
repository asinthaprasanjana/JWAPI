USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.SalesOrderInvoiced]    Script Date: 30/05/2019 11:35:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.SalesOrderInvoiced](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[InvoiceType] [smallint] NULL,
	[SaleNo] [varchar](20) NULL,
	[InvoiceNo] [varchar](25) NOT NULL,
	[CustomerId] [varchar](25) NOT NULL,
	[GrossTotal] [decimal](18, 0) NOT NULL,
	[NetTotal] [decimal](18, 0) NOT NULL,
	[TotalTax] [decimal](18, 0) NULL,
	[TotalDiscounts] [decimal](18, 0) NULL,
	[ApprovalStatus] [smallint] NULL,
	[InvoiceDate] [date] NULL,
	[PaymentStatus] [tinyint] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[csh.SalesOrderInvoiced] ADD  DEFAULT ((0)) FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[csh.SalesOrderInvoiced] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
