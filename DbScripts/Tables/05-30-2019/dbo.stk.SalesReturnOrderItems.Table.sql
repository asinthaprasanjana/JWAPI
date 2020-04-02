USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesReturnOrderItems]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesReturnOrderItems](
	[Id] [int] NOT NULL,
	[SaleOrderReturnId] [varchar](20) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[SaleNo] [varchar](20) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[Quantity] [float] NOT NULL,
	[ItemCost] [money] NOT NULL,
	[Discount] [money] NULL,
	[Tax] [money] NULL,
	[TotalCost] [money] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_stk.SalesReturnOrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
