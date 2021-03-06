USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesOrder]    Script Date: 28/06/2019 4:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SaleNo] [varchar](20) NULL,
	[CustomerId] [varchar](20) NOT NULL,
	[CompanyId] [smallint] NULL,
	[PayementDue] [date] NULL,
	[BillLocationId] [smallint] NOT NULL,
	[ShipLocationId] [smallint] NOT NULL,
	[CurrencyId] [smallint] NOT NULL,
	[GrossTotal] [decimal](18, 0) NULL,
	[Tax] [decimal](18, 0) NULL,
	[Discount] [decimal](18, 0) NULL,
	[NetTotal] [decimal](18, 0) NULL,
	[ApprovalStatus] [tinyint] NULL,
	[Invoiced] [tinyint] NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](100) NULL,
	[CreditPeriod] [smallint] NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
