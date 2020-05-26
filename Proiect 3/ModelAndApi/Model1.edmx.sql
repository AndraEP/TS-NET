
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/16/2020 13:34:53
-- Generated from EDMX file: D:\An3\Sem2\TSP Net\Proiect\ModelAndApi\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProiectMedia];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Media'
CREATE TABLE [dbo].[Media] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [Moved] int  NOT NULL,
    [Evenimente] nvarchar(max)  NOT NULL,
    [Persoane] nvarchar(max)  NOT NULL,
    [Peisaje] nvarchar(max)  NOT NULL,
    [Locuri] nvarchar(max)  NOT NULL,
    [Altele] nvarchar(max)  NOT NULL,
    [DataCreare] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Media'
ALTER TABLE [dbo].[Media]
ADD CONSTRAINT [PK_Media]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------