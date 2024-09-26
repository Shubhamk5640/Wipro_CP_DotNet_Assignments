
use EmployeeDB;

create table Employee(
EmployeeId INT PRIMARY KEY IDENTITY(1,1),
Name NVARCHAR(100),
Gender NVARCHAR(10),
Country NVARCHAR(50),
DateOfBirth DATE
);

select * from Employee;