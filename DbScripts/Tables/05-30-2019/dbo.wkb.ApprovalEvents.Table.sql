USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[wkb.ApprovalEvents]    Script Date: 30/05/2019 11:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wkb.ApprovalEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceNo] [varchar](20) NOT NULL,
	[ApprovalTaskId] [varchar](20) NOT NULL,
	[UserId] [smallint] NOT NULL,
	[UserComment] [varchar](200) NULL,
	[ApprovalTypeId] [int] NOT NULL,
	[ApprovalTypeName] [varchar](50) NOT NULL,
	[ApprovalSenderId] [smallint] NULL,
	[Status] [tinyint] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedUserId] [smallint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_wkb.ApprovalEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
