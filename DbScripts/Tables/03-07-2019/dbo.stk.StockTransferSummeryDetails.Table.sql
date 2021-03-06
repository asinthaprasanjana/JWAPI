USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.StockTransferSummeryDetails]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.StockTransferSummeryDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyID] [int] NULL,
	[TransferId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[SourceLocationId] [int] NULL,
	[SourceLocationName] [varchar](30) NULL,
	[DestinationLocationId] [int] NULL,
	[DestinationLocationName] [varchar](30) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedUserName] [varchar](20) NULL,
	[CreatedDateTime] [datetime] NULL,
	[ReceivedUserId] [int] NULL,
	[ReceivedUserName] [varchar](20) NULL,
	[Status] [varchar](15) NULL,
	[Remarks] [varchar](200) NULL,
	[IsApproved] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stk.StockTransferSummeryDetails] ADD  DEFAULT ((0)) FOR [IsApproved]
GO
