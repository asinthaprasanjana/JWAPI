USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockAdjustmentDetails]    Script Date: 01/04/2019 9:42:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockAdjustmentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StockAdjustmentId] [nvarchar](20) NULL,
	[ProductId] [int] NULL,
	[ProductName] [nvarchar](20) NULL,
	[SupplierCode] [nvarchar](20) NULL,
	[NewQuantity] [int] NULL,
	[AvailableStock] [int] NULL,
	[Variance] [int] NULL,
	[Comment] [nvarchar](20) NULL,
	[createdDateTime] [datetime] NULL
) ON [PRIMARY]
GO
