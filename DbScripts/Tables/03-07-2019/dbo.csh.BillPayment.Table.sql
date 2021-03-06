USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.BillPayment]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.BillPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillPaymentId]  AS (right(CONVERT([varchar](20),[Id],(0)),(8))) PERSISTED,
	[BillPaymentTypeId] [tinyint] NOT NULL,
	[BillId] [nvarchar](20) NULL,
	[BusinessPartnerId] [int] NOT NULL,
	[TotalPrice] [money] NOT NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
