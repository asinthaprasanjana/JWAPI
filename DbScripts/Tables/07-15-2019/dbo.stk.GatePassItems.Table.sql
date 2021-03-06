USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GatePassItems]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.GatePassItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNumber] [varchar](50) NULL,
	[GatePassDetailsID] [int] NULL,
	[ProductId] [int] NULL,
	[ProductName] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[PackSizeName] [varchar](50) NULL,
	[PackSizeId] [int] NULL,
	[ReturnDate] [datetime] NULL,
	[Reason] [varchar](200) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
