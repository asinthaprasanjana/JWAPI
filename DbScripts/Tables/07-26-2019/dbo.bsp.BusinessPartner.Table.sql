USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[bsp.BusinessPartner]    Script Date: 26/07/2019 10:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bsp.BusinessPartner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[RegisteredAs] [varchar](10) NOT NULL,
	[BusinessPartnerId]  AS (CONVERT([varchar](20),[CompanyId],(0))+right('00000000'+CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[BusinessPartnerTypeId] [int] NOT NULL,
	[Addressing] [varchar](10) NULL,
	[FirstName] [varchar](20) NULL,
	[LastName] [varchar](20) NULL,
	[NIC] [varchar](15) NULL,
	[CompanyName] [varchar](50) NULL,
	[CompanyOwner] [varchar](50) NULL,
	[CompanyCode] [varchar](20) NULL,
	[DisplayName] [varchar](50) NULL,
	[Address1] [varchar](50) NOT NULL,
	[Address2] [varchar](50) NULL,
	[Address3] [varchar](50) NULL,
	[City] [varchar](20) NULL,
	[Province] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[MobileNo] [varchar](20) NULL,
	[Description] [varchar](100) NULL,
	[Country] [varchar](20) NULL,
	[LandPhoneNo] [varchar](20) NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_bsp.BusinessPartner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
