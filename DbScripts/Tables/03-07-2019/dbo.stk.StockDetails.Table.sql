USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockDetails]    Script Date: 07/03/2019 10:01:20 AM ******/
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
