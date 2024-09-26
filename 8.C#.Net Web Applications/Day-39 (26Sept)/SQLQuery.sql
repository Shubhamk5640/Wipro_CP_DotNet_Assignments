create database Employeemanagement;

use EmployeeManagement;

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    MiddleName NVARCHAR(50),
    LastName NVARCHAR(50) NOT NULL,
    Salary DECIMAL(18,2) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Address NVARCHAR(200),
    Country NVARCHAR(50),
    Age INT,
    DateOfBirth DATE
);


select * from Employees;

