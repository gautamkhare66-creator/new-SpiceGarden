# Software Development Life Cycle

## Requirement Analysis
The system requires customer registration, secure login, menu discovery, cart ordering, checkout, reservation, administration, validation, reporting, and SQL Server persistence.

## Design
The application is divided into Presentation, Business Logic, and Data Access layers. The master page provides shared navigation and session display. SQL Server tables and relationships provide the persistent design.

## Implementation
ASP.NET Web Forms pages use controls and validation. BLL classes enforce business rules. DAL classes use parameterized ADO.NET queries. The database script creates the schema and development sample data.

## Testing
Testing/TestCases.md contains the complete functional test case list. Tests should cover customer workflows, admin workflows, validation, cart, orders, reservations, and authorization.

## Deployment
Deploy the compiled .NET Framework 4.8 application to IIS or IIS Express. Configure RestaurantDBConnection for the target SQL Server. Run the database script before the first application request.

## Maintenance
Regularly review database permissions, connection strings, application logs, order and reservation statuses, category and menu availability, and security policy. Replace development credentials before any shared deployment.
