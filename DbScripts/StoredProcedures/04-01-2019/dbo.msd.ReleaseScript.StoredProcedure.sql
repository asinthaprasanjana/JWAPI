USE [OnimtaWebInventory]
GO
/****** Object:  StoredProcedure [dbo].[msd.ReleaseScript]    Script Date: 01/04/2019 9:46:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[msd.ReleaseScript]

AS
BEGIN

 --- Insert Approval Types --- 

DROP TABLE [dbo].[wkb.ApprovalTypes]

CREATE TABLE [dbo].[wkb.ApprovalTypes](
	[Id] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ApprovalTypeId] [int] NOT NULL,
	[ApprovalName] [nvarchar](50) NULL,
	[IsActive] [tinyint] NULL,
	[LastModifiedDateTime] [datetime] NULL,
	[LastModifiedUserId] [int] NULL,
	[ApprovalOfficerIds] [nvarchar](100) NULL,
 CONSTRAINT [PK_wkb.ApprovalTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
INSERT [dbo].[wkb.ApprovalTypes] ([Id], [CompanyId], [ApprovalTypeId], [ApprovalName], [IsActive], [LastModifiedDateTime], [LastModifiedUserId], [ApprovalOfficerIds]) VALUES (1, 1, 1, N'Purchase Order Approval', 0, CAST(N'2019-02-06T11:16:03.857' AS DateTime), NULL, NULL)
INSERT [dbo].[wkb.ApprovalTypes] ([Id], [CompanyId], [ApprovalTypeId], [ApprovalName], [IsActive], [LastModifiedDateTime], [LastModifiedUserId], [ApprovalOfficerIds]) VALUES (2, 1, 2, N'Stock Tranfer Approval
', 0, CAST(N'2019-02-06T11:17:23.607' AS DateTime), NULL, NULL)
INSERT [dbo].[wkb.ApprovalTypes] ([Id], [CompanyId], [ApprovalTypeId], [ApprovalName], [IsActive], [LastModifiedDateTime], [LastModifiedUserId], [ApprovalOfficerIds]) VALUES (3, 1, 3, N'Stock Adjusment Approval
', 0, CAST(N'2019-02-05T19:44:13.783' AS DateTime), NULL, NULL)
INSERT [dbo].[wkb.ApprovalTypes] ([Id], [CompanyId], [ApprovalTypeId], [ApprovalName], [IsActive], [LastModifiedDateTime], [LastModifiedUserId], [ApprovalOfficerIds]) VALUES (4, 1, 4, N'New User Creation Approval', 0, CAST(N'2019-01-07T19:57:32.530' AS DateTime), NULL, NULL)
INSERT [dbo].[wkb.ApprovalTypes] ([Id], [CompanyId], [ApprovalTypeId], [ApprovalName], [IsActive], [LastModifiedDateTime], [LastModifiedUserId], [ApprovalOfficerIds]) VALUES (5, 1, 5, N'Edit User Details Approval', 0, CAST(N'2019-01-07T19:47:57.297' AS DateTime), NULL, NULL)
INSERT [dbo].[wkb.ApprovalTypes] ([Id], [CompanyId], [ApprovalTypeId], [ApprovalName], [IsActive], [LastModifiedDateTime], [LastModifiedUserId], [ApprovalOfficerIds]) VALUES (6, 1, 6, N'Removing User Details Approval', 0, CAST(N'2019-01-03T15:09:58.270' AS DateTime), NULL, NULL)



INSERT INTO [dbo].[msd.BranchTypeDetails]
           ([TypeDetail])
     VALUES
           ('Head Office')

INSERT INTO [dbo].[msd.BranchTypeDetails]
           ([TypeDetail])
     VALUES
           ('Ware House')


INSERT INTO [dbo].[msd.BranchTypeDetails]
           ([TypeDetail])
     VALUES
           ('Retail Outlet')


END
GO
