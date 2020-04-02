USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.Currency]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.Currency](
	[id] [int] NULL,
	[CompanyId] [int] NULL,
	[CurrencyId] [int] NULL,
	[CurryncyName] [nvarchar](20) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[DisplayName] [nvarchar](10) NULL
) ON [PRIMARY]
GO
