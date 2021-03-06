USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderRecievedSummery]    Script Date: 28/06/2019 4:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderRecievedSummery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [smallint] NULL,
	[RecievedId] [int] NOT NULL,
	[RecievedTypeId] [smallint] NOT NULL,
	[IsBilled] [tinyint] NOT NULL,
	[PurchaseNo] [varchar](20) NOT NULL,
	[TotalQuantity] [float] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecievedSummery] ADD  DEFAULT ((0)) FOR [RecievedTypeId]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecievedSummery] ADD  DEFAULT ((0)) FOR [IsBilled]
GO
ALTER TABLE [dbo].[stk.PurchaseOrderRecievedSummery] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
