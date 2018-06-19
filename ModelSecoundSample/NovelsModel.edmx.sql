
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/03/2018 11:15:49
-- Generated from EDMX file: C:\Users\SDE-03062\source\repos\ModelFirstSample\ModelSecoundSample\NovelsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Model.Novels];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Novels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Novels];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Novels'
CREATE TABLE [dbo].[Novels] (
    [NovelId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Chapter] int  NULL,
    [Genre] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [NovelId] in table 'Novels'
ALTER TABLE [dbo].[Novels]
ADD CONSTRAINT [PK_Novels]
    PRIMARY KEY CLUSTERED ([NovelId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------