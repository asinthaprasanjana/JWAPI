USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.PurchaseOrderReturnDetails]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.PurchaseOrderReturnDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseReturnId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[SupplierId] [int] NOT NULL,
	[CompanyId] [int] NULL,
	[BillLocationId] [int] NOT NULL,
	[ShipLocationId] [int] NOT NULL,
	[ReturningTotal] [money] NULL,
	[Email] [varchar](50) NULL,
	[Remarks] [varchar](100) NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_PurchaseOrderReturnDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
