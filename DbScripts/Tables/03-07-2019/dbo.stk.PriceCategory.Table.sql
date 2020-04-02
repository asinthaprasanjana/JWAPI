USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PriceCategory]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PriceCategory](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[CategoryName] [nvarchar](50) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
