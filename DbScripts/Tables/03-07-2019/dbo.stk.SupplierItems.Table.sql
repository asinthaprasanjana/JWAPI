USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SupplierItems]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SupplierItems](
	[Id] [int] NULL,
	[ItemId] [int] NOT NULL,
	[ItemName] [nvarchar](50) NOT NULL,
	[BusinessPartnerId] [int] NOT NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
