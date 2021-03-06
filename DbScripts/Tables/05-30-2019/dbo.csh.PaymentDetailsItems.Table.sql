USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[csh.PaymentDetailsItems]    Script Date: 30/05/2019 11:35:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csh.PaymentDetailsItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentNo] [varchar](20) NOT NULL,
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
