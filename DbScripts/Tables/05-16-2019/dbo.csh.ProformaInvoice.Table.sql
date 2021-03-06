USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.ProformaInvoice]    Script Date: 16/05/2019 12:00:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.ProformaInvoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[SaleNo] [varchar](20) NOT NULL,
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
ALTER TABLE [dbo].[csh.ProformaInvoice] ADD  DEFAULT ((0)) FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[csh.ProformaInvoice] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
