create database DBFirstCrud;
use DBFirstCrud;

-- Create Department table
CREATE TABLE Department (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50)
);

-- Create Employee table
CREATE TABLE Employee (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50),
    Gender NVARCHAR(10),
    Age INT,
    Salary DECIMAL(18, 2),
    DeptId INT FOREIGN KEY REFERENCES Department(Id)
);


-- Insert Departments
INSERT INTO Department (Name) VALUES ('HR');
INSERT INTO Department (Name) VALUES ('IT');
INSERT INTO Department (Name) VALUES ('Finance');



ALTER TABLE Employee
ADD Email NVARCHAR(100);

select * from Employees;
select * from Departments;

use CodeFirstDB;






