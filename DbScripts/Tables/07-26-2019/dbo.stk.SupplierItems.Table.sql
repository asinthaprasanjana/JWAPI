USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SupplierItems]    Script Date: 26/07/2019 10:08:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.SupplierItems](
	[Id] [int] NULL,
	[ItemId] [int] NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
	[BusinessPartnerId] [int] NOT NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
