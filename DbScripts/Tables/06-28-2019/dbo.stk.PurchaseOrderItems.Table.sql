USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderItems]    Script Date: 28/06/2019 4:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[PurchaseNo] [varchar](20) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[packSizeId] [int] NULL,
	[PackSizeName] [varchar](50) NULL,
	[Quantity] [float] NOT NULL,
	[QuantityAfter] [float] NULL,
	[ItemCost] [decimal](18, 0) NOT NULL,
	[Discount] [decimal](18, 0) NULL,
	[Tax] [decimal](18, 0) NULL,
	[TotalCost] [decimal](18, 0) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_stk.PurchaseOrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
