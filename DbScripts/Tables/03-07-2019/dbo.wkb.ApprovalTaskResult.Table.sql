USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[wkb.ApprovalTaskResult]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wkb.ApprovalTaskResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApprovalTaskId] [int] NOT NULL,
	[ApprovalResponserId] [int] NOT NULL,
	[ApprovalResponserName] [varchar](25) NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_wkb.ApprovalTaskResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
