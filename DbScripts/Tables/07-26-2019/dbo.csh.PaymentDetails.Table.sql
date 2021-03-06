USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.PaymentDetails]    Script Date: 26/07/2019 10:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.PaymentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNo] [varchar](20) NOT NULL,
	[PaymentTypeId] [tinyint] NOT NULL,
	[ReferenceNo] [varchar](20) NULL,
	[BusinessPartnerId] [int] NOT NULL,
	[TotalPaid] [decimal](18, 0) NOT NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[csh.PaymentDetails] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
