USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockDetails]    Script Date: 16/05/2019 12:00:28 PM ******/
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
