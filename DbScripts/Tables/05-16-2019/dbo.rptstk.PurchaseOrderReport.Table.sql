USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[rptstk.PurchaseOrderReport]    Script Date: 16/05/2019 12:00:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rptstk.PurchaseOrderReport](
	[Id] [int] NULL,
	[Month] [varchar](50) NULL,
	[Count] [int] NULL,
	[CompanyId] [int] NULL,
	[Status] [nvarchar](10) NULL
) ON [PRIMARY]
GO
