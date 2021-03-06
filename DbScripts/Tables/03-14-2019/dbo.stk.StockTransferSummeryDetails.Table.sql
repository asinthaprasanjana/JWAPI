USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransferSummeryDetails]    Script Date: 14/03/2019 11:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransferSummeryDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
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
	[IsApproved] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.StockTransferSummeryDetails] ADD  DEFAULT ((0)) FOR [IsApproved]
GO
