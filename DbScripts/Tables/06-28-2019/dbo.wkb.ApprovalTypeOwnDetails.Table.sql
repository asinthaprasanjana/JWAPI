USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[wkb.ApprovalTypeOwnDetails]    Script Date: 28/06/2019 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wkb.ApprovalTypeOwnDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApprovalTypeId] [smallint] NOT NULL,
	[ApprovalOfficersId] [varchar](100) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[wkb.ApprovalTypeOwnDetails] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
