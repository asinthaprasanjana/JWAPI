USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesOrderDraftDetails]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesOrderDraftDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaleNo]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[CustomerId] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[PayementDue] [date] NULL,
	[BillLocationId] [int] NOT NULL,
	[ShipLocationId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[GrossTotal] [money] NULL,
	[Tax] [money] NULL,
	[Discount] [money] NULL,
	[NetTotal] [money] NULL,
	[Status] [varchar](10) NULL,
	[Invoiced] [tinyint] NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](100) NULL,
	[CreditPeriod] [int] NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_SalesOrderDraftDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
