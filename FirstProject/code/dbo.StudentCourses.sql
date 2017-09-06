CREATE TABLE [dbo].[StudentCourses] (
    [StudentId] INT NOT NULL,
    [CourseId]  INT NOT NULL,
    CONSTRAINT [PK_StudentCourses] PRIMARY KEY CLUSTERED ([StudentId] ASC, [CourseId] ASC),
    CONSTRAINT [FK_StudentCourses_Members] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Members] ([Id]),
    CONSTRAINT [FK_StudentCourses_Courses] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Courses] ([Id])
);

