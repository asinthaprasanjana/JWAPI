USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderRecieved]    Script Date: 01/04/2019 9:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderRecieved](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[PurchaseNo] [nvarchar](20) NOT NULL,
	[PurchaseOrderItemId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[TotalQuantity] [float] NOT NULL,
	[RecievedQuantity] [float] NOT NULL,
	[FreeQuantity] [float] NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecieved] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
