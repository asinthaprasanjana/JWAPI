USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.Currency]    Script Date: 28/06/2019 4:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.Currency](
	[id] [int] NULL,
	[CompanyId] [int] NULL,
	[CurrencyId] [int] NULL,
	[CurryncyName] [varchar](20) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[DisplayName] [varchar](10) NULL
) ON [PRIMARY]
GO
