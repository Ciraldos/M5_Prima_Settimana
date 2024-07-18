﻿CREATE TABLE [dbo].Users
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Username NVARCHAR(20) NOT NULL UNIQUE,
	Password NVARCHAR(128) NOT NULL
)
CREATE TABLE [dbo].Roles
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL UNIQUE
)
CREATE TABLE [dbo].UsersRoles
(
	UserId INT NOT NULL,
	RoleId INT NOT NULL, 
    CONSTRAINT [PK_UserRoles] 
		PRIMARY KEY ([UserId], [RoleId])
)
