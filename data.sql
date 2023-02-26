-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- latihan.dbo.Department definition

-- Drop table

-- DROP TABLE latihan.dbo.Department GO

CREATE TABLE latihan.dbo.Department (
	DepartmentId int IDENTITY(1,1) NOT NULL,
	DepartmentName nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) GO;


-- latihan.dbo.Employee definition

-- Drop table

-- DROP TABLE latihan.dbo.Employee GO

CREATE TABLE latihan.dbo.Employee (
	EmployeeId int IDENTITY(1,1) NOT NULL,
	EmployeeName nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Department nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	DateOfJoining datetime NULL,
	PhotoFileName nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) GO;;
