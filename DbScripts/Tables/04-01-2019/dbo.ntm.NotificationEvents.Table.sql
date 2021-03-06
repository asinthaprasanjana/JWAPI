USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[ntm.NotificationEvents]    Script Date: 01/04/2019 9:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ntm.NotificationEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [smallint] NULL,
	[UserId] [smallint] NULL,
	[ReferenceNo] [varchar](15) NULL,
	[Header] [varchar](50) NULL,
	[Message] [varchar](200) NULL,
	[Url] [varchar](100) NULL,
	[Seen] [tinyint] NOT NULL,
	[IsActive] [tinyint] NULL,
	[Sender] [smallint] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_ntm.NotificationEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
