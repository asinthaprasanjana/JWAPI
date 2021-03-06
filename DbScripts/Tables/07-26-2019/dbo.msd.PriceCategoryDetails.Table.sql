USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.PriceCategoryDetails]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.PriceCategoryDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[CreatedUserId] [smallint] NOT NULL,
	[CreatedDateTime] [date] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.PriceCategoryDetails] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
