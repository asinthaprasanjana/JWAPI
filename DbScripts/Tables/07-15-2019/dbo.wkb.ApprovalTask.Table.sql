USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[wkb.ApprovalTask]    Script Date: 15/07/2019 12:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wkb.ApprovalTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApprovalTaskId]  AS ([ReferenceNo]+right('00'+CONVERT([varchar](8),[ID],(0)),(8))) PERSISTED,
	[ReferenceNo] [varchar](20) NULL,
	[CompanyId] [smallint] NULL,
	[ApprovalTypeId] [smallint] NOT NULL,
	[ApprovalSenderId] [smallint] NULL,
	[ApprovalRecieversId] [varchar](150) NULL,
	[Status] [tinyint] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_wkb.ApprovalTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[wkb.ApprovalTask] ADD  DEFAULT ((1)) FOR [CompanyId]
GO
