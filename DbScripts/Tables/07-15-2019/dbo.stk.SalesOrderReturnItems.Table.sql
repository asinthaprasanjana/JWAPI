USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesOrderReturnItems]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesOrderReturnItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaleOrderReturnId] [varchar](20) NOT NULL,
	[CompanyId] [smallint] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[ReturningQuantity] [float] NOT NULL,
	[ReturningPrice] [money] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_stk.SalesOrderReturnItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
