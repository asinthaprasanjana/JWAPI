USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GoodReserved]    Script Date: 14/03/2019 11:45:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.GoodReserved](
	[Id] [int] NULL,
	[PurchaseNo] [int] NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
