USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockAdjustmentReasonDetails]    Script Date: 14/03/2019 11:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockAdjustmentReasonDetails](
	[Id] [int] NULL,
	[CompanyId] [int] NULL,
	[ReasonId] [int] NULL,
	[ReasonName] [nvarchar](150) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
