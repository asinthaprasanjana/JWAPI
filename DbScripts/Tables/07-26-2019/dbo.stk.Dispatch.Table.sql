USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.Dispatch]    Script Date: 26/07/2019 10:08:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.Dispatch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DispatchTypeId] [int] NULL,
	[BusinessPartnerTypeId] [int] NULL,
	[DocumentNumber] [varchar](50) NULL,
	[ReasonId] [int] NULL,
	[ReasonName] [varchar](50) NULL,
	[Comment] [varchar](200) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL
) ON [PRIMARY]
GO
