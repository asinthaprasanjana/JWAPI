USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesQuotationProducts]    Script Date: 01/04/2019 9:42:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesQuotationProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID] [varchar](20) NULL,
	[ProductID] [int] NULL,
	[UnitPrice] [float] NULL,
	[Quantity] [int] NULL,
	[totalCost] [float] NULL,
	[CreatedDate] [date] NOT NULL
) ON [PRIMARY]
GO
