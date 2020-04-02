USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GoodReserved]    Script Date: 30/05/2019 11:35:29 AM ******/
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
