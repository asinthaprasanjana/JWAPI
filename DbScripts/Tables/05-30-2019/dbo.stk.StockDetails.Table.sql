USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockDetails]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockDetails](
	[Id] [varchar](50) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Quantity] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
