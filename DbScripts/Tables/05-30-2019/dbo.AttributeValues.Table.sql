USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[AttributeValues]    Script Date: 30/05/2019 11:35:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeValues](
	[AttributeValueId] [int] IDENTITY(1,1) NOT NULL,
	[AttributeId] [int] NOT NULL,
	[ParentNodeId] [int] NULL,
	[ChildNode] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
