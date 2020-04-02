USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[bsp.BusinessPartnerBankDetails]    Script Date: 14/03/2019 11:45:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bsp.BusinessPartnerBankDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessPartnerId] [varchar](50) NULL,
	[BankId] [int] NULL,
	[BranchName] [nvarchar](50) NULL,
	[AccountNo] [int] NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
