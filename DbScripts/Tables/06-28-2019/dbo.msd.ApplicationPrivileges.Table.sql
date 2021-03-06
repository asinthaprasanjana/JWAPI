USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ApplicationPrivileges]    Script Date: 28/06/2019 4:47:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.ApplicationPrivileges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrivilegeId]  AS ([Id]) PERSISTED NOT NULL,
	[PrivilegeName] [varchar](40) NOT NULL,
	[CreatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_msd.ApplicationPrivileges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.ApplicationPrivileges] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
