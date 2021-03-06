USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesQuotationProducts]    Script Date: 15/07/2019 12:08:38 PM ******/
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
