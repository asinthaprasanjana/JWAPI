USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ProductPriceType]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.ProductPriceType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.ProductPriceType] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
