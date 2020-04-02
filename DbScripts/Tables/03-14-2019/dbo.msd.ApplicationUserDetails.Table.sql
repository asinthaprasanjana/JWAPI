USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.ApplicationUserDetails]    Script Date: 14/03/2019 11:45:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.ApplicationUserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId]  AS ([Id]) PERSISTED NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[BranchID] [int] NOT NULL,
	[NicNo] [nvarchar](15) NULL,
	[Birthday] [date] NULL,
	[ExpirationDate] [date] NULL,
	[MobileNo] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL
) ON [PRIMARY]
GO
