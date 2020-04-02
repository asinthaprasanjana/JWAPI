USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.BusinessPartnerBanks]    Script Date: 28/06/2019 4:47:48 PM ******/
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
