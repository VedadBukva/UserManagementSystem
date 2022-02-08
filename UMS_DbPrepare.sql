USE [UserManagementSystem]
GO
/****** Object:  User [ums]    Script Date: 8.2.2022. 00:30:24 ******/
CREATE USER [ums] FOR LOGIN [ums] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [ums]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [ums]
GO
ALTER ROLE [db_datareader] ADD MEMBER [ums]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [ums]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 8.2.2022. 00:30:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8.2.2022. 00:30:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Status] [nvarchar](100) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[ModifiedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 8.2.2022. 00:30:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermission](
	[Id] [int] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[PermissionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserPermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Permission] ([Id], [Code], [Description]) VALUES (N'82d72849-3e46-4983-86a0-325486a170a1', N'1-11', N'HR Admin')
GO
INSERT [dbo].[Permission] ([Id], [Code], [Description]) VALUES (N'1857a1c7-782f-4e52-8453-e2e04d33290b', N'1-10', N'Admin')
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Status], [CreatedOn], [ModifiedOn]) VALUES (N'f9047c09-af8d-474b-ad06-38e407d2a021', N't1', N'aa', N'tt', N'tt', N'tt', N'Inactive', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-02-07T21:15:54.6899264' AS DateTime2))
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Status], [CreatedOn], [ModifiedOn]) VALUES (N'f9047c09-af8d-474b-ad06-38e407d2a022', N't2', N'bb', N'tt', N'tt', N'tt', N'Active', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-02-07T22:00:41.3095308' AS DateTime2))
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Status], [CreatedOn], [ModifiedOn]) VALUES (N'f9047c09-af8d-474b-ad06-38e407d2a023', N't3', N'cc', N'tt', N'tt', N'tt', N'Active', CAST(N'2022-02-07T03:46:46.3112204' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Status], [CreatedOn], [ModifiedOn]) VALUES (N'f9047c09-af8d-474b-ad06-38e407d2a024', N't4', N'dd', N'tt', N'tt', N'tt', N'Active', CAST(N'2022-02-07T03:46:46.3112204' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Status], [CreatedOn], [ModifiedOn]) VALUES (N'f9047c09-af8d-474b-ad06-38e407d2a025', N't5', N'ee', N'jj', N'tt', N'tt', N'Inactive', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-02-07T21:18:20.9341387' AS DateTime2))
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Status], [CreatedOn], [ModifiedOn]) VALUES (N'f9047c09-af8d-474b-ad06-38e407d2a026', N't6', N'ff', N'tt', N'tt', N'tt', N'Active', CAST(N'2022-02-07T03:46:46.3112204' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Status], [CreatedOn], [ModifiedOn]) VALUES (N'f9047c09-af8d-474b-ad06-38e407d2a027', N't7', N'gg', N'tt', N'tt', N'tt', N'Active', CAST(N'2022-02-07T03:46:46.3112204' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Status], [CreatedOn], [ModifiedOn]) VALUES (N'f9047c09-af8d-474b-ad06-38e407d2a028', N't8', N'hh', N'tt', N'tt', N'tt', N'Active', CAST(N'2022-02-07T03:46:46.3112204' AS DateTime2), NULL)
GO
INSERT [dbo].[User] ([Id], [FirstName], [LastName], [Username], [Password], [Email], [Status], [CreatedOn], [ModifiedOn]) VALUES (N'f9047c09-af8d-474b-ad06-38e407d2a029', N't9', N'tt', N'tt', N'tt', N'tt', N'Inactive', CAST(N'2022-02-07T03:46:46.3112204' AS DateTime2), NULL)
GO
ALTER TABLE [dbo].[UserPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserPermission_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK_UserPermission_Permission]
GO
ALTER TABLE [dbo].[UserPermission]  WITH CHECK ADD  CONSTRAINT [FK_UserPermission_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK_UserPermission_User]
GO
