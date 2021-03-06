USE [SimulationExam]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 30/06/2018 17:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[EventId] [int] NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ActivityDate]    Script Date: 30/06/2018 17:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityDate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[ActivityId] [int] NULL,
 CONSTRAINT [PK_ActivityDate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Event]    Script Date: 30/06/2018 17:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 30/06/2018 17:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 30/06/2018 17:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Email] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserActivityDate]    Script Date: 30/06/2018 17:46:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserActivityDate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[UserId] [int] NULL,
	[ActivityDateId] [int] NULL,
	[IsPartecipant] [tinyint] NULL,
	[WillCome] [tinyint] NULL,
 CONSTRAINT [PK_UserActivity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Activity] ON 

INSERT [dbo].[Activity] ([Id], [Name], [EventId]) VALUES (31, N'Pallavolo', 1)
INSERT [dbo].[Activity] ([Id], [Name], [EventId]) VALUES (32, N'Calcio', 1)
SET IDENTITY_INSERT [dbo].[Activity] OFF
SET IDENTITY_INSERT [dbo].[ActivityDate] ON 

INSERT [dbo].[ActivityDate] ([Id], [Date], [ActivityId]) VALUES (68, CAST(N'1997-09-09T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[ActivityDate] ([Id], [Date], [ActivityId]) VALUES (69, CAST(N'1997-09-01T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[ActivityDate] ([Id], [Date], [ActivityId]) VALUES (70, CAST(N'1881-05-05T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[ActivityDate] ([Id], [Date], [ActivityId]) VALUES (71, CAST(N'2015-05-14T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[ActivityDate] ([Id], [Date], [ActivityId]) VALUES (72, CAST(N'1880-05-05T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[ActivityDate] ([Id], [Date], [ActivityId]) VALUES (73, CAST(N'2010-03-03T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[ActivityDate] ([Id], [Date], [ActivityId]) VALUES (74, CAST(N'2018-09-04T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[ActivityDate] ([Id], [Date], [ActivityId]) VALUES (75, CAST(N'2009-07-09T00:00:00.000' AS DateTime), 31)
SET IDENTITY_INSERT [dbo].[ActivityDate] OFF
SET IDENTITY_INSERT [dbo].[Event] ON 

INSERT [dbo].[Event] ([Id], [Name], [UserId]) VALUES (1, N'Addio al celibato', 1)
SET IDENTITY_INSERT [dbo].[Event] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Organizzatore')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Partecipante')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [RoleId]) VALUES (1, N'Marco', N'marcodege97@gmail.com', N'12345678', 1)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [RoleId]) VALUES (23, N'Marco', N'dwd@gmail.com', N'123', 2)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [RoleId]) VALUES (24, N'Andrea', N'dwdd@gmail.com', N'12345678', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserActivityDate] ON 

INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (67, NULL, 24, 68, NULL, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (68, NULL, 24, 69, NULL, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (69, NULL, 24, 70, 1, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (70, NULL, 24, 71, 1, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (71, NULL, 24, 72, 1, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (72, NULL, 24, 73, 1, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (73, NULL, 24, 74, 1, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (74, NULL, 23, 68, NULL, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (75, NULL, 23, 69, NULL, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (76, NULL, 23, 70, NULL, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (77, NULL, 23, 71, 1, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (78, NULL, 23, 72, NULL, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (79, NULL, 23, 73, 1, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (80, NULL, 23, 74, 1, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (81, NULL, 23, 75, 1, NULL)
INSERT [dbo].[UserActivityDate] ([Id], [Name], [UserId], [ActivityDateId], [IsPartecipant], [WillCome]) VALUES (82, NULL, 24, 75, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserActivityDate] OFF
ALTER TABLE [dbo].[Activity]  WITH CHECK ADD  CONSTRAINT [FK_Activity_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([Id])
GO
ALTER TABLE [dbo].[Activity] CHECK CONSTRAINT [FK_Activity_Event]
GO
ALTER TABLE [dbo].[ActivityDate]  WITH CHECK ADD  CONSTRAINT [FK_ActivityDate_Activity] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activity] ([Id])
GO
ALTER TABLE [dbo].[ActivityDate] CHECK CONSTRAINT [FK_ActivityDate_Activity]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserActivityDate]  WITH CHECK ADD  CONSTRAINT [FK_UserActivityDate_ActivityDate] FOREIGN KEY([ActivityDateId])
REFERENCES [dbo].[ActivityDate] ([Id])
GO
ALTER TABLE [dbo].[UserActivityDate] CHECK CONSTRAINT [FK_UserActivityDate_ActivityDate]
GO
ALTER TABLE [dbo].[UserActivityDate]  WITH CHECK ADD  CONSTRAINT [FK_UserActivityDate_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserActivityDate] CHECK CONSTRAINT [FK_UserActivityDate_User]
GO
