USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.InvoicePayment]    Script Date: 16/05/2019 12:00:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.InvoicePayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoicePaymentId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[InvoicePaymentTypeId] [tinyint] NOT NULL,
	[InvoiceNo] [nvarchar](20) NULL,
	[BusinessPartnerId] [int] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[CashPayment] [money] NULL,
	[ChequePayment] [money] NULL,
	[AdvancePayment] [money] NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
