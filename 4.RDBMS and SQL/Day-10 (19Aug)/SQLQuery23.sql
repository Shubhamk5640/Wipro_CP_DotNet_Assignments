-- Create the Authors table
CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL
);

-- Create the Books table
CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    Title VARCHAR(255) NOT NULL,
    ISBN VARCHAR(13) NOT NULL UNIQUE,  -- ISBN must be unique
    Publisher VARCHAR(255) NOT NULL,
    PublishedYear INT NOT NULL CHECK (PublishedYear >= 1800 AND PublishedYear <= YEAR(GETDATE())),  -- Year must be between 1800 and the current year
    AuthorID INT,  -- Foreign key to the Authors table
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)  -- Establishes the relationship with Authors
);

-- Create the Members table
CREATE TABLE Members (
    MemberID INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,  -- Email must be unique
    PhoneNumber VARCHAR(15) UNIQUE,  -- Phone number can be unique
    MembershipDate DATE NOT NULL
);

-- Create the Loans table
CREATE TABLE Loans (
    LoanID INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    BookID INT NOT NULL,  -- Foreign key to the Books table
    MemberID INT NOT NULL,  -- Foreign key to the Members table
    LoanDate DATE NOT NULL,
    DueDate DATE NOT NULL,  -- Due date must be after the loan date
    ReturnDate DATE,
    FOREIGN KEY (BookID) REFERENCES Books(BookID),  -- Establishes the relationship with Books
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID)  -- Establishes the relationship with Members
);

-- Create the Categories table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),  -- Auto-incrementing primary key
    CategoryName VARCHAR(100) NOT NULL UNIQUE  -- Category name must be unique
);

-- Create the BookCategories table (many-to-many relationship between Books and Categories)
CREATE TABLE BookCategories (
    BookID INT NOT NULL,  -- Foreign key to the Books table
    CategoryID INT NOT NULL,  -- Foreign key to the Categories table
    PRIMARY KEY (BookID, CategoryID),  -- Composite primary key
    FOREIGN KEY (BookID) REFERENCES Books(BookID),  -- Establishes the relationship with Books
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)  -- Establishes the relationship with Categories
);




-- Add a new column to the Books Table
ALTER table Books
add NumberOfPages int;

--Modify the Books table to make Publisher optional
ALTER table Books
ALTER column Publisher varchar(255) null;

--Drop the categories Table
drop table BookCategories;
