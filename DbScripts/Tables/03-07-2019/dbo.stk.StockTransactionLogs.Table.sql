USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransactionLogs]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransactionLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[ReferenceNo] [nvarchar](20) NOT NULL,
	[BranchId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_stk.StockTransactionLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.StockTransactionLogs] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
