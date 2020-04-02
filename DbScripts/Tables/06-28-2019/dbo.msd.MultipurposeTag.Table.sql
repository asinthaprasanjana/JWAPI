USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.MultipurposeTag]    Script Date: 28/06/2019 4:47:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.MultipurposeTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[ModuleName] [varchar](20) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Data] [tinyint] NOT NULL,
	[CreatedUser] [varchar](20) NOT NULL,
	[CreatedDateTime] [date] NOT NULL,
 CONSTRAINT [PK_msd.MultipurposeTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
