USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.Currency]    Script Date: 26/07/2019 10:08:53 AM ******/
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
