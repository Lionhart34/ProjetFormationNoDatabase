
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/16/2018 15:22:03
-- Generated from EDMX file: C:\Users\gnicot\Documents\Visual Studio 2013\Projects\ProjetFormationDebug\ProjetFormationDebug\Model\ModelDebug.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjetFormationDebug];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CompetencePersonne]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personnes] DROP CONSTRAINT [FK_CompetencePersonne];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Competences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Competences];
GO
IF OBJECT_ID(N'[dbo].[Personnes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personnes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Competences'
CREATE TABLE [dbo].[Competences] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] nvarchar(max)  NOT NULL,
    [LibelleCourt] nvarchar(max)  NOT NULL,
    [Couleur] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Personnes'
CREATE TABLE [dbo].[Personnes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NULL,
    [Prenom] nvarchar(max)  NULL,
    [CompetenceId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Competences'
ALTER TABLE [dbo].[Competences]
ADD CONSTRAINT [PK_Competences]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personnes'
ALTER TABLE [dbo].[Personnes]
ADD CONSTRAINT [PK_Personnes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CompetenceId] in table 'Personnes'
ALTER TABLE [dbo].[Personnes]
ADD CONSTRAINT [FK_CompetencePersonne]
    FOREIGN KEY ([CompetenceId])
    REFERENCES [dbo].[Competences]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetencePersonne'
CREATE INDEX [IX_FK_CompetencePersonne]
ON [dbo].[Personnes]
    ([CompetenceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------