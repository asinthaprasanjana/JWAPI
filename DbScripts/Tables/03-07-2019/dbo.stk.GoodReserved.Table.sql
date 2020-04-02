USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GoodReserved]    Script Date: 07/03/2019 10:01:20 AM ******/
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
