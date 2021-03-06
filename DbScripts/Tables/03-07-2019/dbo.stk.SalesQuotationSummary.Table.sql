USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesQuotationSummary]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesQuotationSummary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuotaionID]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[CompanyID] [smallint] NULL,
	[BusinessPartnerId] [varchar](20) NULL,
	[BuinessPartnerName] [varchar](50) NULL,
	[BranchID] [smallint] NULL,
	[GrossTotal] [float] NULL,
	[CreatedUserID] [smallint] NULL,
	[CreatedDate] [date] NOT NULL
) ON [PRIMARY]
GO
