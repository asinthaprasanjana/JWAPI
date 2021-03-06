USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.Test1]    Script Date: 14/03/2019 11:45:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.Test1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PageId]  AS ([Id]) PERSISTED NOT NULL,
	[PageName] [nvarchar](40) NOT NULL,
	[RouterLink] [nvarchar](60) NULL,
	[Icon] [nvarchar](25) NOT NULL,
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
