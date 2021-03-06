USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.AdvancePayment]    Script Date: 15/07/2019 12:08:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.AdvancePayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdvancePaymentId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[AdvancePaymentTypeId] [tinyint] NOT NULL,
	[PaymentMethodId] [smallint] NULL,
	[BusinessPartnerId] [int] NOT NULL,
	[TotalPrice] [decimal](18, 0) NOT NULL,
	[SetOffAmount] [decimal](18, 0) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[csh.AdvancePayment] ADD  DEFAULT ((0)) FOR [SetOffAmount]
GO
ALTER TABLE [dbo].[csh.AdvancePayment] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
