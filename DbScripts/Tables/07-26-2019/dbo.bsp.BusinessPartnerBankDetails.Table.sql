USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[bsp.BusinessPartnerBankDetails]    Script Date: 26/07/2019 10:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bsp.BusinessPartnerBankDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessPartnerId] [varchar](50) NULL,
	[BankId] [int] NULL,
	[BranchName] [varchar](50) NULL,
	[AccountNo] [varchar](25) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
