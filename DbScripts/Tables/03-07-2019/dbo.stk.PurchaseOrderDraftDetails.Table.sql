USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderDraftDetails]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderDraftDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseNo]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[CompanyId] [int] NULL,
	[BranchId] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
	[BillLocationId] [int] NOT NULL,
	[ShipLocationId] [int] NOT NULL,
	[StockDue] [date] NULL,
	[PayementDue] [date] NULL,
	[CurrencyId] [int] NOT NULL,
	[GrossTotal] [money] NULL,
	[Tax] [money] NULL,
	[Discount] [money] NULL,
	[NetTotal] [money] NULL,
	[Status] [nvarchar](10) NOT NULL,
	[Recieved] [tinyint] NULL,
	[Billed] [tinyint] NULL,
	[CreditPeriod] [int] NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](100) NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_PurchaseOrderDraftDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
