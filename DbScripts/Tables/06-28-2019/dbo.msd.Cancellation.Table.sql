USE [OnimtaWebInventory]
GO
/****** Object:  Table [dbo].[msd.Cancellation]    Script Date: 28/06/2019 4:47:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[msd.Cancellation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CancellationTypeId] [smallint] NULL,
	[ReferenceNumber] [varchar](20) NULL,
	[Reason] [varchar](100) NULL,
	[CreatedUserId] [smallint] NULL,
	[CreatedDateTime] [date] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[msd.Cancellation] ADD  DEFAULT (getdate()) FOR [CreatedDateTime]
GO
