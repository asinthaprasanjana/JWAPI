USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.BusinessPartnerBanks]    Script Date: 01/04/2019 9:42:49 AM ******/
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
