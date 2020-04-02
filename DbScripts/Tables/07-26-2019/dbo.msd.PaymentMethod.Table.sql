USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.PaymentMethod]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.PaymentMethod](
	[PaymentMethodId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentMethodName] [varchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL
) ON [PRIMARY]
GO
