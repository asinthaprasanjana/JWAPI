USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransactionLogs]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransactionLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeId] [smallint] NOT NULL,
	[ReferenceNo] [varchar](20) NOT NULL,
	[BranchId] [smallint] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[PackSizeId] [int] NULL,
	[Quantity] [float] NOT NULL,
	[BaseUnitQuantity] [float] NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_stk.StockTransactionLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.StockTransactionLogs] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
