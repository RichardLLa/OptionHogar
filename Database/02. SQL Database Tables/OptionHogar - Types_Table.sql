SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[TYPE_CodTable] [varchar](3) NOT NULL,
	[TYPE_CodType] [varchar](3) NOT NULL,
	[TYPE_Desc1] [varchar](100) NOT NULL,
	[TYPE_Desc2] [varchar](100) NULL,
	[TYPE_Num1] [int] NULL,
	[TYPE_Num2] [int] NULL,
	[TYPE_Status] [char](1) NOT NULL,
	[AUDI_UserCrea] [varchar](20) NOT NULL,
	[AUDI_FechCrea] [datetime] NOT NULL,
	[AUDI_UserModi] [varchar](20) NULL,
	[AUDI_FechModi] [datetime] NULL,
 CONSTRAINT [Types_PK] PRIMARY KEY CLUSTERED 
(
	[TYPE_CodTable] ASC,
	[TYPE_CodType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]