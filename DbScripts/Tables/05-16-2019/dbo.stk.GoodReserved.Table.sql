USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GoodReserved]    Script Date: 16/05/2019 12:00:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.GoodReserved](
	[Id] [int] NULL,
	[PurchaseNo] [int] NULL,
	[ItemId] [int] NULL,
	[Quantity] [int] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
