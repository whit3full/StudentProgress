USE [StudentProgress]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 22.06.2024 13:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[ID_Group] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Course] [nchar](10) NOT NULL,
	[Specialty] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[ID_Group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journal]    Script Date: 22.06.2024 13:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[ID_Journal] [int] IDENTITY(1,1) NOT NULL,
	[ID_Subject] [int] NOT NULL,
	[ID_Group] [int] NOT NULL,
	[ID_Student] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Grade] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[ID_Journal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 22.06.2024 13:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID_Role] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 22.06.2024 13:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[ID_session] [int] IDENTITY(1,1) NOT NULL,
	[ID_Subject] [int] NOT NULL,
	[ID_Teacher] [int] NOT NULL,
	[ID_Group] [int] NOT NULL,
	[ID_Student] [int] NOT NULL,
	[TypeOfCertification] [nvarchar](50) NOT NULL,
	[DueDate] [date] NOT NULL,
	[Grade] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[ID_session] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 22.06.2024 13:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID_Student] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[NumberPhone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID_Student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 22.06.2024 13:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[ID_Subject] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](50) NOT NULL,
	[FullSubject] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[ID_Subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 22.06.2024 13:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID_Teacher] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[Post] [nvarchar](50) NOT NULL,
	[ID_Subject] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID_Teacher] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22.06.2024 13:03:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ID_Role] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([ID_Group], [Name], [Course], [Specialty]) VALUES (1, N'ИСП', N'1         ', N'Информационные системы и программирование')
INSERT [dbo].[Group] ([ID_Group], [Name], [Course], [Specialty]) VALUES (2, N'ПК', N'2         ', N'Повар кондитер')
INSERT [dbo].[Group] ([ID_Group], [Name], [Course], [Specialty]) VALUES (3, N'ЭЛ', N'3         ', N'Электрик')
INSERT [dbo].[Group] ([ID_Group], [Name], [Course], [Specialty]) VALUES (4, N'СВ', N'4         ', N'Сварщик')
INSERT [dbo].[Group] ([ID_Group], [Name], [Course], [Specialty]) VALUES (5, N'СР', N'1         ', N'Слесарь')
INSERT [dbo].[Group] ([ID_Group], [Name], [Course], [Specialty]) VALUES (6, N'П', N'2         ', N'Повар')
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[Journal] ON 

INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (1, 1, 1, 1, CAST(N'2024-06-03' AS Date), N'5         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (2, 2, 1, 2, CAST(N'2024-06-02' AS Date), N'4         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (3, 3, 2, 3, CAST(N'2024-06-04' AS Date), N'4         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (4, 1, 1, 3, CAST(N'2024-06-01' AS Date), N'5         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (5, 2, 2, 1, CAST(N'2024-06-04' AS Date), N'3         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (6, 3, 3, 2, CAST(N'2024-06-04' AS Date), N'3         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (7, 1, 3, 3, CAST(N'2024-06-04' AS Date), N'5         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (8, 2, 1, 1, CAST(N'2024-06-04' AS Date), N'4         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (9, 3, 2, 2, CAST(N'2024-06-02' AS Date), N'5         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (10, 1, 2, 3, CAST(N'2024-06-04' AS Date), N'5         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (11, 2, 3, 1, CAST(N'2024-06-03' AS Date), N'4         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (12, 3, 1, 2, CAST(N'2024-06-04' AS Date), N'4         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (16, 3, 2, 3, CAST(N'2024-06-05' AS Date), N'3         ')
INSERT [dbo].[Journal] ([ID_Journal], [ID_Subject], [ID_Group], [ID_Student], [Date], [Grade]) VALUES (17, 2, 2, 2, CAST(N'2024-06-09' AS Date), N'5         ')
SET IDENTITY_INSERT [dbo].[Journal] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID_Role], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([ID_Role], [Name]) VALUES (2, N'Teacher')
INSERT [dbo].[Role] ([ID_Role], [Name]) VALUES (3, N'Student')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (1, 1, 1, 1, 1, N'Зачет', CAST(N'2024-06-04' AS Date), N'5         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (2, 2, 2, 1, 2, N'Демонстрационный экзамен', CAST(N'2024-06-04' AS Date), N'4         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (3, 3, 3, 2, 3, N'Зачет', CAST(N'2024-06-04' AS Date), N'3         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (4, 1, 1, 1, 3, N'Курсовая работа', CAST(N'2024-06-04' AS Date), N'5         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (5, 2, 2, 2, 1, N'Демонстрационный экзамен', CAST(N'2024-06-04' AS Date), N'4         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (6, 3, 3, 3, 2, N'Зачет', CAST(N'2024-06-04' AS Date), N'5         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (7, 1, 3, 3, 3, N'Курсовой проект', CAST(N'2024-06-04' AS Date), N'5         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (8, 2, 1, 1, 1, N'Финальный экзамен', CAST(N'2024-06-04' AS Date), N'4         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (9, 3, 2, 2, 2, N'Зачет', CAST(N'2024-06-04' AS Date), N'3         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (10, 1, 2, 3, 3, N'Экзамен', CAST(N'2024-06-04' AS Date), N'5         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (11, 2, 3, 1, 1, N'Демонстрационный экзамен', CAST(N'2024-06-04' AS Date), N'3         ')
INSERT [dbo].[Session] ([ID_session], [ID_Subject], [ID_Teacher], [ID_Group], [ID_Student], [TypeOfCertification], [DueDate], [Grade]) VALUES (12, 3, 1, 2, 2, N'Зачет', CAST(N'2024-06-04' AS Date), N'5         ')
SET IDENTITY_INSERT [dbo].[Session] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (1, N'Иванов', N'Иван', N'Иванович', CAST(N'2000-01-01' AS Date), N'1234567890')
INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (2, N'Петров', N'Петр', N'Петрович', CAST(N'2001-02-02' AS Date), N'9876543210')
INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (3, N'Сидоров', N'Павел', N'Сидорович', CAST(N'2002-03-03' AS Date), N'5551234567')
INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (4, N'Кузнецов', N'Иван', N'Иванович', CAST(N'2003-04-04' AS Date), N'7775551234')
INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (5, N'Смирнов', N'Дамир', N'Алексеевич', CAST(N'2004-05-05' AS Date), N'9997775555')
INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (6, N'Соколов', N'Владислав', N'Сергеевич', CAST(N'2005-06-06' AS Date), N'6669997777')
INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (7, N'Лебедев', N'Никита', N'Алексеевич', CAST(N'2006-07-07' AS Date), N'4446669999')
INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (8, N'Козлов', N'Дамьян', N'Егорович', CAST(N'2007-08-08' AS Date), N'3334446666')
INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (9, N'Кузовна', N'Анна', N'Константиновна', CAST(N'2008-09-09' AS Date), N'2223334444')
INSERT [dbo].[Student] ([ID_Student], [Surname], [Name], [Patronymic], [DateOfBirth], [NumberPhone]) VALUES (10, N'Морозова', N'Евгения', N'Сергеевна', CAST(N'2009-10-10' AS Date), N'1112223333')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (1, N'Математика', N'Полный курс математики, включая алгебру, геометрию и математический анализ')
INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (2, N'Физика', N'
Полный курс физики, включая механику, термодинамику и электромагнетизм')
INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (3, N'Компьютерная наука', N'Полный курс компьютерных наук, включая программирование, алгоритмы и структуры данных')
INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (4, N'Биология', N'Полный курс биологии, включая ботанику, зоологию и экологию')
INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (5, N'Химия', N'Полный курс химии, включая неорганическую, органическую и физическую химию')
INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (6, N'Инженерное искусство', N'
Полный курс инженерного дела, включая механику, электротехнику и гражданское строительство')
INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (7, N'Экономика', N'Полный курс экономики, включая микроэкономику, макроэкономику и международную торговлю')
INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (8, N'Философия', N'Полный курс философии, включая этику, логику и метафизику')
INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (9, N'История', N'Полный курс истории, включая древнюю, средневековую и современную историю')
INSERT [dbo].[Subject] ([ID_Subject], [SubjectName], [FullSubject]) VALUES (10, N'Литература', N'Полный курс литературы, включая поэзию, драматургию и романы')
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (1, N'Кутузов', N'Иван', N'Иванович', N'Преподаватель', 1)
INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (2, N'Петрова', N'Ирина', N'Петровна', N'Ассистент ', 2)
INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (3, N'Сидоров', N'Даниил', N'Данилович', N'Заведующий отделением', 3)
INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (4, N'Кузнецов', N'Владислав', N'Владимирович', N'Преподаватель', 6)
INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (5, N'Попов', N'Павел', N'Денисович', N'Ассистент', 4)
INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (6, N'Соколова', N'Александра', N'Олеговна', N'Преподаватель', 5)
INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (7, N'Лебедев', N'Вечеслав', N'Максимович', N'Преподаватель', 7)
INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (8, N'Козлова', N'Дамина', N'Владиславовна', N'Ассистент', 8)
INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (9, N'Новиков', N'Алексей', N'Сергеевич', N'Преподаватель', 9)
INSERT [dbo].[Teacher] ([ID_Teacher], [Surname], [Name], [Patronymic], [Post], [ID_Subject]) VALUES (10, N'Морозов', N'Иван', N'Иванович', N'Мастер', 4)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID_User], [Login], [Password], [ID_Role]) VALUES (1, N'admin', N'admin1', 1)
INSERT [dbo].[Users] ([ID_User], [Login], [Password], [ID_Role]) VALUES (2, N'teacher', N'teacher123', 2)
INSERT [dbo].[Users] ([ID_User], [Login], [Password], [ID_Role]) VALUES (3, N'Ivanov', N'Ivanov1', 3)
INSERT [dbo].[Users] ([ID_User], [Login], [Password], [ID_Role]) VALUES (4, N'Petrov', N'Petrov23', 3)
INSERT [dbo].[Users] ([ID_User], [Login], [Password], [ID_Role]) VALUES (6, N'Sidorov', N'Sidorov12', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Group] FOREIGN KEY([ID_Group])
REFERENCES [dbo].[Group] ([ID_Group])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Group]
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Student] FOREIGN KEY([ID_Student])
REFERENCES [dbo].[Student] ([ID_Student])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Student]
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Subject] FOREIGN KEY([ID_Subject])
REFERENCES [dbo].[Subject] ([ID_Subject])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Subject]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Group] FOREIGN KEY([ID_Group])
REFERENCES [dbo].[Group] ([ID_Group])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Group]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Student] FOREIGN KEY([ID_Student])
REFERENCES [dbo].[Student] ([ID_Student])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Student]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Subject] FOREIGN KEY([ID_Subject])
REFERENCES [dbo].[Subject] ([ID_Subject])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Subject]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Teacher] FOREIGN KEY([ID_Teacher])
REFERENCES [dbo].[Teacher] ([ID_Teacher])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Teacher]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Subject] FOREIGN KEY([ID_Subject])
REFERENCES [dbo].[Subject] ([ID_Subject])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Subject]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([ID_Role])
REFERENCES [dbo].[Role] ([ID_Role])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
