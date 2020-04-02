USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.BusinessPartnerBanks]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.BusinessPartnerBanks](
	[Id] [int] NULL,
	[BankId] [int] NULL,
	[BankName] [varchar](50) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
