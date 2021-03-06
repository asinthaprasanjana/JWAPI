USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderDraftDetails]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderDraftDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseNo]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[CompanyId] [int] NULL,
	[BranchId] [smallint] NOT NULL,
	[SupplierId] [int] NOT NULL,
	[BillLocationId] [smallint] NOT NULL,
	[ShipLocationId] [smallint] NOT NULL,
	[StockDue] [date] NULL,
	[PayementDue] [date] NULL,
	[CurrencyId] [smallint] NOT NULL,
	[GrossTotal] [money] NULL,
	[Tax] [money] NULL,
	[Discount] [money] NULL,
	[NetTotal] [money] NULL,
	[Status] [varchar](10) NOT NULL,
	[Recieved] [tinyint] NULL,
	[Billed] [tinyint] NULL,
	[CreditPeriod] [smallint] NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](100) NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_PurchaseOrderDraftDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
