USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CommonAttributeValues]    Script Date: 15/07/2019 12:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CommonAttributeValues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[AttributeId] [int] NOT NULL,
	[DataId] [int] NOT NULL,
	[Data] [varchar](50) NOT NULL,
	[CreatedDateTime] [date] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.CommonAttributeValues] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
