USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[bsp.BusinessPartnerFinancialDetails]    Script Date: 14/03/2019 11:45:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bsp.BusinessPartnerFinancialDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessPartnerId] [nvarchar](10) NOT NULL,
	[CreditPeriod] [int] NULL,
	[DiscountRate] [int] NULL,
	[BrcNo] [int] NULL,
	[VatRegNo] [int] NULL,
	[CreatedDateTime] [date] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
 CONSTRAINT [PK_bsp.BusinessPartnerFinancialDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
