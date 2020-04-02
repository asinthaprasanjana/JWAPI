USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GoodReserved]    Script Date: 01/04/2019 9:42:49 AM ******/
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
