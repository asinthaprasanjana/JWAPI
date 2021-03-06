USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.Test1]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.Test1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PageId]  AS ([Id]) PERSISTED NOT NULL,
	[PageName] [varchar](40) NOT NULL,
	[RouterLink] [varchar](60) NULL,
	[Icon] [varchar](25) NOT NULL,
	[IsMainMenu] [tinyint] NULL,
	[MainMenuId] [tinyint] NULL,
	[CreatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_msd.Test1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.Test1] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
