USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.Company]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NULL,
	[Address] [varchar](150) NULL,
	[VATNo] [varchar](20) NULL,
	[RegistrationNo] [varchar](50) NULL,
	[PhoneNo] [int] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
