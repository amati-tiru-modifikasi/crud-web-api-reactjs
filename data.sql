CREATE table dbo.Department(
DepartmentId int identity(1,1),
DepartmentName nvarchar(500)
);

CREATE table dbo.Employee(
EmployeeId int identity(1,1),
EmployeeName nvarchar(500),
Department nvarchar(500),
DateOfJoining datetime,
PhotoFileName nvarchar(500)
)

insert into dbo.Department values ('IT');
insert into dbo.Department values ('Supports');