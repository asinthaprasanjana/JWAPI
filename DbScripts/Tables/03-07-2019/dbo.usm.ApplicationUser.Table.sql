USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[usm.ApplicationUser]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usm.ApplicationUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](150) NULL,
	[LastName] [nvarchar](150) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[NIC] [nchar](10) NULL,
	[DateOfBirth] [datetime] NULL,
	[ContactNumber] [int] NULL,
	[Address] [nvarchar](50) NULL,
	[CompanyID] [int] NULL,
	[BranchID] [int] NOT NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
