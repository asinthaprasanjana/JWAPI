USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.SupplierItems]    Script Date: 28/06/2019 4:47:50 PM ******/
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
