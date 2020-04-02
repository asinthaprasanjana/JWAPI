USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.DocumentTypeDetails]    Script Date: 16/05/2019 12:00:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.DocumentTypeDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentTypeId] [smallint] NULL,
	[DocumentTypeName] [varchar](100) NULL,
	[Number] [varchar](10) NULL,
	[Text] [varchar](100) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.DocumentTypeDetails] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
