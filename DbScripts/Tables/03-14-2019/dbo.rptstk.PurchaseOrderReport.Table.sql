USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[rptstk.PurchaseOrderReport]    Script Date: 14/03/2019 11:45:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rptstk.PurchaseOrderReport](
	[Id] [int] NULL,
	[Month] [nvarchar](50) NULL,
	[Count] [int] NULL,
	[CompanyId] [int] NULL,
	[Status] [nvarchar](10) NULL
) ON [PRIMARY]
GO
