USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransferSummeryDetails]    Script Date: 15/07/2019 12:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransferSummeryDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [smallint] NULL,
	[TransferId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[SourceLocationId] [smallint] NULL,
	[SourceLocationName] [varchar](30) NULL,
	[DestinationLocationId] [smallint] NULL,
	[DestinationLocationName] [varchar](30) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedUserName] [varchar](20) NULL,
	[ReceivedUserId] [smallint] NULL,
	[ReceivedUserName] [varchar](20) NULL,
	[Status] [smallint] NULL,
	[Remarks] [varchar](200) NULL,
	[IsApproved] [tinyint] NULL,
	[isCancelled] [tinyint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.StockTransferSummeryDetails] ADD  DEFAULT ((0)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[stk.StockTransferSummeryDetails] ADD  DEFAULT ((0)) FOR [isCancelled]
GO
ALTER TABLE [dbo].[stk.StockTransferSummeryDetails] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
