USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockAdjustmentDetails]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockAdjustmentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StockAdjustmentId] [varchar](20) NULL,
	[ProductId] [int] NULL,
	[ProductName] [varchar](20) NULL,
	[PackSizeId] [int] NULL,
	[SupplierCode] [varchar](20) NULL,
	[NewQuantity] [int] NULL,
	[AvailableStock] [int] NULL,
	[Variance] [int] NULL,
	[Comment] [varchar](20) NULL,
	[createdDateTime] [datetime] NULL
) ON [PRIMARY]
GO
