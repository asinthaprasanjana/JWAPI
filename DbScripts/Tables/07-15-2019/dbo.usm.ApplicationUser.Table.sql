USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[usm.ApplicationUser]    Script Date: 15/07/2019 12:08:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usm.ApplicationUser](
	[UserID] [smallint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](150) NULL,
	[LastName] [varchar](150) NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[NIC] [char](10) NULL,
	[DateOfBirth] [datetime] NULL,
	[ContactNumber] [int] NULL,
	[Address] [varchar](50) NULL,
	[CompanyID] [int] NULL,
	[BranchID] [smallint] NOT NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
