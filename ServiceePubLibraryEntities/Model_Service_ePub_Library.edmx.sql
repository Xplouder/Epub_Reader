
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/09/2015 13:35:44
-- Generated from EDMX file: D:\EI_1sem\IS\Projeto\Rep_Novo\trunk\Código\IS_ePubIntegrator_1415\ServiceePubLibraryEntities\Model_Service_ePub_Library.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db_service_epub_library];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ChapterChapterBookmark]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChapterBookmark] DROP CONSTRAINT [FK_ChapterChapterBookmark];
GO
IF OBJECT_ID(N'[dbo].[FK_ChapterChapterFav]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChapterFav] DROP CONSTRAINT [FK_ChapterChapterFav];
GO
IF OBJECT_ID(N'[dbo].[FK_EpubChapter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Chapter] DROP CONSTRAINT [FK_EpubChapter];
GO
IF OBJECT_ID(N'[dbo].[FK_EpubEpubBookmark]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EpubBookmark] DROP CONSTRAINT [FK_EpubEpubBookmark];
GO
IF OBJECT_ID(N'[dbo].[FK_EpubEpubFav]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EpubFav] DROP CONSTRAINT [FK_EpubEpubFav];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChapterBookmark]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChapterBookmark] DROP CONSTRAINT [FK_UserChapterBookmark];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChapterFav]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChapterFav] DROP CONSTRAINT [FK_UserChapterFav];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEpubBookmark]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EpubBookmark] DROP CONSTRAINT [FK_UserEpubBookmark];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEpubFav]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EpubFav] DROP CONSTRAINT [FK_UserEpubFav];
GO
IF OBJECT_ID(N'[dbo].[FK_UserLoginHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoginHistory] DROP CONSTRAINT [FK_UserLoginHistory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Chapter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Chapter];
GO
IF OBJECT_ID(N'[dbo].[ChapterBookmark]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChapterBookmark];
GO
IF OBJECT_ID(N'[dbo].[ChapterFav]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChapterFav];
GO
IF OBJECT_ID(N'[dbo].[Epub]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Epub];
GO
IF OBJECT_ID(N'[dbo].[EpubBookmark]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EpubBookmark];
GO
IF OBJECT_ID(N'[dbo].[EpubFav]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EpubFav];
GO
IF OBJECT_ID(N'[dbo].[LoginHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoginHistory];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(15)  NOT NULL,
    [Password] nvarchar(60)  NOT NULL,
    [Email] nvarchar(30)  NOT NULL,
    [Birthdate] datetime  NOT NULL,
    [Salt] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'Chapter'
CREATE TABLE [dbo].[Chapter] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Epub_Id] int  NOT NULL,
    [Title] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'ChapterBookmark'
CREATE TABLE [dbo].[ChapterBookmark] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Chapter_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'ChapterFav'
CREATE TABLE [dbo].[ChapterFav] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Chapter_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Epub'
CREATE TABLE [dbo].[Epub] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [Author] nvarchar(100)  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EpubBookmark'
CREATE TABLE [dbo].[EpubBookmark] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Epub_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'EpubFav'
CREATE TABLE [dbo].[EpubFav] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Epub_Id] int  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'LoginHistory'
CREATE TABLE [dbo].[LoginHistory] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateLogin] datetime  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Chapter'
ALTER TABLE [dbo].[Chapter]
ADD CONSTRAINT [PK_Chapter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChapterBookmark'
ALTER TABLE [dbo].[ChapterBookmark]
ADD CONSTRAINT [PK_ChapterBookmark]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ChapterFav'
ALTER TABLE [dbo].[ChapterFav]
ADD CONSTRAINT [PK_ChapterFav]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Epub'
ALTER TABLE [dbo].[Epub]
ADD CONSTRAINT [PK_Epub]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EpubBookmark'
ALTER TABLE [dbo].[EpubBookmark]
ADD CONSTRAINT [PK_EpubBookmark]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EpubFav'
ALTER TABLE [dbo].[EpubFav]
ADD CONSTRAINT [PK_EpubFav]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LoginHistory'
ALTER TABLE [dbo].[LoginHistory]
ADD CONSTRAINT [PK_LoginHistory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Chapter_Id] in table 'ChapterBookmark'
ALTER TABLE [dbo].[ChapterBookmark]
ADD CONSTRAINT [FK_ChapterChapterBookmark]
    FOREIGN KEY ([Chapter_Id])
    REFERENCES [dbo].[Chapter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChapterChapterBookmark'
CREATE INDEX [IX_FK_ChapterChapterBookmark]
ON [dbo].[ChapterBookmark]
    ([Chapter_Id]);
GO

-- Creating foreign key on [Chapter_Id] in table 'ChapterFav'
ALTER TABLE [dbo].[ChapterFav]
ADD CONSTRAINT [FK_ChapterChapterFav]
    FOREIGN KEY ([Chapter_Id])
    REFERENCES [dbo].[Chapter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChapterChapterFav'
CREATE INDEX [IX_FK_ChapterChapterFav]
ON [dbo].[ChapterFav]
    ([Chapter_Id]);
GO

-- Creating foreign key on [Epub_Id] in table 'Chapter'
ALTER TABLE [dbo].[Chapter]
ADD CONSTRAINT [FK_EpubChapter]
    FOREIGN KEY ([Epub_Id])
    REFERENCES [dbo].[Epub]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EpubChapter'
CREATE INDEX [IX_FK_EpubChapter]
ON [dbo].[Chapter]
    ([Epub_Id]);
GO

-- Creating foreign key on [User_Id] in table 'ChapterBookmark'
ALTER TABLE [dbo].[ChapterBookmark]
ADD CONSTRAINT [FK_UserChapterBookmark]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserChapterBookmark'
CREATE INDEX [IX_FK_UserChapterBookmark]
ON [dbo].[ChapterBookmark]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'ChapterFav'
ALTER TABLE [dbo].[ChapterFav]
ADD CONSTRAINT [FK_UserChapterFav]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserChapterFav'
CREATE INDEX [IX_FK_UserChapterFav]
ON [dbo].[ChapterFav]
    ([User_Id]);
GO

-- Creating foreign key on [Epub_Id] in table 'EpubBookmark'
ALTER TABLE [dbo].[EpubBookmark]
ADD CONSTRAINT [FK_EpubEpubBookmark]
    FOREIGN KEY ([Epub_Id])
    REFERENCES [dbo].[Epub]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EpubEpubBookmark'
CREATE INDEX [IX_FK_EpubEpubBookmark]
ON [dbo].[EpubBookmark]
    ([Epub_Id]);
GO

-- Creating foreign key on [Epub_Id] in table 'EpubFav'
ALTER TABLE [dbo].[EpubFav]
ADD CONSTRAINT [FK_EpubEpubFav]
    FOREIGN KEY ([Epub_Id])
    REFERENCES [dbo].[Epub]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EpubEpubFav'
CREATE INDEX [IX_FK_EpubEpubFav]
ON [dbo].[EpubFav]
    ([Epub_Id]);
GO

-- Creating foreign key on [User_Id] in table 'EpubBookmark'
ALTER TABLE [dbo].[EpubBookmark]
ADD CONSTRAINT [FK_UserEpubBookmark]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEpubBookmark'
CREATE INDEX [IX_FK_UserEpubBookmark]
ON [dbo].[EpubBookmark]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'EpubFav'
ALTER TABLE [dbo].[EpubFav]
ADD CONSTRAINT [FK_UserEpubFav]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEpubFav'
CREATE INDEX [IX_FK_UserEpubFav]
ON [dbo].[EpubFav]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'LoginHistory'
ALTER TABLE [dbo].[LoginHistory]
ADD CONSTRAINT [FK_UserLoginHistory]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLoginHistory'
CREATE INDEX [IX_FK_UserLoginHistory]
ON [dbo].[LoginHistory]
    ([User_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([Id], [Username], [Password], [Email], [Birthdate], [Salt]) VALUES (1, N'teste', N'5yHmsMHocNAfAOMThh5lXIPCMKg=', N'teste@teste.pt', N'2004-06-17 00:00:00', N'mQ/O9TDrCUZuJNs=')
INSERT INTO [dbo].[User] ([Id], [Username], [Password], [Email], [Birthdate], [Salt]) VALUES (2, N'admin', N'ouyya09LbeOHbES9hzMOFycr4WQ=', N'admin@admin.pt', N'2004-12-11 00:00:00', N'0SJa0s+82WddgUWwZQV1CoQ=')
SET IDENTITY_INSERT [dbo].[User] OFF

CREATE UNIQUE INDEX [index_unique_email]
ON [dbo].[User] ([Email])

CREATE UNIQUE INDEX [index_unique_epub]
ON [dbo].[Epub] ([Title],[Author])

CREATE UNIQUE INDEX [index_unique_chapter]
ON [dbo].[Chapter] ([Epub_Id],[Title])

CREATE UNIQUE INDEX [index_unique_epubFav]
ON [dbo].[EpubFav] ([Epub_Id],[User_Id])

CREATE UNIQUE INDEX [index_unique_epubBookmark]
ON [dbo].[EpubBookmark] ([Epub_Id],[User_Id])

CREATE UNIQUE INDEX [index_unique_ChapterFav]
ON [dbo].[ChapterFav] ([Chapter_Id],[User_Id])

CREATE UNIQUE INDEX [index_unique_ChapterBookmark]
ON [dbo].[ChapterBookmark] ([Chapter_Id],[User_Id])