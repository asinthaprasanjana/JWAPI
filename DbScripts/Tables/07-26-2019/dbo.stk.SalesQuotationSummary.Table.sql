USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SalesQuotationSummary]    Script Date: 26/07/2019 10:08:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SalesQuotationSummary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[CompanyID] [smallint] NULL,
	[BusinessPartnerId] [varchar](20) NULL,
	[BuinessPartnerName] [varchar](50) NULL,
	[BranchID] [smallint] NULL,
	[GrossTotal] [float] NULL,
	[AprovalStatus] [smallint] NOT NULL,
	[CreatedUserID] [smallint] NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.SalesQuotationSummary] ADD  DEFAULT ((0)) FOR [AprovalStatus]
GO
