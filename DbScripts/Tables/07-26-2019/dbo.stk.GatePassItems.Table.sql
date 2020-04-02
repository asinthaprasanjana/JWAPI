USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GatePassItems]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.GatePassItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNumber] [varchar](50) NULL,
	[ProductId] [int] NULL,
	[ProductName] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[PackSizeName] [varchar](50) NULL,
	[PackSizeId] [int] NULL
) ON [PRIMARY]
GO
