USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.SalesOrderInvoicedItems]    Script Date: 26/07/2019 10:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.SalesOrderInvoicedItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [smallint] NOT NULL,
	[InvoiceNo] [varchar](20) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PackSizeId] [smallint] NULL,
	[ItemCost] [decimal](18, 0) NOT NULL,
	[Discount] [decimal](18, 0) NULL,
	[Tax] [decimal](18, 0) NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_csh.SalesOrderInvoicedItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
