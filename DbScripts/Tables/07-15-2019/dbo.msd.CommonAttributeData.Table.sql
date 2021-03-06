USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CommonAttributeData]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CommonAttributeData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttributeId] [int] NOT NULL,
	[Value] [varchar](50) NOT NULL,
	[isDeleted] [tinyint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.CommonAttributeData] ADD  DEFAULT ((0)) FOR [isDeleted]
GO
