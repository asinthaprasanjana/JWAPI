USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderRecievedSummery]    Script Date: 14/03/2019 11:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderRecievedSummery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[RecievedId] [int] NOT NULL,
	[IsBilled] [tinyint] NOT NULL,
	[PurchaseNo] [nvarchar](20) NOT NULL,
	[TotalQuantity] [float] NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecievedSummery] ADD  DEFAULT ((0)) FOR [IsBilled]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecievedSummery] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
