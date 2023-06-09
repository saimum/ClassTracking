USE [DB_ClassTracking]
GO
/****** Object:  Table [dbo].[ClassDataModels]    Script Date: 3/16/2023 3:49:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassDataModels](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[MaxStudent] [int] NOT NULL,
	[Standard] [int] NOT NULL,
	[TeacherId] [bigint] NULL,
 CONSTRAINT [PK_ClassDataModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 3/16/2023 3:49:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[NID] [varchar](50) NOT NULL,
	[ClassDataModelId] [bigint] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 3/16/2023 3:49:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[NID] [varchar](50) NOT NULL,
	[ClassDataModelId] [bigint] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ClassDataModels] ON 

INSERT [dbo].[ClassDataModels] ([Id], [Name], [MaxStudent], [Standard], [TeacherId]) VALUES (1, N'Class 1', 2, 1, NULL)
INSERT [dbo].[ClassDataModels] ([Id], [Name], [MaxStudent], [Standard], [TeacherId]) VALUES (2, N'Calss 2', 2, 2, NULL)
SET IDENTITY_INSERT [dbo].[ClassDataModels] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (1, 1, N'Student 1', N'NID1', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (2, 0, N'Student 2', N'NID2', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (3, 1, N'Student 3', N'NID3', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (4, 1, N'Student 4', N'NID4', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (5, 1, N'Student 5', N'NID5', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (6, 1, N'Student 6', N'NID6', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (7, 0, N'Student 6', N'NID6', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (8, 1, N'Student 6', N'NID6', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (9, 0, N'Student 6', N'NID6', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (10, 0, N'Student 6', N'NID6', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (11, 0, N'Student 11', N'NID11', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (12, 0, N'Student 20', N'NID20', NULL)
INSERT [dbo].[Students] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (13, 0, N'Student 22', N'NID22', NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (1, 1, N'Teacher 1', N'NID1', NULL)
INSERT [dbo].[Teachers] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (2, 1, N'Teacher 2', N'NID2', NULL)
INSERT [dbo].[Teachers] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (3, 1, N'Teacher 3', N'NID3', NULL)
INSERT [dbo].[Teachers] ([Id], [IsActive], [Name], [NID], [ClassDataModelId]) VALUES (4, 1, N'Teacher4', N'NID4', NULL)
SET IDENTITY_INSERT [dbo].[Teachers] OFF
GO
