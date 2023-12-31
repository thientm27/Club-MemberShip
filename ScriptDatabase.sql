USE [master]
GO
/****** Object:  Database [ClubMembership]    Script Date: 8/11/2023 5:15:00 PM ******/
CREATE DATABASE [ClubMembership]

USE [ClubMembership]
GO
/****** Object:  Table [dbo].[Club]    Script Date: 8/11/2023 5:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Club](
	[Id] [int] NOT NULL,
	[Code] [nchar](5) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Logo] [nchar](150) NULL,
	[ShortDecription] [nvarchar](50) NULL,
	[LongDecription] [nvarchar](200) NULL,
	[DateOfEstablishment] [date] NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Club] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClubActivity]    Script Date: 8/11/2023 5:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClubActivity](
	[Id] [int] NOT NULL,
	[ClubId] [int] NOT NULL,
	[StartDay] [date] NOT NULL,
	[EndDay] [date] NULL,
	[CreateDay] [date] NOT NULL,
	[Status] [int] NULL,
	[TimeLine] [int] NULL,
 CONSTRAINT [PK_ClubActivity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClubBoard]    Script Date: 8/11/2023 5:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClubBoard](
	[Id] [int] NOT NULL,
	[ClubId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ShortDecription] [nvarchar](50) NULL,
	[LongDecription] [nvarchar](200) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_ClubBoard_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grade]    Script Date: 8/11/2023 5:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grade](
	[Id] [int] NOT NULL,
	[GradeYear] [date] NOT NULL,
	[GraduateYear] [date] NULL,
	[ExpeiredYear] [date] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Major]    Script Date: 8/11/2023 5:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Major](
	[Id] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Detail] [nvarchar](100) NULL,
	[Semeter] [int] NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Major] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberRole]    Script Date: 8/11/2023 5:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberRole](
	[MembershipId] [int] NOT NULL,
	[ClubBoardId] [int] NOT NULL,
	[StartDay] [date] NULL,
	[EndDay] [date] NOT NULL,
	[Status] [int] NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_MemberRole] PRIMARY KEY CLUSTERED 
(
	[MembershipId] ASC,
	[ClubBoardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membership]    Script Date: 8/11/2023 5:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membership](
	[StudentId] [int] NOT NULL,
	[ClubId] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[JoinDate] [date] NULL,
	[QuitDate] [date] NULL,
	[NickName] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Membership] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participant]    Script Date: 8/11/2023 5:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participant](
	[MembershipId] [int] NOT NULL,
	[ClubActivityId] [int] NOT NULL,
	[JoinDate] [date] NOT NULL,
	[LeaveDate] [date] NULL,
	[RegisterDate] [date] NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Participant] PRIMARY KEY CLUSTERED 
(
	[MembershipId] ASC,
	[ClubActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 8/11/2023 5:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[MajorId] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
	[DateOfBirth] [date] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClubActivity]  WITH CHECK ADD  CONSTRAINT [FK_ClubActivity_Club] FOREIGN KEY([ClubId])
REFERENCES [dbo].[Club] ([Id])
GO
ALTER TABLE [dbo].[ClubActivity] CHECK CONSTRAINT [FK_ClubActivity_Club]
GO
ALTER TABLE [dbo].[ClubBoard]  WITH CHECK ADD  CONSTRAINT [FK_ClubBoard_Club] FOREIGN KEY([ClubId])
REFERENCES [dbo].[Club] ([Id])
GO
ALTER TABLE [dbo].[ClubBoard] CHECK CONSTRAINT [FK_ClubBoard_Club]
GO
ALTER TABLE [dbo].[MemberRole]  WITH CHECK ADD  CONSTRAINT [FK_MemberRole_ClubBoard] FOREIGN KEY([ClubBoardId])
REFERENCES [dbo].[ClubBoard] ([Id])
GO
ALTER TABLE [dbo].[MemberRole] CHECK CONSTRAINT [FK_MemberRole_ClubBoard]
GO
ALTER TABLE [dbo].[MemberRole]  WITH CHECK ADD  CONSTRAINT [FK_MemberRole_Membership] FOREIGN KEY([MembershipId])
REFERENCES [dbo].[Membership] ([Id])
GO
ALTER TABLE [dbo].[MemberRole] CHECK CONSTRAINT [FK_MemberRole_Membership]
GO
ALTER TABLE [dbo].[Membership]  WITH CHECK ADD  CONSTRAINT [FK_Membership_Club] FOREIGN KEY([ClubId])
REFERENCES [dbo].[Club] ([Id])
GO
ALTER TABLE [dbo].[Membership] CHECK CONSTRAINT [FK_Membership_Club]
GO
ALTER TABLE [dbo].[Membership]  WITH CHECK ADD  CONSTRAINT [FK_Membership_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Membership] CHECK CONSTRAINT [FK_Membership_Student]
GO
ALTER TABLE [dbo].[Participant]  WITH CHECK ADD  CONSTRAINT [FK_Participant_ClubActivity] FOREIGN KEY([ClubActivityId])
REFERENCES [dbo].[ClubActivity] ([Id])
GO
ALTER TABLE [dbo].[Participant] CHECK CONSTRAINT [FK_Participant_ClubActivity]
GO
ALTER TABLE [dbo].[Participant]  WITH CHECK ADD  CONSTRAINT [FK_Participant_Membership] FOREIGN KEY([MembershipId])
REFERENCES [dbo].[Membership] ([Id])
GO
ALTER TABLE [dbo].[Participant] CHECK CONSTRAINT [FK_Participant_Membership]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Grade] FOREIGN KEY([GradeId])
REFERENCES [dbo].[Grade] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Grade]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Major] FOREIGN KEY([MajorId])
REFERENCES [dbo].[Major] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Major]
GO
USE [master]
GO
ALTER DATABASE [ClubMembership] SET  READ_WRITE 
GO
