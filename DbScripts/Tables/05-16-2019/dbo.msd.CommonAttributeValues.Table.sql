USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CommonAttributeValues]    Script Date: 16/05/2019 12:00:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CommonAttributeValues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[AttributeId] [int] NOT NULL,
	[Value] [varchar](50) NOT NULL,
	[CreatedDateTime] [date] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.CommonAttributeValues] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
