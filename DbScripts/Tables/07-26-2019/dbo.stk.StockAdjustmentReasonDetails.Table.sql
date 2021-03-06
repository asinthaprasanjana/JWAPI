USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockAdjustmentReasonDetails]    Script Date: 26/07/2019 10:08:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockAdjustmentReasonDetails](
	[Id] [int] NULL,
	[CompanyId] [int] NULL,
	[ReasonId] [int] NULL,
	[ReasonName] [varchar](150) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
