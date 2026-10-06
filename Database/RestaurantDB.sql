USE master;
GO
IF DB_ID(N'RestaurantDB') IS NOT NULL
    DROP DATABASE RestaurantDB;
GO
CREATE DATABASE RestaurantDB;
GO
USE RestaurantDB;
GO
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(20),
    Role NVARCHAR(20) NOT NULL DEFAULT 'Customer' CHECK (Role IN ('Customer','Admin')),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
GO
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(250)
);
GO
CREATE TABLE MenuItems (
    MenuItemId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryId INT NOT NULL,
    ItemName NVARCHAR(150) NOT NULL UNIQUE,
    Description NVARCHAR(500),
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    ImageUrl NVARCHAR(500),
    IsAvailable BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_MenuItems_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);
GO
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL CHECK (TotalAmount >= 0),
    Status NVARCHAR(30) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending','Confirmed','Preparing','Out for Delivery','Delivered','Cancelled')),
    DeliveryAddress NVARCHAR(500),
    CONSTRAINT FK_Orders_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO
CREATE TABLE OrderItems (
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    MenuItemId INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    UnitPrice DECIMAL(10,2) NOT NULL CHECK (UnitPrice >= 0),
    Subtotal DECIMAL(10,2) NOT NULL CHECK (Subtotal >= 0),
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
    CONSTRAINT FK_OrderItems_MenuItems FOREIGN KEY (MenuItemId) REFERENCES MenuItems(MenuItemId)
);
GO
CREATE TABLE Reservations (
    ReservationId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NULL,
    CustomerName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    ReservationDate DATE NOT NULL,
    ReservationTime TIME NOT NULL,
    NumberOfGuests INT NOT NULL CHECK (NumberOfGuests BETWEEN 1 AND 20),
    SpecialRequest NVARCHAR(500),
    Status NVARCHAR(30) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending','Confirmed','Completed','Cancelled')),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Reservations_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
GO
CREATE INDEX IX_MenuItems_CategoryId ON MenuItems(CategoryId);
CREATE INDEX IX_Orders_UserId ON Orders(UserId);
CREATE INDEX IX_OrderItems_OrderId ON OrderItems(OrderId);
CREATE INDEX IX_Reservations_ReservationDate ON Reservations(ReservationDate);
GO
INSERT INTO Users (FullName, Email, PasswordHash, Phone, Role) VALUES
('Development Admin', 'admin@spicegarden.local', '6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=', '+91 00000 00000', 'Admin'),
('Development Customer', 'customer@spicegarden.local', 'mOxlSo3yj48PjwIiBIPUaRa4UBfeC3TY7HVcKMuFOag=', '+91 00000 00000', 'Customer');
GO
INSERT INTO Categories (CategoryName, Description) VALUES
('Starters','Small plates and appetizers'),('Main Course','Traditional main dishes'),('Biryani','Fragrant rice preparations'),('Breads','Tandoor breads'),('Desserts','Sweet endings'),('Beverages','Refreshing drinks');
GO
INSERT INTO MenuItems (CategoryId, ItemName, Description, Price, ImageUrl, IsAvailable) VALUES
(1,'Paneer Tikka','Char grilled cottage cheese with spices', 480.00,'https://images.unsplash.com/photo-1567188040759-fb0d445b2e5b?auto=format&fit=crop&w=700&q=80',1),
(1,'Chicken Tikka','Tandoori chicken marinated with yogurt', 620.00,'https://images.unsplash.com/photo-1599487488170-d11ec9c172f0?auto=format&fit=crop&w=700&q=80',1),
(2,'Butter Chicken','Tomato butter sauce chicken', 690.00,'https://images.unsplash.com/photo-1603894584373-5ac82b2ae398?auto=format&fit=crop&w=700&q=80',1),
(2,'Paneer Butter Masala','Cottage cheese in a creamy tomato sauce', 580.00,'https://images.unsplash.com/photo-1565557623262-b51c251560ff?auto=format&fit=crop&w=700&q=80',1),
(3,'Veg Biryani','Fragrant basmati rice with vegetables', 520.00,'https://images.unsplash.com/photo-1589302168068-964664d9517f?auto=format&fit=crop&w=700&q=80',1),
(3,'Chicken Biryani','Fragrant basmati rice with spiced chicken', 650.00,'https://images.unsplash.com/photo-1563379926898-05f4575a45d8?auto=format&fit=crop&w=700&q=80',1),
(4,'Garlic Naan','Tandoor baked garlic bread', 80.00,'https://images.unsplash.com/photo-1601050690599-df0568f70950?auto=format&fit=crop&w=700&q=80',1),
(4,'Tandoori Roti','Whole wheat flatbread', 35.00,'https://images.unsplash.com/photo-1585937421612-70a008356fbe?auto=format&fit=crop&w=700&q=80',1),
(5,'Gulab Jamun','Warm milk dumplings in rose syrup', 180.00,'https://images.unsplash.com/photo-1578985545062-69928b1d9587?auto=format&fit=crop&w=700&q=80',1),
(5,'Mango Lassi','Sweet mango and yogurt drink', 220.00,'https://images.unsplash.com/photo-1626201320195-4e1f8f8f8d3b?auto=format&fit=crop&w=700&q=80',1),
(6,'Masala Chaas','Spiced buttermilk drink', 120.00,'https://images.unsplash.com/photo-1626201320195-4e1f8f8f8d3b?auto=format&fit=crop&w=700&q=80',1),
(6,'Fresh Lime Soda','Lime, soda and mint', 150.00,'https://images.unsplash.com/photo-1544145945-f90425350222?auto=format&fit=crop&w=700&q=80',1);
GO
