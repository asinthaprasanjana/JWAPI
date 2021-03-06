USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.BillPayment]    Script Date: 16/05/2019 12:00:27 PM ******/
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
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
