# Testing Test Cases

| Test Case ID | Module | Input | Expected Result | Actual Result | Status |
|---|---|---|---|---|---|
| TC01 | Registration | Valid name, valid email, phone, password and confirmation | Account created and user signed in |  | Not run |
| TC02 | Registration | Missing required fields | Validation errors and no record |  | Not run |
| TC03 | Registration | Existing email | Duplicate-email error |  | Not run |
| TC04 | Registration | Invalid email format | Validation error |  | Not run |
| TC05 | Login | Valid admin credentials | Admin dashboard |  | Not run |
| TC06 | Login | Invalid password | Error and no session |  | Not run |
| TC07 | Logout | Logged-in user | Session cleared and home redirect |  | Not run |
| TC08 | Menu display | Request menu without filters | Database menu displayed |  | Not run |
| TC09 | Menu search | Search term | Matching rows only |  | Not run |
| TC10 | Category filter | Category ID | Matching category rows |  | Not run |
| TC11 | Cart | Add menu item | Item appears with quantity one |  | Not run |
| TC12 | Cart | Increase quantity | Quantity increments |  | Not run |
| TC13 | Cart | Remove item | Item removed |  | Not run |
| TC14 | Checkout | Valid cart and address | Order created and cart cleared |  | Not run |
| TC15 | Order storage | Checkout | Order and items stored |  | Not run |
| TC16 | My Orders | Logged-in customer | Own order list |  | Not run |
| TC17 | Reservation | Valid dates, time, guests and contact | Reservation pending |  | Not run |
| TC18 | Reservation | Invalid date or guest count | Validation error |  | Not run |
| TC19 | Admin login | Admin credentials | Admin dashboard |  | Not run |
| TC20 | Unauthorized admin access | Customer session | Redirect to home |  | Not run |
| TC21 | Category create | Valid details | Category inserted |  | Not run |
| TC22 | Category update | Existing category and changed name | Category updated |  | Not run |
| TC23 | Category delete | Existing category | Category deleted |  | Not run |
| TC24 | Menu create | Valid category and item | Menu item inserted |  | Not run |
| TC25 | Menu update | Existing menu item | Menu item updated |  | Not run |
| TC26 | Menu delete | Existing menu item | Menu item deleted |  | Not run |
| TC27 | Order status | Valid order and status | Status updated |  | Not run |
| TC28 | Reservation status | Valid reservation and status | Status updated |  | Not run |
