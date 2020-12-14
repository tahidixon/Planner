CREATE TABLE [dbo].[Task] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (100)  NOT NULL,
    [Category] INT   NOT NULL,
    [Priority] INT   NOT NULL,
    [Notes]    VARCHAR (MAX) NOT NULL,
    [StartTime]   BIGINT      NOT NULL,
    [EndTime]     BIGINT      NOT NULL,
	[CreationUser] INT NOT NULL ,
	[CreationTime]BIGINT NOT NULL,
    [StorageTime] BIGINT NOT NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Task_Category] FOREIGN KEY ([Category]) REFERENCES [dbo].[Category] ([ID])
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'ID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task Name (Max 100 Characters)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task Category ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'Category'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task Priority in decimal',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'Priority'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task Notes',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'Notes'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task Start Time',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'StartTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task End Time',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'EndTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task Client Creation Time',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'CreationTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task Server Storage Time',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'StorageTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Task Creator User ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Task',
    @level2type = N'COLUMN',
    @level2name = N'CreationUser'