USE [master];
GO

CREATE DATABASE [PruebaRebardor];
GO

USE [PruebaRebardor];
GO

-- Crear tabla Companies
CREATE TABLE [dbo].[Companies](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(255)
);
GO

-- Crear tabla Employee
CREATE TABLE [dbo].[Employee](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [CompanyId] INT,
    [CreatedOn] DATETIME DEFAULT GETDATE(),
    [DeletedOn] DATETIME,
    [Email] NVARCHAR(255),
    [Fax] NVARCHAR(50),
    [Name] NVARCHAR(255),
    [LastLogin] DATETIME,
    [Password] NVARCHAR(255),
    [PortalId] INT,
    [RoleId] INT,
    [StatusId] INT,
    [Telephone] NVARCHAR(50),
    [UpdatedOn] DATETIME
);
GO

-- Crear tabla Roles
CREATE TABLE [dbo].[Roles](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100)
);
GO

-- Crear tabla Status
CREATE TABLE [dbo].[Status](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100)
);
GO

-- Insertar datos en Companies
SET IDENTITY_INSERT [dbo].[Companies] ON;
INSERT INTO [dbo].[Companies] ([Id], [Name]) VALUES (1, N'Company A');
INSERT INTO [dbo].[Companies] ([Id], [Name]) VALUES (2, N'Company B');
INSERT INTO [dbo].[Companies] ([Id], [Name]) VALUES (3, N'Company C');
SET IDENTITY_INSERT [dbo].[Companies] OFF;
GO

-- Insertar datos en Employee
SET IDENTITY_INSERT [dbo].[Employee] ON;
INSERT INTO [dbo].[Employee] ([Id], [CompanyId], [CreatedOn], [Email], [Fax], [Name], [Password], [RoleId], [StatusId], [Telephone])
VALUES (1, 3, CAST(N'2024-07-05T00:50:54.480' AS DATETIME), N'usuario1@gmail.com', N'string', N'Usuario 1', N'4a3f06ab818f057c3588be31d7216c773282fe809851a9493cbe5a072d4e169c', 1, 1, N'string');
INSERT INTO [dbo].[Employee] ([Id], [CompanyId], [CreatedOn], [Email], [Fax], [Name], [Password], [RoleId], [StatusId], [Telephone])
VALUES (2, 3, CAST(N'2024-07-05T00:54:12.367' AS DATETIME), N'usuario2@gmail.com', N'Fax 2', N'Usuario 2', N'4a3f06ab818f057c3588be31d7216c773282fe809851a9493cbe5a072d4e169c', 1, 1, N'string');
INSERT INTO [dbo].[Employee] ([Id], [CompanyId], [CreatedOn], [Email], [Fax], [Name], [LastLogin], [Password], [RoleId], [StatusId], [Telephone])
VALUES (3, 3, CAST(N'2024-07-05T00:56:05.493' AS DATETIME), N'usuario3@gmail.com', N'string', N'Usuario 3', CAST(N'2024-07-05T10:31:20.903' AS DATETIME), N'4a3f06ab818f057c3588be31d7216c773282fe809851a9493cbe5a072d4e169c', 1, 1, N'string');
SET IDENTITY_INSERT [dbo].[Employee] OFF;
GO

-- Insertar datos en Roles
SET IDENTITY_INSERT [dbo].[Roles] ON;
INSERT INTO [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin');
INSERT INTO [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User');
INSERT INTO [dbo].[Roles] ([Id], [Name]) VALUES (3, N'Guest');
SET IDENTITY_INSERT [dbo].[Roles] OFF;
GO

-- Insertar datos en Status
SET IDENTITY_INSERT [dbo].[Status] ON;
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (1, N'Active');
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (2, N'Inactive');
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (3, N'Pending');
SET IDENTITY_INSERT [dbo].[Status] OFF;
GO

-- Configurar claves foráneas
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT FK_Users_Companies FOREIGN KEY([CompanyId]) REFERENCES [dbo].[Companies]([Id]);
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT FK_Users_Roles FOREIGN KEY([RoleId]) REFERENCES [dbo].[Roles]([Id]);
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT FK_Users_Status FOREIGN KEY([StatusId]) REFERENCES [dbo].[Status]([Id]);
GO

-- Configurar base de datos
ALTER DATABASE [PruebaRebardor] SET READ_WRITE;
GO

-- Base de datos para Test

USE [master];
GO

CREATE DATABASE [PruebaRebardorTest];
GO

USE [PruebaRebardorTest];
GO

-- Crear tabla Companies
CREATE TABLE [dbo].[Companies](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(255)
);
GO

-- Crear tabla Employee
CREATE TABLE [dbo].[Employee](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [CompanyId] INT,
    [CreatedOn] DATETIME DEFAULT GETDATE(),
    [DeletedOn] DATETIME,
    [Email] NVARCHAR(255),
    [Fax] NVARCHAR(50),
    [Name] NVARCHAR(255),
    [LastLogin] DATETIME,
    [Password] NVARCHAR(255),
    [PortalId] INT,
    [RoleId] INT,
    [StatusId] INT,
    [Telephone] NVARCHAR(50),
    [UpdatedOn] DATETIME
);
GO

-- Crear tabla Roles
CREATE TABLE [dbo].[Roles](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100)
);
GO

-- Crear tabla Status
CREATE TABLE [dbo].[Status](
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100)
);
GO

-- Insertar datos en Companies
SET IDENTITY_INSERT [dbo].[Companies] ON;
INSERT INTO [dbo].[Companies] ([Id], [Name]) VALUES (1, N'Company A');
INSERT INTO [dbo].[Companies] ([Id], [Name]) VALUES (2, N'Company B');
INSERT INTO [dbo].[Companies] ([Id], [Name]) VALUES (3, N'Company C');
SET IDENTITY_INSERT [dbo].[Companies] OFF;
GO

-- Insertar datos en Employee
SET IDENTITY_INSERT [dbo].[Employee] ON;
INSERT INTO [dbo].[Employee] ([Id], [CompanyId], [CreatedOn], [Email], [Fax], [Name], [Password], [RoleId], [StatusId], [Telephone])
VALUES (1, 3, CAST(N'2024-07-05T00:50:54.480' AS DATETIME), N'usuario1@gmail.com', N'string', N'Usuario 1', N'4a3f06ab818f057c3588be31d7216c773282fe809851a9493cbe5a072d4e169c', 1, 1, N'string');
INSERT INTO [dbo].[Employee] ([Id], [CompanyId], [CreatedOn], [Email], [Fax], [Name], [Password], [RoleId], [StatusId], [Telephone])
VALUES (2, 3, CAST(N'2024-07-05T00:54:12.367' AS DATETIME), N'usuario2@gmail.com', N'Fax 2', N'Usuario 2', N'4a3f06ab818f057c3588be31d7216c773282fe809851a9493cbe5a072d4e169c', 1, 1, N'string');
INSERT INTO [dbo].[Employee] ([Id], [CompanyId], [CreatedOn], [Email], [Fax], [Name], [LastLogin], [Password], [RoleId], [StatusId], [Telephone])
VALUES (3, 3, CAST(N'2024-07-05T00:56:05.493' AS DATETIME), N'usuario3@gmail.com', N'string', N'Usuario 3', CAST(N'2024-07-05T10:31:20.903' AS DATETIME), N'4a3f06ab818f057c3588be31d7216c773282fe809851a9493cbe5a072d4e169c', 1, 1, N'string');
SET IDENTITY_INSERT [dbo].[Employee] OFF;
GO

-- Insertar datos en Roles
SET IDENTITY_INSERT [dbo].[Roles] ON;
INSERT INTO [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Admin');
INSERT INTO [dbo].[Roles] ([Id], [Name]) VALUES (2, N'User');
INSERT INTO [dbo].[Roles] ([Id], [Name]) VALUES (3, N'Guest');
SET IDENTITY_INSERT [dbo].[Roles] OFF;
GO

-- Insertar datos en Status
SET IDENTITY_INSERT [dbo].[Status] ON;
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (1, N'Active');
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (2, N'Inactive');
INSERT INTO [dbo].[Status] ([Id], [Name]) VALUES (3, N'Pending');
SET IDENTITY_INSERT [dbo].[Status] OFF;
GO

-- Configurar claves foráneas
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT FK_Users_Companies FOREIGN KEY([CompanyId]) REFERENCES [dbo].[Companies]([Id]);
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT FK_Users_Roles FOREIGN KEY([RoleId]) REFERENCES [dbo].[Roles]([Id]);
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT FK_Users_Status FOREIGN KEY([StatusId]) REFERENCES [dbo].[Status]([Id]);
GO

-- Configurar base de datos
ALTER DATABASE [PruebaRebardorTest] SET READ_WRITE;
GO
