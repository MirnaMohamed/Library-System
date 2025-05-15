# Library System

A web-based Library Management System built with ASP.NET Core (.NET 8), Entity Framework Core, and MVC/Blazor patterns. The system allows users to manage books, authors, and borrowing records with a modern UI and robust backend.

---

## Features

- **Book Management**: Add, edit, delete, and list books with genre and author assignment.
- **Author Management**: Add, edit, delete, and list authors with full name and biography.
- **Borrowing System**: Request and return books, track borrowing records.
- **Validation**: Client-side and server-side validation for all forms.
- **Notifications**: Toastr notifications for success and error messages.
- **Dynamic Dropdowns**: Genre and author selection in book forms.
- **AJAX/Fetch**: Real-time book availability checks before borrowing.
- **Seeding**: In-memory database seeding for development/testing.

---

## Technologies Used

- **.NET 8 / ASP.NET Core MVC**
- **Entity Framework Core (In-Memory)**
- **AutoMapper**
- **Blazor (for future UI expansion)**
- **jQuery, jQuery Validation, Toastr.js**
- **Bootstrap 4/5 (for styling)**

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or later

### Running the Project

1. **Clone the repository**
2. **Open the solution in Visual Studio.**

3. **Run the project (F5 or Ctrl+F5).**
    - The app uses an in-memory database and seeds sample data on startup.

---

## Project Structure

- `Library System` - MVC Layer
- `Library System/ViewModels/` - View models for data transfer to/from views.
- `Business` - Business logic and service layer.
- `Data` - Data Access.
- `Data/Context/` - EF Core DbContext and data seeding.
- `Domain/Entities/` - Core domain models (Book, Author, BorrowingRecord).
- `Common` - shared layer for custom exceptions
---

## Key Usage Notes

- **Validation**: All forms use `asp-for` and `asp-validation-for` for model binding and validation.
- **Book Availability**: Borrow form disables the borrow button if the book is not available, using a fetch call to the backend.
