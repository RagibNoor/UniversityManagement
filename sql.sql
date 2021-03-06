USE [master]
GO
/****** Object:  Database [UniversityManagement]    Script Date: 9/26/2018 6:41:02 PM ******/
CREATE DATABASE [UniversityManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManagement.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityManagement] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityManagement]
GO
/****** Object:  Table [dbo].[AssignTeacher]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[Credit] [decimal](5, 2) NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_AssignTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassAllocation]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassAllocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[Day] [varchar](50) NOT NULL,
	[StartTime] [time](0) NOT NULL,
	[EndTime] [time](0) NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_ClassAllocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [decimal](3, 2) NOT NULL,
	[Description] [varchar](50) NULL,
	[DepartmentId] [int] NOT NULL,
	[SemisterId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Deparment]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Deparment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](7) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Deparment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semister]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semister](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semister] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[Eamil] [varchar](max) NOT NULL,
	[Address] [varchar](max) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RegisterNo] [varchar](50) NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentEnrollCourse]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentEnrollCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Grade] [varchar](50) NULL,
	[Date] [date] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_StudentEnrollCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditToBeTaken] [decimal](5, 2) NOT NULL,
	[Address] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ClassAllocationView]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ClassAllocationView]
AS
SELECT dbo.Course.Code, dbo.Course.Name, dbo.Room.RoomNo, dbo.ClassAllocation.Day, dbo.ClassAllocation.StartTime, dbo.ClassAllocation.EndTime, dbo.Course.DepartmentId, dbo.ClassAllocation.Status
FROM     dbo.Course LEFT OUTER JOIN
                  dbo.ClassAllocation ON dbo.Course.Id = dbo.ClassAllocation.CourseId LEFT OUTER JOIN
                  dbo.Room ON dbo.ClassAllocation.RoomId = dbo.Room.Id LEFT OUTER JOIN
                  dbo.Deparment ON dbo.Course.DepartmentId = dbo.Deparment.Id AND dbo.ClassAllocation.DepartmentId = dbo.Deparment.Id

GO
/****** Object:  View [dbo].[CourseAssignToTeacher]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CourseAssignToTeacher]
AS
SELECT dbo.Course.Id AS CourseID, dbo.Course.Code AS CourseCode, dbo.Course.Name AS CourseName, dbo.Semister.Name AS SemisterName, dbo.Teacher.Id AS TeacherId, dbo.Teacher.TeacherName, dbo.Course.DepartmentId, 
                  dbo.AssignTeacher.Status
FROM     dbo.Course LEFT OUTER JOIN
                  dbo.AssignTeacher ON dbo.AssignTeacher.CourseId = dbo.Course.Id LEFT OUTER JOIN
                  dbo.Teacher ON dbo.AssignTeacher.TeacherId = dbo.Teacher.Id LEFT OUTER JOIN
                  dbo.Semister ON dbo.Course.SemisterId = dbo.Semister.Id

GO
/****** Object:  View [dbo].[StudentEnrollCourseView]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentEnrollCourseView]
AS
SELECT dbo.StudentEnrollCourse.Grade, dbo.Course.Code AS CourseCode, dbo.Course.Name AS CourseName, dbo.StudentEnrollCourse.StudentId, dbo.Course.Id AS CourseId
FROM     dbo.StudentEnrollCourse INNER JOIN
                  dbo.Course ON dbo.StudentEnrollCourse.CourseId = dbo.Course.Id

GO
/****** Object:  View [dbo].[StudentWithDepartmentView]    Script Date: 9/26/2018 6:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentWithDepartmentView]
AS
SELECT dbo.Student.DepartmentId, dbo.Deparment.Name AS Department, dbo.Student.Id, dbo.Student.Eamil, dbo.Student.Name, dbo.Student.RegisterNo
FROM     dbo.Student INNER JOIN
                  dbo.Deparment ON dbo.Student.DepartmentId = dbo.Deparment.Id

GO
SET IDENTITY_INSERT [dbo].[AssignTeacher] ON 

INSERT [dbo].[AssignTeacher] ([Id], [DepartmentId], [CourseId], [TeacherId], [Credit], [Status]) VALUES (1, 1, 2, 1, CAST(3.00 AS Decimal(5, 2)), 1)
INSERT [dbo].[AssignTeacher] ([Id], [DepartmentId], [CourseId], [TeacherId], [Credit], [Status]) VALUES (3, 1, 1004, 2, CAST(3.00 AS Decimal(5, 2)), 1)
INSERT [dbo].[AssignTeacher] ([Id], [DepartmentId], [CourseId], [TeacherId], [Credit], [Status]) VALUES (6, 6, 1006, 4, CAST(4.00 AS Decimal(5, 2)), 1)
SET IDENTITY_INSERT [dbo].[AssignTeacher] OFF
SET IDENTITY_INSERT [dbo].[ClassAllocation] ON 

INSERT [dbo].[ClassAllocation] ([Id], [DepartmentId], [CourseId], [RoomId], [Day], [StartTime], [EndTime], [Status]) VALUES (7, 1, 2, 1, N'Sunday', CAST(0x0000000000000000 AS Time), CAST(0x00302A0000000000 AS Time), 1)
INSERT [dbo].[ClassAllocation] ([Id], [DepartmentId], [CourseId], [RoomId], [Day], [StartTime], [EndTime], [Status]) VALUES (8, 1, 2, 1, N'Sunday', CAST(0x0050460000000000 AS Time), CAST(0x0080700000000000 AS Time), 1)
INSERT [dbo].[ClassAllocation] ([Id], [DepartmentId], [CourseId], [RoomId], [Day], [StartTime], [EndTime], [Status]) VALUES (10, 6, 1006, 4, N'Friday', CAST(0x0008070000000000 AS Time), CAST(0x00A8930000000000 AS Time), 1)
INSERT [dbo].[ClassAllocation] ([Id], [DepartmentId], [CourseId], [RoomId], [Day], [StartTime], [EndTime], [Status]) VALUES (11, 6, 1006, 4, N'Friday', CAST(0x00F0D20000000000 AS Time), CAST(0x0018F60000000000 AS Time), 1)
SET IDENTITY_INSERT [dbo].[ClassAllocation] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemisterId]) VALUES (2, N'cs101', N'Asp .Net', CAST(3.00 AS Decimal(3, 2)), N'assssss', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemisterId]) VALUES (1002, N'eee101', N'Digital logic design', CAST(3.00 AS Decimal(3, 2)), NULL, 6, 3)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemisterId]) VALUES (1003, N'cs111', N'Programming Language', CAST(4.00 AS Decimal(3, 2)), N'c++', 1, 3)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemisterId]) VALUES (1004, N'cs140', N'Programming Language 2', CAST(3.00 AS Decimal(3, 2)), N'Java', 1, 4)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemisterId]) VALUES (1005, N'cs110', N'Algorithm', CAST(3.00 AS Decimal(3, 2)), N'algorithem', 1, 6)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemisterId]) VALUES (1006, N'EEE111', N'Electrical Circuit', CAST(4.00 AS Decimal(3, 2)), NULL, 6, 6)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Deparment] ON 

INSERT [dbo].[Deparment] ([Id], [Code], [Name]) VALUES (1, N'CSE', N'Computer Science Engeering')
INSERT [dbo].[Deparment] ([Id], [Code], [Name]) VALUES (5, N'CE', N'Civil Engneering')
INSERT [dbo].[Deparment] ([Id], [Code], [Name]) VALUES (6, N'EEE', N'Electrical and Electronics Engineering')
INSERT [dbo].[Deparment] ([Id], [Code], [Name]) VALUES (8, N'BBA', N'BBA')
INSERT [dbo].[Deparment] ([Id], [Code], [Name]) VALUES (1008, N'Eng', N'English')
SET IDENTITY_INSERT [dbo].[Deparment] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (1, N'Lecturer ')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (2, N'Professor ')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (3, N' ASST. Professor ')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (4, N' Sr Lecturer ')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (5, N'Department Head')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (1, N'701')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (2, N'702')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (3, N'703')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (4, N'704')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[Semister] ON 

INSERT [dbo].[Semister] ([Id], [Name]) VALUES (1, N'Semester 1')
INSERT [dbo].[Semister] ([Id], [Name]) VALUES (2, N'Semester 2')
INSERT [dbo].[Semister] ([Id], [Name]) VALUES (3, N'Semester 3')
INSERT [dbo].[Semister] ([Id], [Name]) VALUES (4, N'Semester 4')
INSERT [dbo].[Semister] ([Id], [Name]) VALUES (5, N'Semester 5')
INSERT [dbo].[Semister] ([Id], [Name]) VALUES (6, N'Semester 6')
INSERT [dbo].[Semister] ([Id], [Name]) VALUES (7, N'Semester 7')
INSERT [dbo].[Semister] ([Id], [Name]) VALUES (8, N'Semester 8')
SET IDENTITY_INSERT [dbo].[Semister] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [Eamil], [Address], [ContactNumber], [DepartmentId], [RegisterNo], [Date]) VALUES (5, N'Ragib', N'ragibnoor19@gmail.com', N'comilla', N'01682048410', 1, N'CSE-2018-001', CAST(0xBF3E0B00 AS Date))
INSERT [dbo].[Student] ([Id], [Name], [Eamil], [Address], [ContactNumber], [DepartmentId], [RegisterNo], [Date]) VALUES (6, N'anik', N'anik@gmail.com', N'comilla', N'01682048410', 1, N'CSE-2017-001', CAST(0xF33C0B00 AS Date))
INSERT [dbo].[Student] ([Id], [Name], [Eamil], [Address], [ContactNumber], [DepartmentId], [RegisterNo], [Date]) VALUES (7, N'ashad', N'ashad@gmail.com', N'aaaaa', N'01682048410', 6, N'EEE-2018-001', CAST(0xC13E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[StudentEnrollCourse] ON 

INSERT [dbo].[StudentEnrollCourse] ([Id], [StudentId], [CourseId], [Grade], [Date], [DepartmentId]) VALUES (1, 5, 2, N'A+', CAST(0xC03E0B00 AS Date), 1)
INSERT [dbo].[StudentEnrollCourse] ([Id], [StudentId], [CourseId], [Grade], [Date], [DepartmentId]) VALUES (2, 5, 1003, N'Not Graded Yet', CAST(0xC03E0B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[StudentEnrollCourse] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNumber], [DesignationId], [DepartmentId], [CreditToBeTaken], [Address]) VALUES (1, N'Ragib', N'ragibnoor19@gmail.com', N'01682048410', 1, 1, CAST(12.00 AS Decimal(5, 2)), N'Comilla')
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNumber], [DesignationId], [DepartmentId], [CreditToBeTaken], [Address]) VALUES (2, N'Imran', N'imran@gmail.com', N'017845874', 2, 1, CAST(18.00 AS Decimal(5, 2)), N'Dhaka')
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNumber], [DesignationId], [DepartmentId], [CreditToBeTaken], [Address]) VALUES (3, N'Asif', N'asif@gmail.com', N'017845874', 2, 6, CAST(2.00 AS Decimal(5, 2)), N'Dhaka')
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNumber], [DesignationId], [DepartmentId], [CreditToBeTaken], [Address]) VALUES (4, N'anik', N'anik@gmail.com', N'017845874', 1, 6, CAST(11.00 AS Decimal(5, 2)), N'Dhaka')
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNumber], [DesignationId], [DepartmentId], [CreditToBeTaken], [Address]) VALUES (5, N'akib', N'mahiuddinahmed63@gmail.com', N'2644465', 5, 1, CAST(11.00 AS Decimal(5, 2)), N'dhaka')
INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNumber], [DesignationId], [DepartmentId], [CreditToBeTaken], [Address]) VALUES (6, N'ashad', N'ashad@gmail.com', N'01682048410', 1, 6, CAST(11.00 AS Decimal(5, 2)), N'dhaka')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
ALTER TABLE [dbo].[StudentEnrollCourse] ADD  CONSTRAINT [DF_StudentEnrollCourse_Grade]  DEFAULT ('Not Graded Yet') FOR [Grade]
GO
ALTER TABLE [dbo].[AssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_AssignTeacher_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AssignTeacher] CHECK CONSTRAINT [FK_AssignTeacher_Course]
GO
ALTER TABLE [dbo].[AssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_AssignTeacher_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[AssignTeacher] CHECK CONSTRAINT [FK_AssignTeacher_Teacher]
GO
ALTER TABLE [dbo].[ClassAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ClassAllocation_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[ClassAllocation] CHECK CONSTRAINT [FK_ClassAllocation_Course]
GO
ALTER TABLE [dbo].[ClassAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ClassAllocation_Deparment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Deparment] ([Id])
GO
ALTER TABLE [dbo].[ClassAllocation] CHECK CONSTRAINT [FK_ClassAllocation_Deparment]
GO
ALTER TABLE [dbo].[ClassAllocation]  WITH CHECK ADD  CONSTRAINT [FK_ClassAllocation_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[ClassAllocation] CHECK CONSTRAINT [FK_ClassAllocation_Room]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Deparment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Deparment] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Deparment]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semister] FOREIGN KEY([SemisterId])
REFERENCES [dbo].[Semister] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semister]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Deparment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Deparment] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Deparment]
GO
ALTER TABLE [dbo].[StudentEnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentEnrollCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[StudentEnrollCourse] CHECK CONSTRAINT [FK_StudentEnrollCourse_Course]
GO
ALTER TABLE [dbo].[StudentEnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentEnrollCourse_Deparment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Deparment] ([Id])
GO
ALTER TABLE [dbo].[StudentEnrollCourse] CHECK CONSTRAINT [FK_StudentEnrollCourse_Deparment]
GO
ALTER TABLE [dbo].[StudentEnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentEnrollCourse_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[StudentEnrollCourse] CHECK CONSTRAINT [FK_StudentEnrollCourse_Student]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Deparment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Deparment] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Deparment]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Course"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ClassAllocation"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Room"
            Begin Extent = 
               Top = 7
               Left = 532
               Bottom = 126
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Deparment"
            Begin Extent = 
               Top = 7
               Left = 774
               Bottom = 148
               Right = 968
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClassAllocationView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClassAllocationView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[36] 4[25] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Course"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "AssignTeacher"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Teacher"
            Begin Extent = 
               Top = 127
               Left = 574
               Bottom = 290
               Right = 782
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Semister"
            Begin Extent = 
               Top = 0
               Left = 542
               Bottom = 119
               Right = 736
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CourseAssignToTeacher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'= 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CourseAssignToTeacher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CourseAssignToTeacher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "StudentEnrollCourse"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentEnrollCourseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentEnrollCourseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Deparment"
            Begin Extent = 
               Top = 7
               Left = 296
               Bottom = 148
               Right = 490
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Student"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 248
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentWithDepartmentView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentWithDepartmentView'
GO
USE [master]
GO
ALTER DATABASE [UniversityManagement] SET  READ_WRITE 
GO
