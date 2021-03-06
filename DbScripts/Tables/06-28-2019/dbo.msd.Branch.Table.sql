USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.Branch]    Script Date: 28/06/2019 4:47:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
CREATE TABLE [dbo].[msd.Branch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BranchId]  AS ([Id]) PERSISTED NOT NULL,
	[BranchName] [varchar](50) NULL,
	[DisplayName] [varchar](50) NULL,
	[BranchTypeId] [int] NOT NULL,
	[PhoneNo] [int] NULL,
	[Address] [varchar](100) NULL,
	[City] [varchar](50) NULL,
	[CompanyId] [int] NOT NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_msd.Branch_1] PRIMARY KEY CLUSTERED 
(
	[BranchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.Branch] ADD  CONSTRAINT [DF_msd.Branch_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
