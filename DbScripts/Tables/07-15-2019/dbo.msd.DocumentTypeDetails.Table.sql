USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.DocumentTypeDetails]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.DocumentTypeDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentTypeId] [smallint] NOT NULL,
	[DocumentTypeName] [varchar](100) NOT NULL,
	[Number] [varchar](10) NOT NULL,
	[Text] [varchar](100) NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.DocumentTypeDetails] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
