SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[PROJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[INVE_ID] [int] NULL,
	[PROJ_Name] [varchar](50) NOT NULL,
	[PROJ_OverallProfitability] [int] NOT NULL,
	[PROJ_ExecutionTime] [int] NOT NULL,
	[PROJ_InvestmentCapital] [numeric](10, 4) NOT NULL,
	[PROJ_Modality] [varchar](50) NOT NULL,
	[PROJ_PromotionDate] [date] NULL,
	[PROJ_ExpirationDate] [date] NULL,
	[PROJ_Progress] [int] NOT NULL,
	[PROJ_Description] [varchar](200) NULL,
	[PROJ_State] [char](1) NOT NULL,
	[AUDI_UserCrea] [varchar](20) NOT NULL,
	[AUDI_FechCrea] [datetime] NOT NULL,
	[AUDI_UserModi] [varchar](20) NULL,
	[AUDI_FechModi] [datetime] NULL,
 CONSTRAINT [Projects_PK] PRIMARY KEY CLUSTERED 
(
	[PROJ_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [Projects_Investments_FK] FOREIGN KEY([INVE_ID])
REFERENCES [dbo].[Investments] ([INVE_ID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [Projects_Investments_FK]