CREATE DATABASE Inventory; 
-- Create Users table
-- Create Users table
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId VARCHAR(255),
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Password VARCHAR(255),
    Email VARCHAR(255),
    Age INT,
    Gender VARCHAR(10),
    Role VARCHAR(50),
    Salary DECIMAL(18, 2),
    JoinDate DATE,
    Birthdate DATE,
    NID VARCHAR(20),
    Phone VARCHAR(15),
    HomeTown VARCHAR(255),
    CurrentCity VARCHAR(255),
    Division VARCHAR(255),
    BloodGroup VARCHAR(5),
    PostalCode VARCHAR(10)
);

-- Create Orders table
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    OrderTag VARCHAR(50),
    Id INT,
    BarCodeId INT,
    Date DATE,
    ProductId INT,
    ProductName VARCHAR(255),
    ProductPerUnitPrice DECIMAL(18, 2),
    OrderQuantity INT,
    OrderStatus VARCHAR(50),
    PaymentMethod VARCHAR(50),
    TotalAmount DECIMAL(18, 2),
    CustomerFullName VARCHAR(255),
    CustomerPhone VARCHAR(15),
    CustomerEmail VARCHAR(255),
    CustomerAddress VARCHAR(255)
);

-- Create OrdersProductsMap table
CREATE TABLE OrdersProductsMap (
    OrderProductsCategoriesId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT,
    ProductId INT
);

-- Create ProCateMap table
CREATE TABLE ProCateMap (
    PCID INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT,
    ProductName VARCHAR(255),
    BrandId INT,
    BrandName VARCHAR(255),
    VendorId INT,
    VendorName VARCHAR(255),
    ThirdCategoryId INT,
    ThirdCategoryName VARCHAR(255),
    SecondCategoryId INT,
    SecondCategoryName VARCHAR(255),
    MainCategoryId INT,
    MainCategoryName VARCHAR(255)
);

-- Create Products table
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductIdTag VARCHAR(50),
    ProductName VARCHAR(255),
    BrandId INT,
    ProductDescription TEXT,
    ProductQuantityPerUnit VARCHAR(50),
    ProductPerUnitPrice DECIMAL(18, 2),
    ProductMSRP DECIMAL(18, 2),
    ProductStatus VARCHAR(50),
    ProductDiscountRate DECIMAL(5, 2),
    ProductSize VARCHAR(50),
    ProductColor VARCHAR(50),
    ProductWeight DECIMAL(10, 2),
    ProductUnitStock INT
);

-- Create Brands table
CREATE TABLE Brands (
    BrandId INT IDENTITY(1,1) PRIMARY KEY,
    BrandTag VARCHAR(50),
    BrandName VARCHAR(255),
    VendorId INT,
    BrandDescription TEXT,
    BrandStatus VARCHAR(50),
    BrandImage VARCHAR(MAX) -- Assuming it's an image URL or file path
);

-- Create Vendors table
CREATE TABLE Vendors (
    VendorId INT IDENTITY(1,1) PRIMARY KEY,
    VendorTag VARCHAR(50),
    VendorName VARCHAR(255),
    ThirdCategoryId INT,
    VendorDescription TEXT,
    VendorStatus VARCHAR(50),
    VendorImage VARCHAR(MAX), -- Assuming it's an image URL or file path
    RegisterDate DATE
);

-- Create Expenses table
CREATE TABLE Expenses (
    ExpenseId INT IDENTITY(1,1) PRIMARY KEY,
    ExpenseName VARCHAR(255),
    ExpenseAmount DECIMAL(18, 2),
    ExpenseDate DATE
);

-- Create BarCodes table
CREATE TABLE BarCodes (
    BarCodeId INT IDENTITY(1,1) PRIMARY KEY,
    BarCode VARCHAR(255)
);

-- Create MainCategories table
CREATE TABLE MainCategories (
    MainCategoryId INT IDENTITY(1,1) PRIMARY KEY,
    MainCategoryName VARCHAR(255),
    MainCategoryImage VARCHAR(MAX) -- Assuming it's an image URL or file path
);

-- Create ThirdCategories table
CREATE TABLE ThirdCategories (
    ThirdCategoryId INT IDENTITY(1,1) PRIMARY KEY,
    SecondCategoryId INT,
    ThirdCategoryName VARCHAR(255),
    ThirdCategoryImage VARCHAR(MAX) -- Assuming it's an image URL or file path
);

-- Create SecondCategories table
CREATE TABLE SecondCategories (
    SecondCategoryId INT IDENTITY(1,1) PRIMARY KEY,
    SecondCategoryName VARCHAR(255),
    SecondCategoryImage VARCHAR(MAX), -- Assuming it's an image URL or file path
    MainCategoryId INT
);


-- Insert Salesman
INSERT INTO Users (Id, UserId, FirstName, LastName, Password, Email, Age, Gender, Role, Salary, JoinDate, Birthdate, NID, Phone, HomeTown, CurrentCity, Division, BloodGroup, PostalCode)
VALUES 
    (1, 'salesman', 'John', 'Doe', 'salesman123', 'john.doe@example.com', 30, 'Male', 'Salesman', 30000.00, '2023-09-25', '1993-05-15', '123456789', '555-555-5555', 'Hometown', 'Current City', 'Division', 'O+', '12345');

-- Insert Cashier
INSERT INTO Users (Id, UserId, FirstName, LastName, Password, Email, Age, Gender, Role, Salary, JoinDate, Birthdate, NID, Phone, HomeTown, CurrentCity, Division, BloodGroup, PostalCode)
VALUES 
    (2, 'cashier', 'Jane', 'Doe', 'cashier123', 'jane.doe@example.com', 28, 'Female', 'Cashier', 32000.00, '2023-09-25', '1995-02-20', '987654321', '555-555-5556', 'Hometown', 'Current City', 'Division', 'A-', '54321');

-- Insert Admin
INSERT INTO Users (Id, UserId, FirstName, LastName, Password, Email, Age, Gender, Role, Salary, JoinDate, Birthdate, NID, Phone, HomeTown, CurrentCity, Division, BloodGroup, PostalCode)
VALUES 
    (3, 'admin', 'Admin', 'User', 'admin123', 'admin@example.com', 35, 'Non-Binary', 'Admin', 50000.00, '2023-09-25', '1988-10-10', '1010101010', '555-555-5557', 'Admin Town', 'Admin City', 'Admin Division', 'AB+', '00000');
