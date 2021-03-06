USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ApplicationPages]    Script Date: 01/04/2019 9:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.ApplicationPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PageId]  AS ([Id]) PERSISTED NOT NULL,
	[PageName] [varchar](40) NOT NULL,
	[RouterLink] [varchar](90) NULL,
	[PriorityNo] [smallint] NOT NULL,
	[Icon] [varchar](55) NOT NULL,
	[IsMainMenu] [tinyint] NULL,
	[IsActive] [tinyint] NOT NULL,
	[MainMenuId] [tinyint] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NULL,
 CONSTRAINT [PK_msd.ApplicationPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.ApplicationPages] ADD  DEFAULT ((0)) FOR [PriorityNo]
GO
ALTER TABLE [dbo].[msd.ApplicationPages] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[msd.ApplicationPages] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
