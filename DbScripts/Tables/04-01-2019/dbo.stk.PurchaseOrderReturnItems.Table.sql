USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderReturnItems]    Script Date: 01/04/2019 9:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderReturnItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseOrderReturnId] [varchar](20) NOT NULL,
	[Reason] [varchar](20) NULL,
	[CompanyId] [smallint] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ReturningQuantity] [float] NOT NULL,
	[ReturningPrice] [money] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_stk.PurchaseOrderReturnItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
