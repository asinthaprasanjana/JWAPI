USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[MemberRelations]    Script Date: 26/07/2019 10:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberRelations](
	[Id] [int] NOT NULL,
	[MemberId] [int] NULL,
	[Parents] [nvarchar](50) NOT NULL,
	[Cousins] [nvarchar](50) NOT NULL,
	[Children] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
