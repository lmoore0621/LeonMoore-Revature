/*
   Monday, September 4, 201712:29:40 AM
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
ALTER TABLE dbo.Title_position SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Title_position', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Title_position', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Title_position', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Member
	(
	Id int NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Title_Id int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Member SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.Member)
	 EXEC('INSERT INTO dbo.Tmp_Member (Id, FirstName, LastName, Title_Id)
		SELECT Id, FirstName, LastName, CONVERT(int, Title_Id) FROM dbo.Member WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Member
GO
EXECUTE sp_rename N'dbo.Tmp_Member', N'Member', 'OBJECT' 
GO
ALTER TABLE dbo.Member ADD CONSTRAINT
	PK_Member PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Member ADD CONSTRAINT
	FK_Member_Title_position FOREIGN KEY
	(
	Title_Id
	) REFERENCES dbo.Title_position
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Member', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Member', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Member', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Roster ADD CONSTRAINT
	FK_Roster_Member FOREIGN KEY
	(
	MemberId
	) REFERENCES dbo.Member
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Roster SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Roster', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Roster', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Roster', 'Object', 'CONTROL') as Contr_Per 