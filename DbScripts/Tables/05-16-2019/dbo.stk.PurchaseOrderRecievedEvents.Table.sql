USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderRecievedEvents]    Script Date: 16/05/2019 12:00:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderRecievedEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[RecievedId] [int] NOT NULL,
	[IsBilled] [tinyint] NULL,
	[PurchaseNo] [nvarchar](20) NOT NULL,
	[RecievedTypeId] [smallint] NULL,
	[PurchaseOrderItemId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[packSizeId] [int] NULL,
	[TotalQuantity] [float] NOT NULL,
	[RecievedQuantity] [float] NOT NULL,
	[FreeQuantity] [float] NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
