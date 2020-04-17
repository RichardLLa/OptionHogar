GO
/****** Object:  Table [dbo].[Events]    Script Date: 17/04/2020 09:39:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EVEN_ID] [int] IDENTITY(1,1) NOT NULL,
	[PROJ_ID] [int] NOT NULL,
	[EVEN_StartDate] [date] NOT NULL,
	[EVEN_EndingDate] [date] NOT NULL,
	[EVEN_State] [char](1) NOT NULL,
	[EVEN_Title] [varchar](20) NOT NULL,
	[EVEN_Description] [varchar](200) NOT NULL,
	[AUDI_UserCrea] [varchar](20) NOT NULL,
	[AUDI_FechCrea] [datetime] NOT NULL,
	[AUDI_UserModi] [varchar](20) NULL,
	[AUDI_FechModi] [datetime] NULL,
 CONSTRAINT [Events_PK] PRIMARY KEY CLUSTERED 
(
	[EVEN_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Investments]    Script Date: 17/04/2020 09:39:34 ******/
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
/****** Object:  Table [dbo].[Logs]    Script Date: 17/04/2020 09:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[LOG_ID] [int] IDENTITY(1,1) NOT NULL,
	[LOG_Date] [date] NOT NULL,
	[TYPE_TabAUD] [varchar](3) NOT NULL,
	[TYPE_CodAUD] [varchar](3) NOT NULL,
	[LOG_Object] [varchar](25) NOT NULL,
	[LOG_Text] [text] NOT NULL,
 CONSTRAINT [Logs_PK] PRIMARY KEY CLUSTERED 
(
	[LOG_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media]    Script Date: 17/04/2020 09:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media](
	[MEDI_ID] [int] IDENTITY(1,1) NOT NULL,
	[PROJ_ID] [int] NULL,
	[EVEN_ID] [int] NULL,
	[MEDI_Event] [bit] NOT NULL,
	[MEDI_Title] [varchar](50) NOT NULL,
	[MEDI_Description] [varchar](250) NOT NULL,
	[MEDI_Url] [varchar](100) NOT NULL,
	[TYPE_TabMED] [varchar](3) NOT NULL,
	[TYPE_CodMED] [varchar](3) NOT NULL,
	[AUDI_UserCrea] [varchar](20) NOT NULL,
	[AUDI_FechCrea] [datetime] NOT NULL,
	[AUDI_UserModi] [varchar](20) NULL,
	[AUDI_FechModi] [datetime] NULL,
 CONSTRAINT [Media_PK] PRIMARY KEY CLUSTERED 
(
	[MEDI_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Params]    Script Date: 17/04/2020 09:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Params](
	[PARA_ID] [int] IDENTITY(1,1) NOT NULL,
	[PARA_Key] [varchar](50) NOT NULL,
	[PARA_Value] [varchar](100) NOT NULL,
	[PARA_Description] [varchar](100) NOT NULL,
	[AUDI_UserCrea] [varchar](20) NOT NULL,
	[AUDI_FechCrea] [datetime] NOT NULL,
	[AUDI_UserModi] [varchar](20) NULL,
	[AUDI_FechModi] [datetime] NULL,
 CONSTRAINT [Params_PK] PRIMARY KEY CLUSTERED 
(
	[PARA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 17/04/2020 09:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PERS_ID] [int] IDENTITY(1,1) NOT NULL,
	[PERS_Names] [varchar](25) NOT NULL,
	[PERS_LastName] [varchar](25) NOT NULL,
	[PERS_MotherLastName] [varchar](25) NOT NULL,
	[PERS_BirthDate] [date] NOT NULL,
	[TYPE_TabGEN] [varchar](3) NOT NULL,
	[TYPE_CodGEN] [varchar](3) NOT NULL,
	[TYPE_TabDOC] [varchar](3) NOT NULL,
	[TYPE_CodDOC] [varchar](3) NOT NULL,
	[AUDI_UserCrea] [varchar](20) NOT NULL,
	[AUDI_FechCrea] [datetime] NOT NULL,
	[AUDI_UserModi] [varchar](20) NULL,
	[AUDI_FechModi] [datetime] NULL,
 CONSTRAINT [Persons_PK] PRIMARY KEY CLUSTERED 
(
	[PERS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_FullName] UNIQUE NONCLUSTERED 
(
	[PERS_Names] ASC,
	[PERS_LastName] ASC,
	[PERS_MotherLastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 17/04/2020 09:39:34 ******/
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
/****** Object:  Table [dbo].[SessionKeys]    Script Date: 17/04/2020 09:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionKeys](
	[SESS_ID] [int] NOT NULL,
	[SESS_Date] [date] NOT NULL,
	[SESS_PrivateKeyXML] [varchar](100) NOT NULL,
	[SESS_PublicKeyXML] [varchar](100) NOT NULL,
	[SESS_PrivateKeyPEM] [varchar](100) NOT NULL,
	[SESS_PublicKeyPEM] [varchar](100) NOT NULL,
	[AUDI_UserCrea] [varchar](20) NOT NULL,
	[AUDI_FechCrea] [datetime] NOT NULL,
	[AUDI_UserModi] [varchar](20) NULL,
	[AUDI_FechModi] [datetime] NULL,
 CONSTRAINT [PK_SessionKeys_1] PRIMARY KEY CLUSTERED 
(
	[SESS_ID] ASC,
	[SESS_Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 17/04/2020 09:39:34 ******/
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
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17/04/2020 09:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[USER_ID] [int] IDENTITY(1,1) NOT NULL,
	[PERS_ID] [int] NOT NULL,
	[USER_Email] [varchar](25) NOT NULL,
	[USER_Password] [varchar](200) NOT NULL,
	[USER_Admin] [bit] NOT NULL,
	[USER_Status] [char](1) NOT NULL,
	[AUDI_UserCrea] [varchar](20) NOT NULL,
	[AUDI_FechCrea] [datetime] NOT NULL,
	[AUDI_UserModi] [varchar](20) NULL,
	[AUDI_FechModi] [datetime] NULL,
 CONSTRAINT [Users_PK] PRIMARY KEY CLUSTERED 
(
	[USER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [Events_Projects_FK] FOREIGN KEY([PROJ_ID])
REFERENCES [dbo].[Projects] ([PROJ_ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [Events_Projects_FK]
GO
ALTER TABLE [dbo].[Investments]  WITH CHECK ADD  CONSTRAINT [Investments_Users_FK] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[Users] ([USER_ID])
GO
ALTER TABLE [dbo].[Investments] CHECK CONSTRAINT [Investments_Users_FK]
GO
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [Logs_TypesAUD_FK] FOREIGN KEY([TYPE_TabAUD], [TYPE_CodAUD])
REFERENCES [dbo].[Types] ([TYPE_CodTable], [TYPE_CodType])
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [Logs_TypesAUD_FK]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [Media_Events_FK] FOREIGN KEY([EVEN_ID])
REFERENCES [dbo].[Events] ([EVEN_ID])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [Media_Events_FK]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [Media_Projects_FK] FOREIGN KEY([PROJ_ID])
REFERENCES [dbo].[Projects] ([PROJ_ID])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [Media_Projects_FK]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [Media_Types_FK] FOREIGN KEY([TYPE_TabMED], [TYPE_CodMED])
REFERENCES [dbo].[Types] ([TYPE_CodTable], [TYPE_CodType])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [Media_Types_FK]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [Persons_TypesDOC_FK] FOREIGN KEY([TYPE_TabDOC], [TYPE_CodDOC])
REFERENCES [dbo].[Types] ([TYPE_CodTable], [TYPE_CodType])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [Persons_TypesDOC_FK]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [Persons_TypesGEN_FK] FOREIGN KEY([TYPE_TabGEN], [TYPE_CodGEN])
REFERENCES [dbo].[Types] ([TYPE_CodTable], [TYPE_CodType])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [Persons_TypesGEN_FK]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [Projects_Investments_FK] FOREIGN KEY([INVE_ID])
REFERENCES [dbo].[Investments] ([INVE_ID])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [Projects_Investments_FK]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [Users_Persons_FK] FOREIGN KEY([PERS_ID])
REFERENCES [dbo].[Persons] ([PERS_ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [Users_Persons_FK]
GO
/****** Object:  StoredProcedure [dbo].[Events_Delete]    Script Date: 17/04/2020 09:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


