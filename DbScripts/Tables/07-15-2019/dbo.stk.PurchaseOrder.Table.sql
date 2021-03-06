USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrder]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseNo] [varchar](20) NOT NULL,
	[CompanyId] [smallint] NULL,
	[BranchId] [smallint] NOT NULL,
	[SupplierId] [varchar](30) NOT NULL,
	[BillLocationId] [smallint] NOT NULL,
	[ShipLocationId] [smallint] NOT NULL,
	[StockDue] [date] NULL,
	[PayementDue] [date] NULL,
	[CurrencyId] [smallint] NOT NULL,
	[GrossTotal] [decimal](18, 2) NOT NULL,
	[Tax] [money] NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[NetTotal] [decimal](18, 2) NOT NULL,
	[ApprovalStatus] [tinyint] NOT NULL,
	[IsCancelled] [bit] NULL,
	[QcAvailable] [bit] NOT NULL,
	[TempRecieved] [tinyint] NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[Recieved] [tinyint] NOT NULL,
	[Billed] [tinyint] NOT NULL,
	[Paid] [tinyint] NOT NULL,
	[CreditPeriod] [int] NULL,
	[Email] [varchar](200) NULL,
	[Remarks] [varchar](100) NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.PurchaseOrder] ADD  CONSTRAINT [DF__stk.Purch__IsCan__321755AF]  DEFAULT ((0)) FOR [IsCancelled]
GO
ALTER TABLE [dbo].[stk.PurchaseOrder] ADD  CONSTRAINT [DF__stk.Purch__QcAva__330B79E8]  DEFAULT ((0)) FOR [QcAvailable]
GO
ALTER TABLE [dbo].[stk.PurchaseOrder] ADD  CONSTRAINT [DF__stk.Purch__TempR__33FF9E21]  DEFAULT ((0)) FOR [TempRecieved]
GO
ALTER TABLE [dbo].[stk.PurchaseOrder] ADD  CONSTRAINT [DF__stk.Purch__Recie__34F3C25A]  DEFAULT ((0)) FOR [Recieved]
GO
ALTER TABLE [dbo].[stk.PurchaseOrder] ADD  CONSTRAINT [DF__stk.Purch__Bille__35E7E693]  DEFAULT ((0)) FOR [Billed]
GO
ALTER TABLE [dbo].[stk.PurchaseOrder] ADD  CONSTRAINT [DF__stk.Purcha__Paid__36DC0ACC]  DEFAULT ((0)) FOR [Paid]
GO
