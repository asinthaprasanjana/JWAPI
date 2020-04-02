USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.WareHouse]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.WareHouse](
	[Id] [int] NULL,
	[WareHouseId] [int] NULL,
	[BranchId] [int] NULL,
	[Code] [varchar](50) NULL,
	[Volume] [int] NULL
) ON [PRIMARY]
GO
