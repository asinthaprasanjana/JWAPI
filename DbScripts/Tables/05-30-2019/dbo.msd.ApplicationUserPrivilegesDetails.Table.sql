USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ApplicationUserPrivilegesDetails]    Script Date: 30/05/2019 11:35:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.ApplicationUserPrivilegesDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [smallint] NOT NULL,
	[PrivilegeId] [varchar](150) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastModifiedUserId] [int] NULL,
	[LastModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_msd.ApplicationUserPrivilegesDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.ApplicationUserPrivilegesDetails] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
