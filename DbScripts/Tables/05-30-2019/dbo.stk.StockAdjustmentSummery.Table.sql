USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockAdjustmentSummery]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockAdjustmentSummery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [smallint] NULL,
	[BranchID] [smallint] NOT NULL,
	[StockAdjustmentId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[ApprovalStatus] [tinyint] NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.StockAdjustmentSummery] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
