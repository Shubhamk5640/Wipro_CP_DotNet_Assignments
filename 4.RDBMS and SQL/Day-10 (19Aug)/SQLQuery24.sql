
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(255),
    Age INT,
    Department VARCHAR(255)
);


INSERT INTO Employees (EmployeeID, Name, Age, Department)
VALUES
(1, 'Shubham kumbhar', 30, 'Sales'),
(2, 'Sanket Mane', 25, 'Marketing'),
(3, 'Pankaj Sarnobat', 40, 'IT'),
(4, 'Sudhansh Bidkar', 35, 'HR'),
(5, 'Sangram Patil', 28, 'Finance');

CREATE INDEX idx_Department ON Employees (Department);


-- Query without index
SELECT * FROM Employees WHERE Department = 'Sales';

-- Query with index
SELECT * FROM Employees WHERE Department = 'Sales';


DROP INDEX idx_Department ON Employees;





















-- Create a new database user with a password
CREATE LOGIN LibraryUser WITH PASSWORD = 'Shubham@123';


-- Create a user in the current database for the login
CREATE USER LibraryUser FOR LOGIN LibraryUser;



-- Grant SELECT, INSERT, and UPDATE privileges on the Books table to LibraryUser
GRANT SELECT, INSERT, UPDATE ON Books TO LibraryUser;



-- Revoke the UPDATE privilege on the Books table from LibraryUser
REVOKE UPDATE ON Books FROM LibraryUser;



-- Drop the user from the database
DROP USER LibraryUser;


-- Drop the login from the server
DROP LOGIN LibraryUser;





use LibraryDB;

create table Customers (
Customer_ID int primary key identity(1,1),
Customer_Name varchar(100) not null,
Email varchar(100) not null,
City varchar(100) not null
);

insert into Customers (Customer_Name, Email, City)
values
('Shubham Kumbhar', 'shubham123@gmail.com','Karad'),
('Sanket Mane', 'sanket123@gmail.com', 'Pune'),
('Pankaj Sarnobat', 'pankaj123@gmail.com', 'Mumbai'),
('Sudhansh Bidkar', 'sudhansh123@gmail.com', 'Kolhapur');







Select * from customers;


select Customer_Name, Email 
from Customers
where City = 'Pune';



CREATE TABLE Orders (
    Order_ID INT PRIMARY KEY IDENTITY(1,1),
    Order_Date DATE NOT NULL,
    Customer_ID INT,  -- Foreign key to customers table
    Amount DECIMAL(10, 2) NOT NULL,
    Region VARCHAR(100) NOT NULL,
    FOREIGN KEY (Customer_ID) REFERENCES Customers(Customer_ID)
);

INSERT INTO orders (Order_Date, Customer_ID, Amount, Region)
VALUES 
('2024-08-01', 1, 150.50, 'East'),
('2024-08-02', 2, 250.75, 'West'),
('2024-08-03', 3, 100.00, 'Midwest'),
('2024-08-04', 1, 300.00, 'East'),
('2024-08-05', 4, 200.00, 'South');


SELECT 
    C.Customer_Name, 
    C.Email, 
    O.Order_ID, 
    O.Order_Date, 
    O.Amount
FROM 
    Customers C
INNER JOIN 
    Orders O ON C.Customer_ID = O.Customer_ID
WHERE 
    O.Region = 'East';  -- Specify the region


SELECT 
    C.Customer_Name, 
    C.Email, 
    O.Order_ID, 
    O.Order_Date, 
    O.Amount
FROM 
    Customers C
LEFT JOIN 
    Orders O ON C.Customer_ID = O.Customer_ID;






-- Add OrderValue column to the orders table
ALTER TABLE orders
ADD OrderValue DECIMAL(10, 2);  -- Adjust the size and scale as per your requirement

select * from Orders;

-- Update orders table with sample order values
UPDATE Orders
SET OrderValue = 100.00
WHERE Order_ID = 1;

UPDATE orders
SET OrderValue = 150.50
WHERE Order_ID = 2;

UPDATE orders
SET OrderValue = 75.25
WHERE Order_ID = 3;















-- Find customers who have placed orders above the average order value
SELECT DISTINCT C.Customer_ID, C.Customer_Name, C.Email
FROM Customers C
INNER JOIN Orders O ON C.Customer_ID = O.Customer_ID
WHERE O.OrderValue > (
    SELECT AVG(OrderValue)
    FROM orders
);






select * from Customers;

-- Combine two SELECT statements with the same number of columns using UNION
SELECT Customer_ID, Customer_Name, Email
FROM customers
WHERE City = 'Karad'

UNION

SELECT Customer_ID, Customer_Name, Email
FROM customers
WHERE City = 'Mumbai';









CREATE TABLE products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(100),
    Price DECIMAL(10, 2),
    StockQuantity INT
);

INSERT INTO products (ProductID, ProductName, Price, StockQuantity)
VALUES
(1, 'Laptop', 899.99, 50),
(2, 'Smartphone', 499.99, 150),
(3, 'Headphones', 79.99, 200),
(4, 'Keyboard', 29.99, 75),
(5, 'Mouse', 19.99, 100),
(6, 'Monitor', 199.99, 30); 

use LibraryDB;
create database Employee;
select * from products;
select * from Orders;
use SqlAssignment;
drop database SqlAssignment;
show tables;
-- Begin the transaction
BEGIN TRANSACTION;

-- Insert a new record into the 'orders' table
INSERT INTO Orders (Customer_ID, Order_Date, OrderValue)
VALUES (1,'2024-08-23',250.00);

-- Commit the transaction
COMMIT;

-- Update the 'products' table
UPDATE products
SET quantity = quantity - 1
WHERE product_id = 1;

-- Rollback the transaction (this will undo the update)
ROLLBACK;

CREATE TABLE Orderss (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_value DECIMAL(10, 2)
);

CREATE TABLE Productss (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    quantity INT,
    price DECIMAL(10, 2)
);

INSERT INTO Productss (product_id, product_name, quantity, price)
VALUES 
(1, 'Product A', 10, 15.00),
(2, 'Product B', 20, 25.00),
(3, 'Product C', 30, 35.00),
(4, 'Product D', 40, 45.00),
(5, 'Product E', 50, 55.00);

-- Begin the transaction
BEGIN TRANSACTION;

-- Insert a new record into the 'orders' table
INSERT INTO Orderss (customer_id, order_date, order_value)
VALUES (1, '2024-08-24', 250.00);

-- Commit the transaction to save the new order
COMMIT;

-- Begin a new transaction to update the 'products' table
BEGIN TRANSACTION;

-- Update the 'products' table
UPDATE products
SET quantity = quantity - 1
WHERE product_id = 1;

-- Rollback the transaction, undoing the update
ROLLBACK;







