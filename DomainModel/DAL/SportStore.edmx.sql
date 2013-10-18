
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/18/2013 16:52:19
-- Generated from EDMX file: F:\Projects\SportStore\DomainModel\DAL\SportStore.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SportStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProductCartLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CartLines] DROP CONSTRAINT [FK_ProductCartLine];
GO
IF OBJECT_ID(N'[dbo].[FK_CartCartLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CartLines] DROP CONSTRAINT [FK_CartCartLine];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Carts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Carts];
GO
IF OBJECT_ID(N'[dbo].[CartLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CartLines];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [Category] nvarchar(50)  NOT NULL,
    [Price] decimal(16,2)  NOT NULL
);
GO

-- Creating table 'Carts'
CREATE TABLE [dbo].[Carts] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'CartLines'
CREATE TABLE [dbo].[CartLines] (
    [Quantity] int  NOT NULL,
    [Id] nvarchar(max)  NOT NULL,
    [ProductId] int  NOT NULL,
    [CartId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [PK_Carts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CartLines'
ALTER TABLE [dbo].[CartLines]
ADD CONSTRAINT [PK_CartLines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProductId] in table 'CartLines'
ALTER TABLE [dbo].[CartLines]
ADD CONSTRAINT [FK_ProductCartLine]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCartLine'
CREATE INDEX [IX_FK_ProductCartLine]
ON [dbo].[CartLines]
    ([ProductId]);
GO

-- Creating foreign key on [CartId] in table 'CartLines'
ALTER TABLE [dbo].[CartLines]
ADD CONSTRAINT [FK_CartCartLine]
    FOREIGN KEY ([CartId])
    REFERENCES [dbo].[Carts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CartCartLine'
CREATE INDEX [IX_FK_CartCartLine]
ON [dbo].[CartLines]
    ([CartId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------