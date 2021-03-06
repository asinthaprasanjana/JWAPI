USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[wkb.ApprovalTask]    Script Date: 14/03/2019 11:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wkb.ApprovalTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApprovalTaskId]  AS ([ReferenceNo]+right('0000'+CONVERT([varchar](8),[ID],(0)),(8))) PERSISTED,
	[ReferenceNo] [nvarchar](200) NULL,
	[CompanyId] [int] NOT NULL,
	[ApprovalTypeId] [int] NOT NULL,
	[ApprovalSenderId] [int] NULL,
	[ApprovalRecieversId] [nvarchar](200) NULL,
	[Status] [tinyint] NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_wkb.ApprovalTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
