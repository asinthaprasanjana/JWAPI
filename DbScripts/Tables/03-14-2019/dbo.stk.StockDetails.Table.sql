USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockDetails]    Script Date: 14/03/2019 11:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockDetails](
	[Id] [nvarchar](50) NOT NULL,
	[Location] [nvarchar](50) NOT NULL,
	[Quantity] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
