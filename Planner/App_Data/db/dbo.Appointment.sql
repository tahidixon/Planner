CREATE TABLE [dbo].[Appointment] (
    [ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (30)  NOT NULL,
    [Notes]    VARCHAR (MAX) NOT NULL,
    [Category] VARCHAR (6)   NOT NULL,
    [Priority] TINYINT            NOT NULL,
    [StartTime]   BIGINT      NOT NULL,
    [EndTime]     BIGINT      NOT NULL,
	[CreationTime]  DATE          NOT NULL,
    [StorageTime] BIGINT NOT NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Appointment_Category] FOREIGN KEY ([Category]) REFERENCES [dbo].[Category] ([ID])
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Appointment ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Appointment',
    @level2type = N'COLUMN',
    @level2name = N'ID'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Appointment Name',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Appointment',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Appointment Notes',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Appointment',
    @level2type = N'COLUMN',
    @level2name = N'Notes'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Appointment Categories',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Appointment',
    @level2type = N'COLUMN',
    @level2name = N'Category'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Appointment Priority',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Appointment',
    @level2type = N'COLUMN',
    @level2name = N'Priority'