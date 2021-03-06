USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[stk.TransactionTypes]    Script Date: 07/03/2019 10:01:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stk.TransactionTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[Data] [int] NULL,
	[ReferenceNo] [nvarchar](20) NULL,
	[TransactionName] [nvarchar](20) NULL,
	[CreatedUserId] [int] NULL,
	[CreatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_stk.TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
