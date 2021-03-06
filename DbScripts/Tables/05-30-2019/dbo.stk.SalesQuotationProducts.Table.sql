USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesQuotationProducts]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesQuotationProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID] [varchar](20) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[UnitPrice] [float] NULL,
	[Quantity] [int] NULL,
	[totalCost] [float] NULL,
	[CreatedDate] [date] NOT NULL
) ON [PRIMARY]
GO
