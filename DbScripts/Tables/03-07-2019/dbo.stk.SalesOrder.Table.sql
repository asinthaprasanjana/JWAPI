USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesOrder]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesOrder](
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
	[Status] [nvarchar](10) NULL,
	[Invoiced] [tinyint] NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](100) NULL,
	[CreditPeriod] [int] NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
