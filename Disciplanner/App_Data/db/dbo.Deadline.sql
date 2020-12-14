CREATE TABLE [dbo].[Deadline] (
    [ID] INT           NOT NULL,
    [Name]        VARCHAR (100)  NOT NULL,
    [Deadline]    BIGINT        NOT NULL,
    [Category]    INT           NOT NULL,
    [Notes]       VARCHAR (MAX) NOT NULL,
    [Priority]      INT         NOT NULL,
    [StartTime]     BIGINT      NOT NULL,
    [EndTime]       BIGINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Deadline_Category] FOREIGN KEY ([Category]) REFERENCES [dbo].[Category] ([ID])
);

