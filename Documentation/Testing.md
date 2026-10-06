# Testing Strategy

## Functional Tests
The test suite covers registration, duplicate emails, login, logout, menu search, category filtering, cart changes, checkout, order persistence, reservations, admin authorization, CRUD, and status updates.

## Validation Tests
Test empty required fields, invalid email, duplicate email, weak passwords, invalid dates and times, guest count boundaries, and mismatched passwords.

## Integration Tests
Run the SQL script and verify that the application can read menu records, create users, insert orders and order items, and insert reservations.

## Security Tests
Attempt direct access to all Admin pages as a customer. Confirm that no password values are displayed and that session values are cleared after logout.

## Manual Test Cases
See Testing/TestCases.md for IDs, module, input, expected result, actual result, and status.
