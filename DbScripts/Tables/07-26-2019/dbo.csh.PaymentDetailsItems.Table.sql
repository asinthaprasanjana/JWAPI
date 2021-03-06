USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.PaymentDetailsItems]    Script Date: 26/07/2019 10:08:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.PaymentDetailsItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocumentNo] [varchar](20) NOT NULL,
	[BillId] [int] NOT NULL,
	[PaymentMethodTypeId] [tinyint] NOT NULL,
	[PaidAmount] [decimal](18, 0) NOT NULL,
	[Reference1] [varchar](40) NULL,
	[Reference2] [varchar](40) NULL,
	[Reference3] [varchar](40) NULL,
	[Reference4] [varchar](40) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[csh.PaymentDetailsItems] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
