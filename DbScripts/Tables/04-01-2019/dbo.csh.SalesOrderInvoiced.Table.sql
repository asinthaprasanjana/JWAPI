USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.SalesOrderInvoiced]    Script Date: 01/04/2019 9:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.SalesOrderInvoiced](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[SaleNo] [varchar](20) NOT NULL,
	[CustomerInvoiceNo] [varchar](25) NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[InvoiceDate] [date] NULL,
	[PaymentStatus] [tinyint] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[csh.SalesOrderInvoiced] ADD  DEFAULT ((0)) FOR [PaymentStatus]
GO
ALTER TABLE [dbo].[csh.SalesOrderInvoiced] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
