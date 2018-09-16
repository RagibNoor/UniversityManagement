USE [master]
GO
/****** Object:  Database [UniversityManagement]    Script Date: 9/17/2018 12:58:41 AM ******/
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
/****** Object:  Table [dbo].[Course]    Script Date: 9/17/2018 12:58:41 AM ******/
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
/****** Object:  Table [dbo].[Deparment]    Script Date: 9/17/2018 12:58:41 AM ******/
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
/****** Object:  Table [dbo].[Designation]    Script Date: 9/17/2018 12:58:41 AM ******/
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
/****** Object:  Table [dbo].[Semister]    Script Date: 9/17/2018 12:58:41 AM ******/
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 9/17/2018 12:58:41 AM ******/
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
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemisterId]) VALUES (2, N'cs101', N'raaaa', CAST(3.00 AS Decimal(3, 2)), N'assssss', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemisterId]) VALUES (1002, N'eee101', N'Digital logic design', CAST(3.00 AS Decimal(3, 2)), NULL, 6, 3)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Deparment] ON 

INSERT [dbo].[Deparment] ([Id], [Code], [Name]) VALUES (1, N'CSE101', N'CSE')
INSERT [dbo].[Deparment] ([Id], [Code], [Name]) VALUES (5, N'C-105', N'CIVIL')
INSERT [dbo].[Deparment] ([Id], [Code], [Name]) VALUES (6, N'E-123', N'EEE')
INSERT [dbo].[Deparment] ([Id], [Code], [Name]) VALUES (8, N'B-123', N'BBA')
SET IDENTITY_INSERT [dbo].[Deparment] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (1, N'Lecturer ')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (2, N'Professor ')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (3, N' ASST. Professor ')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (4, N' Sr Lecturer ')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (5, N'Department Head')
SET IDENTITY_INSERT [dbo].[Designation] OFF
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
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [TeacherName], [Email], [ContactNumber], [DesignationId], [DepartmentId], [CreditToBeTaken], [Address]) VALUES (1, N'Ragib', N'ragibnoor19@gmail.com', N'01682048410', 1, 1, CAST(12.00 AS Decimal(5, 2)), N'Comilla')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
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
USE [master]
GO
ALTER DATABASE [UniversityManagement] SET  READ_WRITE 
GO
