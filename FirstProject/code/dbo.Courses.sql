CREATE TABLE [dbo].[Courses] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [ProfessorId] INT           NULL,
    [Name]        NVARCHAR (75) NOT NULL,
    [CreditHours] INT           NOT NULL,
    [StartDate]   DATE          NOT NULL,
    [EndDate]     DATE          NOT NULL,
    [StartTime]   TIME (7)      NOT NULL,
    [Length]      INT           NOT NULL,
    [StudentCapacity] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Courses_Members] FOREIGN KEY ([ProfessorId]) REFERENCES [dbo].[Members] ([Id])
);

