use Employee;

CREATE TABLE orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_value DECIMAL(10, 2)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(50),
    quantity INT,
    price DECIMAL(10, 2)
);

INSERT INTO products (product_id, product_name, quantity, price)
VALUES 
(1, 'Product A', 10, 15.00),
(2, 'Product B', 20, 25.00),
(3, 'Product C', 30, 35.00),
(4, 'Product D', 40, 45.00),
(5, 'Product E', 50, 55.00);


-- Begin the transaction
BEGIN TRANSACTION;

-- Insert a new record into the 'orders' table
INSERT INTO orders (customer_id, order_date, order_value)
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

select * from products;
select * from orders;

drop table products


drop database Employee

use Company
drop table

-- Create the 'orders' table
create TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_value DECIMAL(10, 2)
);

use Company;
create table orders (
order_id int primary key,
customer_id int,
order_date date,
order_value decimal(10,2)
);


-- Create the 'products' table
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    quantity INT,
    price DECIMAL(10, 2)
);

select * from orders
select * from products
DROP TABLE orders

drop table products







-- Begin the transaction
BEGIN TRANSACTION;

-- Insert a new record into the 'orders' table
INSERT INTO orders (order_id, customer_id, order_date)
VALUES (1, 1, '2024-08-23');

-- Set a SAVEPOINT
SAVE TRANSACTION savepoint1;

select * from orders;








-- Insert another new record into the 'orders' table
INSERT INTO orders (order_id, customer_id, order_date)
VALUES (2, 2, '2024-08-24');

-- Set another SAVEPOINT
SAVE TRANSACTION savepoint2;

select * from orders;







-- Insert another new record into the 'orders' table
INSERT INTO orders (order_id, customer_id, order_date)
VALUES (3, 3, '2024-08-25');

select * from orders;






-- Rollback to the second SAVEPOINT
ROLLBACK TRANSACTION savepoint2;

select * from orders;




-- COMMIT the overall transaction
COMMIT;

















CREATE LOGIN Library_user_shubham WITH PASSWORD = 'p@ssw0rd';

CREATE USER Library_user_shubham FOR LOGIN Library_user_shubham;

GRANT SELECT,INSERT,UPDATE ON SCHEMA:: dbo TO Library_user_shubham;

REVOKE UPDATE ON SCHEMA:: dbo FROM Library_user_shubham;


DROP USER Library_user_shubham; --dropping user from the database

DROP LOGIN Library_user_shubham; --dropping Login from the database












CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Author VARCHAR(255),
    Price DECIMAL(10, 2),
    Available INT
);


CREATE TABLE Members (
    MemberID INT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15),
    MembershipDate DATE NOT NULL,
    Address VARCHAR(255)
);


CREATE TABLE BorrowedBooks (
    BorrowID INT PRIMARY KEY,
    BookID INT,
    MemberID INT,
    BorrowDate DATE,
    DueDate DATE,
    ReturnDate DATE,
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)
);





--Insert Records into Books Table
INSERT INTO Books (BookID, Title, Author, Price, Available)
VALUES (1, 'The Great Gatsby', 'F. Scott Fitzgerald', 10.99, 5);

INSERT INTO Books (BookID, Title, Author, Price, Available)
VALUES (2, 'To Kill a Mockingbird', 'Harper Lee', 7.99, 3);

INSERT INTO Books (BookID, Title, Author, Price, Available)
VALUES (3, '1984', 'George Orwell', 8.99, 4);
INSERT INTO Books (BookID, Title, Author, Price, Available)
VALUES (4, 'Killer', 'John Orlands', 9.99, 5);
--Insert Records into Members Table
INSERT INTO Members (MemberID, Name, Email, PhoneNumber, MembershipDate, Address)
VALUES (1, 'John Doe', 'john.doe@example.com', '123-456-7890', '2024-01-15', '123 Main St, Cityville');

INSERT INTO Members (MemberID, Name, Email, PhoneNumber, MembershipDate, Address)
VALUES (2, 'Jane Smith', 'jane.smith@example.com', '234-567-8901', '2024-02-10', '456 Oak St, Townsville');

INSERT INTO Members (MemberID, Name, Email, PhoneNumber, MembershipDate, Address)
VALUES (3, 'Michael Johnson', 'michael.johnson@example.com', '345-678-9012', '2024-03-05', '789 Pine St, Villageville');
INSERT INTO Members (MemberID, Name, Email, PhoneNumber, MembershipDate, Address)
VALUES (4, 'Gorge Sandro', 'gorge.sandro@example.com', '435-768-9012', '2024-04-08', '143 spine St, Bargilins');
--Insert Records into BorrowedBooks Table
INSERT INTO BorrowedBooks (BorrowID, BookID, MemberID, BorrowDate, DueDate, ReturnDate)
VALUES (1, 1, 1, '2024-08-01', '2024-08-15', NULL);

INSERT INTO BorrowedBooks (BorrowID, BookID, MemberID, BorrowDate, DueDate, ReturnDate)
VALUES (2, 2, 2, '2024-08-05', '2024-08-20', NULL);

INSERT INTO BorrowedBooks (BorrowID, BookID, MemberID, BorrowDate, DueDate, ReturnDate)
VALUES (3, 3, 3, '2024-08-10', '2024-08-25', NULL);


select * from Books;
select * from Members;




-- Update the price of a book
UPDATE Books
SET Price = 12.99
WHERE BookID = 1;

-- Update the address of a member
UPDATE Members
SET Address = '321 New St, Townsville'
WHERE MemberID = 2;

select * from Books;
select * from Members;



-- Delete a book
DELETE FROM Books
WHERE BookID = 8;

-- Delete a member
DELETE FROM Members
WHERE MemberID = 4 ;

select * from Books;
select * from Members;




-- Example of BULK INSERT from a file 'books_data.csv' located in a specified directory
BULK INSERT Books
FROM 'C:\Users\Administrator\SQLBulkOperation\book_data.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2 -- Skipping the header row
);

select * from Books;























insert into Books(BookId, Title, Author, Price, Available)
values
(4, 'The Catcher in the Rye', 'J.D. Salinger', 11.99, 7),
(5, 'The Hobbit', 'J.R.R. Tolkien', 14.99, 6),
(6, 'Pride and Prejudice', 'Jane Austen', 9.99, 8),
(7, 'Moby Dick', 'Herman Melville', 13.5, 5),
(8, 'War and Peace', 'Leo Tolstoy', 20, 3);




EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;
EXEC sp_configure 'Ad Hoc Distributed Queries', 1;
RECONFIGURE;

