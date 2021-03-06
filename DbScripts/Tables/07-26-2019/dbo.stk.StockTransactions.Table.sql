USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransactions]    Script Date: 26/07/2019 10:08:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[TransactionTypeId] [int] NULL,
	[TransactionId] [int] NULL,
	[ReferenceNo] [int] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.StockTransactions] ADD  DEFAULT ((1)) FOR [TransactionId]
GO
ALTER TABLE [dbo].[stk.StockTransactions] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
