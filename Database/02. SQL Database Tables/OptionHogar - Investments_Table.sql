SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Investments](
	[INVE_ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_ID] [int] NOT NULL,
	[INVE_Amount] [numeric](10, 4) NOT NULL,
	[INVE_Date] [date] NOT NULL,
	[INVE_Observation] [varchar](200) NULL,
	[INVE_CostEffectiveness] [int] NULL,
	[INVE_State] [char](1) NOT NULL,
	[AUDI_UserCrea] [varchar](20) NOT NULL,
	[AUDI_FechCrea] [datetime] NOT NULL,
	[AUDI_UserModi] [varchar](20) NULL,
	[AUDI_FechModi] [datetime] NULL,
 CONSTRAINT [Investments_PK] PRIMARY KEY CLUSTERED 
(
	[INVE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Investments]  WITH CHECK ADD  CONSTRAINT [Investments_Users_FK] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[Users] ([USER_ID])
GO
ALTER TABLE [dbo].[Investments] CHECK CONSTRAINT [Investments_Users_FK]