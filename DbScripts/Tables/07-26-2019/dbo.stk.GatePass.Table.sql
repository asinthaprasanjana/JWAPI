USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GatePass]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.GatePass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNumber] [varchar](50) NULL,
	[TypeId] [int] NULL,
	[BusinessPartnerId] [int] NULL,
	[BusinessPartnerTypeId] [int] NULL,
	[ReturnDate] [datetime] NULL,
	[RecieveStatus] [varchar](50) NULL,
	[ContactDetail] [varchar](100) NULL,
	[Reason] [varchar](50) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
