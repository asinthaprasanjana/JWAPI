USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PriceCategory]    Script Date: 16/05/2019 12:00:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PriceCategory](
	[Id] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[CategoryName] [varchar](50) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
