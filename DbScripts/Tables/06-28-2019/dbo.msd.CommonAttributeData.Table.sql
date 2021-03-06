USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CommonAttributeData]    Script Date: 28/06/2019 4:47:48 PM ******/
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
