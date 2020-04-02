USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd_ProductPackSize]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd_ProductPackSize](
	[PackSizeId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[PackSizeName] [varchar](50) NOT NULL,
	[PackQty] [decimal](18, 3) NOT NULL,
	[CreatedUserId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd_ProductPackSize] ADD  CONSTRAINT [DF_msd_ProductPackSize_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
