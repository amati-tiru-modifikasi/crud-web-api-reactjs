-- latihan.dbo.Pegawai definition

-- Drop table

-- DROP TABLE latihan.dbo.Pegawai GO

CREATE TABLE latihan.dbo.Pegawai (
	Id varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	FirstName varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	LastName varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Mobile varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Email varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) GO;