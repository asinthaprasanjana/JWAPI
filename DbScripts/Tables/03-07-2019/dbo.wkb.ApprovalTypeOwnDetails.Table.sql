USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[wkb.ApprovalTypeOwnDetails]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wkb.ApprovalTypeOwnDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApprovalTypeId] [int] NOT NULL,
	[ApprovalOfficersId] [nvarchar](100) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[wkb.ApprovalTypeOwnDetails] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
