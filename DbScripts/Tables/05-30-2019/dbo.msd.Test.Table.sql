USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.Test]    Script Date: 30/05/2019 11:35:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PageId]  AS ([Id]) PERSISTED NOT NULL,
	[PageName] [varchar](40) NOT NULL,
	[RouterLink] [varchar](60) NULL,
	[Icon] [nvarchar](25) NOT NULL,
	[IsMainMenu] [tinyint] NULL,
	[MainMenuId] [tinyint] NULL,
	[CreatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_msd.Test] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.Test] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
