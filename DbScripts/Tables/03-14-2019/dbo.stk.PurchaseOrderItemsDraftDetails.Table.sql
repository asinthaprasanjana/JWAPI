USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderItemsDraftDetails]    Script Date: 14/03/2019 11:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderItemsDraftDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[PurchaseNo] [nvarchar](15) NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[QuantityAfter] [float] NOT NULL,
	[ItemCost] [money] NOT NULL,
	[Discount] [money] NOT NULL,
	[Tax] [money] NOT NULL,
	[TotalCost] [money] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_stk.PurchaseOrderItemsDraftDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
