# Architecture

## Presentation Layer
ASP.NET Web Forms pages, controls, master page, session handling, validation, and GridView rendering. The pages call business logic and never access SQL directly.

## Business Logic Layer
The BLL contains validation, business rules, password hashing, cart calculations, and orchestration. It calls DAL methods and returns domain objects or status results to the presentation layer.

## Data Access Layer
The DAL uses DatabaseHelper with SqlConnection, SqlCommand, SqlParameter, SqlDataReader, and SqlDataAdapter. All SQL text is parameterized and located in the DAL or database script.

## SQL Server
The application configuration uses the RestaurantDBConnection setting. SQL Server is the authoritative persistent data store. The cart remains session-only and does not require a database table.

## Security Boundary
Passwords are hashed before insertion and compared by the BLL. Admin pages are guarded by session role checks. Database exceptions are converted into user-friendly error messages in the presentation layer.
