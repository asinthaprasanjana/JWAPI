USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[bsp.BusinessPartnerBankDetails]    Script Date: 30/05/2019 11:35:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bsp.BusinessPartnerBankDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessPartnerId] [varchar](50) NULL,
	[BankId] [int] NULL,
	[BranchName] [varchar](50) NULL,
	[AccountNo] [int] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
