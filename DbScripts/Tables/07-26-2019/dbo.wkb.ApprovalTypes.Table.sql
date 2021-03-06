USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[wkb.ApprovalTypes]    Script Date: 26/07/2019 10:08:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wkb.ApprovalTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ApprovalTypeId] [int] NOT NULL,
	[ApprovalName] [nvarchar](50) NULL,
	[IsActive] [tinyint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
	[LastModifiedUserId] [int] NULL,
	[ApprovalOfficerIds] [nvarchar](100) NULL,
 CONSTRAINT [PK_wkb.ApprovalTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[wkb.ApprovalTypes] ADD  DEFAULT ((1)) FOR [CompanyId]
GO
ALTER TABLE [dbo].[wkb.ApprovalTypes] ADD  DEFAULT (getdate()) FOR [LastModifiedDateTime]
GO
