# Database Design

## Users
UserId is the primary key. Email is unique. PasswordHash stores only the password hash. Role is restricted to Customer or Admin. The role and user information are used during login and authorization.

## Categories
CategoryId is the primary key. CategoryName provides a normalized menu grouping.

## MenuItems
MenuItemId is the primary key. CategoryId is a foreign key to Categories. The ItemName and price are used by the menu and cart. IsAvailable controls whether an item can be ordered.

## Orders
OrderId is the primary key. UserId is a foreign key to Users. TotalAmount is calculated by the BLL and persisted when checkout completes. Status defaults to Pending.

## OrderItems
OrderItemId is the primary key. OrderId and MenuItemId are foreign keys. Quantity, UnitPrice, and Subtotal preserve the order details. Deleting an order cascades to its items.

## Reservations
ReservationId is the primary key. UserId is optional for anonymous reservations. ReservationDate and ReservationTime identify the requested table slot. Status defaults to Pending.

## Relationships
Users 1-to-many Orders and Reservations. Categories 1-to-many MenuItems. Orders 1-to-many OrderItems. MenuItems many-to-one Categories.
