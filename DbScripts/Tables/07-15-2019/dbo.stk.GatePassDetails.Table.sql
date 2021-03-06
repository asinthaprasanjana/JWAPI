USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GatePassDetails]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.GatePassDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNumber] [varchar](50) NULL,
	[BusinessPartnerId] [int] NULL,
	[BusinessPartnerTypeId] [int] NULL,
	[RecieveStatus] [varchar](50) NULL,
	[ContactDetail] [varchar](50) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
