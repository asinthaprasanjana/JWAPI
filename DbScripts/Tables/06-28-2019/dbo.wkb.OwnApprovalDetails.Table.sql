USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[wkb.OwnApprovalDetails]    Script Date: 28/06/2019 4:47:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wkb.OwnApprovalDetails](
	[Id] [int] NOT NULL,
	[ApprovalTaskId] [int] NOT NULL,
	[ApprovalResponserId] [int] NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
	[CompanyID] [int] NULL,
 CONSTRAINT [PK_wkb.OwnApprovalDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
