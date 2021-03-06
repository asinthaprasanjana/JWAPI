USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.Dispatch]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.Dispatch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DispatchTypeId] [int] NULL,
	[BusinessPartnerTypeId] [int] NULL,
	[ProductId] [int] NULL,
	[ProductName] [varchar](50) NULL,
	[Quantity] [int] NULL,
	[PackSizeName] [varchar](50) NULL,
	[PackSizeId] [int] NULL,
	[DocumentNumber] [varchar](50) NULL,
	[ReasonId] [int] NULL,
	[ReasonName] [varchar](50) NULL,
	[Comment] [varchar](200) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
