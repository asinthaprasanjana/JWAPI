USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ApplicationUserLogInDetails]    Script Date: 28/06/2019 4:47:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.ApplicationUserLogInDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [smallint] NOT NULL,
	[UserName] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[RoleId] [int] NOT NULL,
	[BranchId] [smallint] NOT NULL,
	[IsApproved] [tinyint] NOT NULL,
	[IsActive] [tinyint] NOT NULL,
	[ExpireDate] [datetime] NOT NULL,
 CONSTRAINT [PK_msd.ApplicationUserLogInDetails] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.ApplicationUserLogInDetails] ADD  DEFAULT ((1)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[msd.ApplicationUserLogInDetails] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[msd.ApplicationUserLogInDetails] ADD  DEFAULT (getdate()) FOR [ExpireDate]
GO
