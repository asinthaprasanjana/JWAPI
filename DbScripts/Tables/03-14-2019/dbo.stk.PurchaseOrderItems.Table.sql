USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderItems]    Script Date: 14/03/2019 11:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[PurchaseNo] [nvarchar](20) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[QuantityAfter] [float] NULL,
	[ItemCost] [money] NOT NULL,
	[Discount] [money] NULL,
	[Tax] [money] NULL,
	[TotalCost] [money] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_stk.PurchaseOrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
