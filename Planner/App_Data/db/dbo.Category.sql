CREATE TABLE [dbo].[Category] (
    [ID] INT   NOT NULL,
    [Name]       VARCHAR (100)  NOT NULL,
    [Notes]      VARCHAR (MAX) NOT NULL,
    [CreationTime] BIGINT NOT NULL, 
    [StorageTime] BIGINT NULL, 
    [CreatedBy] NCHAR(10) NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

