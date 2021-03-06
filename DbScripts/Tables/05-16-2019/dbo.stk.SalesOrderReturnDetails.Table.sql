USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesOrderReturnDetails]    Script Date: 16/05/2019 12:00:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesOrderReturnDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalesReturnId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[CustomerId] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[BillLocationId] [int] NOT NULL,
	[ShipLocationId] [int] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[ReturningTotal] [money] NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](100) NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_SalesOrderReturnDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
