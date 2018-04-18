
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/16/2018 13:42:44
-- Generated from EDMX file: C:\Users\gnicot\Documents\Visual Studio 2013\Projects\ProjetFormation\ProjetFormation\Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjetFormation];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProjetLot]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lots] DROP CONSTRAINT [FK_ProjetLot];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetencePersonne]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personnes] DROP CONSTRAINT [FK_CompetencePersonne];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Projets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projets];
GO
IF OBJECT_ID(N'[dbo].[Lots]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lots];
GO
IF OBJECT_ID(N'[dbo].[Personnes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personnes];
GO
IF OBJECT_ID(N'[dbo].[Competences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Competences];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Projets'
CREATE TABLE [dbo].[Projets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NULL,
    [DateDebut] datetime  NULL,
    [DateFin] datetime  NULL
);
GO

-- Creating table 'Lots'
CREATE TABLE [dbo].[Lots] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjetId] int  NOT NULL
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

-- Creating table 'Competences'
CREATE TABLE [dbo].[Competences] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Libelle] nvarchar(max)  NOT NULL,
    [LibelleCourt] nvarchar(max)  NOT NULL,
    [Couleur] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Projets'
ALTER TABLE [dbo].[Projets]
ADD CONSTRAINT [PK_Projets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lots'
ALTER TABLE [dbo].[Lots]
ADD CONSTRAINT [PK_Lots]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personnes'
ALTER TABLE [dbo].[Personnes]
ADD CONSTRAINT [PK_Personnes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Competences'
ALTER TABLE [dbo].[Competences]
ADD CONSTRAINT [PK_Competences]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProjetId] in table 'Lots'
ALTER TABLE [dbo].[Lots]
ADD CONSTRAINT [FK_ProjetLot]
    FOREIGN KEY ([ProjetId])
    REFERENCES [dbo].[Projets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjetLot'
CREATE INDEX [IX_FK_ProjetLot]
ON [dbo].[Lots]
    ([ProjetId]);
GO

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