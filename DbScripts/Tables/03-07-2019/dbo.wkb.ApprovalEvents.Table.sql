USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[wkb.ApprovalEvents]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wkb.ApprovalEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceNo] [nvarchar](20) NOT NULL,
	[ApprovalTaskId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[UserComment] [varchar](200) NULL,
	[ApprovalTypeId] [int] NOT NULL,
	[ApprovalTypeName] [nvarchar](50) NOT NULL,
	[ApprovalSenderId] [int] NULL,
	[Status] [tinyint] NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_wkb.ApprovalEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
