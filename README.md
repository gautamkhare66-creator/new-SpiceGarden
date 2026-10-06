# SpiceGarden – Online Restaurant Ordering and Reservation System

## Project Title
SpiceGarden – Online Restaurant Ordering and Reservation System

## Problem Statement
The application provides a database-driven restaurant ordering and reservation experience for students. It demonstrates presentation, business logic, and data access separated into clear layers using classic ASP.NET Web Forms, C#, ADO.NET, and SQL Server.

## Introduction
SpiceGarden is a college mini-project for a B.Sc. Computer Science assignment. It is a real database-driven Web Forms application rather than a static website.

## Objectives
- Build a responsive restaurant ordering and reservation system.
- Demonstrate three-tier architecture.
- Use parameterized ADO.NET queries against Microsoft SQL Server.
- Implement session-based authentication and admin authorization.
- Support customer and administrator workflows.

## Users
- Customer: places orders and reserves tables.
- Admin: manages users, categories, menu items, orders, and reservations.

## Technology Stack
- C# with .NET Framework 4.8
- ASP.NET Web Forms
- ADO.NET and System.Data.SqlClient
- Microsoft SQL Server
- Bootstrap 5 via CDN
- Visual Studio 2022 and IIS Express

## System Requirements
- Windows 10/11 64-bit
- Visual Studio 2022 with ASP.NET and web development workload
- .NET Framework 4.8 Developer Pack
- SQL Server 2019+ or SQL Server Express
- SQL Server Management Studio
- IIS Express or IIS

## Three-Tier Architecture
- Presentation Layer: ASPX pages, master page, validation, session handling.
- Business Logic Layer: business validation and orchestration.
- Data Access Layer: parameterized SQL using ADO.NET.
- SQL Server: authoritative data store.

## Database Setup
1. Open SSMS and run Database/RestaurantDB.sql.
2. Ensure the connection string in Web.config points to the local SQL Server instance.
3. For Windows authentication, the current Windows account must have permission to create the database and access RestaurantDB.

## Development Credentials
- Admin: admin@spicegarden.local / Admin@123
- Customer sample: customer@spicegarden.local / Customer@123

These credentials are seeded by the SQL script only for local development. Do not use them in production.

## Visual Studio Setup
1. Clone this repository into a local folder.
2. Open SpiceGardenWebForms.sln in Visual Studio 2022.
3. Install the ASP.NET and web development workload and .NET Framework 4.8 targeting pack.
4. Run Database/RestaurantDB.sql in SSMS.
5. Update the RestaurantDBConnection connection string if the local SQL Server instance differs.
6. Build the solution and run with IIS Express.

## Testing
See Testing/TestCases.md and Documentation/Testing.md.

## Deployment
Deploy the project to IIS after configuring a dedicated SQL Server connection string. Keep the application in the same namespace and preserve the Web.config connection setting.
