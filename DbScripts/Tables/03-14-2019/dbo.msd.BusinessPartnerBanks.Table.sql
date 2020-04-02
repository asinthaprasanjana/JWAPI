USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.BusinessPartnerBanks]    Script Date: 14/03/2019 11:45:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.BusinessPartnerBanks](
	[Id] [int] NULL,
	[BankId] [int] NULL,
	[BankName] [varchar](50) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
