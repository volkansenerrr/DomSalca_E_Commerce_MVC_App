CREATE DATABASE DomSalca_DB
GO
USE DomSalca_DB
GO
CREATE TABLE Tbl_Category(
CategoryID INT IDENTITY PRIMARY KEY,
CategoryName NVARCHAR(250) UNIQUE,
IsActive BIT null,
IsDelete BIT null
)

CREATE TABLE Tbl_Product(
ProductID INT IDENTITY PRIMARY KEY,
ProductName NVARCHAR(250) UNIQUE,
CategoryID INT,
IsActive BIT null,
IsDelete BIT null,
CreatedDate DATETIME null,
ModifiedDate DATETIME null,
Description NVARCHAR(MAX) null,
ProductImage NVARCHAR(max),
IsFeatured BIT null,
Quantity INT,
FOREIGN KEY(CategoryID) REFERENCES Tbl_Category(CategoryID)
)

CREATE TABLE Tbl_CartStatus(
CartStatusID INT IDENTITY PRIMARY KEY,
CartStatus NVARCHAR(500)
)

CREATE TABLE Tbl_Members(
MemberID INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(200),
LastName NVARCHAR(200) UNIQUE,
EmailID  NVARCHAR(200) UNIQUE,
Password NVARCHAR (500),
IsActive BIT null,
IsDelete BIT null,
CreateOn DATETIME,
ModifiedOn DATETIME
)

CREATE TABLE Tbl_ShippingDetails(
  ShippingDetailID INT IDENTITY PRIMARY KEY,
  MemberID INT,
  Adress NVARCHAR(500),
  City NVARCHAR(500),
  State NVARCHAR(500),
  Country NVARCHAR(50),
  ZipCode NVARCHAR(50),
  OrderID INT,
  AmountPaid DECIMAL,
  PaymentType NVARCHAR(50),
  FOREIGN KEY (MemberID) REFERENCES Tbl_Members(MemberID)
)

CREATE TABLE Tbl_Roles(
RoleID INT IDENTITY PRIMARY KEY,
RoleName NVARCHAR(200) UNIQUE 
)

CREATE TABLE Tbl_Cart(
CartID INT IDENTITY PRIMARY KEY,
ProductID INT,
MemberID INT,
CartStatusID INT,
FOREIGN KEY (ProductID) REFERENCES Tbl_Product(ProductID) 
)

CREATE TABLE Tbl_MemberRole(
MemberRoleID INT IDENTITY PRIMARY KEY,
MemberID INT,
RoleID INT
)

CREATE TABLE Tbl_SlideImage(
SlideID INT IDENTITY PRIMARY KEY,
SlideTitle NVARCHAR(500),
SlideImage NVARCHAR(MAX)
)