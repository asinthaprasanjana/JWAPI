USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.GatePass]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.GatePass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NULL,
	[BusinessPartnerId] [int] NULL,
	[BusinessPartnerTypeId] [int] NULL,
	[ProductId] [int] NULL,
	[ProductName] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[PackSizeName] [varchar](50) NULL,
	[PackSizeId] [int] NULL,
	[ReturnDate] [datetime] NULL,
	[RecieveStatus] [varchar](50) NULL,
	[ContactDetail] [varchar](100) NULL,
	[Reason] [varchar](50) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
