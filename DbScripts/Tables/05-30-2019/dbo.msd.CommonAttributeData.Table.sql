USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.CommonAttributeData]    Script Date: 30/05/2019 11:35:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.CommonAttributeData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AttributeId] [int] NOT NULL,
	[Value] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
