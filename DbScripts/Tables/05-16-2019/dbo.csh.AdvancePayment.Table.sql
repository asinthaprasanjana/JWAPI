USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.AdvancePayment]    Script Date: 16/05/2019 12:00:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.AdvancePayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdvancePaymentId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[AdvancePaymentTypeId] [tinyint] NOT NULL,
	[PaymentMethodId] [int] NULL,
	[BusinessPartnerId] [int] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
