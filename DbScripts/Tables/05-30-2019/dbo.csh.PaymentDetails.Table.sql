USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.PaymentDetails]    Script Date: 30/05/2019 11:35:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.PaymentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentNo] [varchar](20) NOT NULL,
	[PaymentTypeId] [tinyint] NOT NULL,
	[ReferenceNo] [varchar](20) NULL,
	[BusinessPartnerId] [int] NOT NULL,
	[TotalPaid] [decimal](18, 0) NOT NULL,
	[Balance] [decimal](18, 0) NOT NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
