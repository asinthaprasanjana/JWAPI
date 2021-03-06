USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrder]    Script Date: 01/04/2019 9:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseNo]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[CompanyId] [int] NULL,
	[BranchId] [int] NOT NULL,
	[SupplierId] [nvarchar](30) NOT NULL,
	[BillLocationId] [int] NOT NULL,
	[ShipLocationId] [int] NOT NULL,
	[StockDue] [date] NULL,
	[PayementDue] [date] NULL,
	[CurrencyId] [int] NOT NULL,
	[GrossTotal] [money] NOT NULL,
	[Tax] [money] NOT NULL,
	[Discount] [money] NOT NULL,
	[NetTotal] [money] NOT NULL,
	[ApprovalStatus] [tinyint] NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[Recieved] [tinyint] NOT NULL,
	[Billed] [tinyint] NOT NULL,
	[CreditPeriod] [int] NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](100) NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL,
	[isCancelled] [tinyint] NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.PurchaseOrder] ADD  DEFAULT ((0)) FOR [isCancelled]
GO
