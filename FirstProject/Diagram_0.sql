/*
   Monday, September 4, 201712:31:45 AM
   User: lmoore0621
   Server: leonrevaturedb.database.windows.net
   Database: SchedularDb
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Days SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Days', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Days', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Days', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.TimeSlot ADD CONSTRAINT
	FK_TimeSlot_Days FOREIGN KEY
	(
	DaysId
	) REFERENCES dbo.Days
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TimeSlot SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.TimeSlot', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.TimeSlot', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.TimeSlot', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.Location_courses.LocationId', N'Tmp_Id_3', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Location_courses.Tmp_Id_3', N'Id', 'COLUMN' 
GO
ALTER TABLE dbo.Location_courses SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Location_courses', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Location_courses', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Location_courses', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.Courses.CourseId', N'Tmp_Id_4', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Courses.Tmp_Id_4', N'Id', 'COLUMN' 
GO
ALTER TABLE dbo.Courses ADD CONSTRAINT
	PK_Courses PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Courses ADD CONSTRAINT
	FK_Courses_Location_courses FOREIGN KEY
	(
	LocationId
	) REFERENCES dbo.Location_courses
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Courses ADD CONSTRAINT
	FK_Courses_TimeSlot FOREIGN KEY
	(
	TimeSlotId
	) REFERENCES dbo.TimeSlot
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Courses SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Courses', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Courses', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Courses', 'Object', 'CONTROL') as Contr_Per 