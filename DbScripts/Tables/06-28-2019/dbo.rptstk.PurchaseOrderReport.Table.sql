USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[rptstk.PurchaseOrderReport]    Script Date: 28/06/2019 4:47:49 PM ******/
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
