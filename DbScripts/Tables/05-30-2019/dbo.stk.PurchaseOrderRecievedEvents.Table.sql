USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderRecievedEvents]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderRecievedEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[RecievedId] [int] NOT NULL,
	[IsBilled] [tinyint] NOT NULL,
	[PurchaseNo] [nvarchar](20) NOT NULL,
	[RecievedTypeId] [smallint] NULL,
	[PurchaseOrderItemId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[packSizeId] [int] NULL,
	[PackSizeName] [varchar](50) NULL,
	[TotalQuantity] [float] NOT NULL,
	[RecievedQuantity] [float] NOT NULL,
	[FreeQuantity] [float] NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecievedEvents] ADD  DEFAULT ((0)) FOR [IsBilled]
GO
