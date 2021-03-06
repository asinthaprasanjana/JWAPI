USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.AdvancePayment]    Script Date: 01/04/2019 9:42:49 AM ******/
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
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
