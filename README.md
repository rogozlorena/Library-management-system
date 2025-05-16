# Library Management System

## Description
This application is a simple library management system developed in C# using a multi-layer architecture (Core, Data, Services, ConsoleApp). It allows adding, deleting, updating, and searching books, as well as managing borrowing and returning with business rules related to stock availability.

---

## Project Structure

- **LibrarySystem.Core**: Contains the `Book` model with properties such as ID, Title, Author, and Quantity.
- **LibrarySystem.Data**: Handles data persistence with a repository that saves and loads data from a JSON file (`books.json`).
- **LibrarySystem.Services**: Business logic layer, implements CRUD operations, search functionality, lending, and returning processes.
- **ConsoleApp (LibraryManagementSystem)**: Console-based user interface that allows the administrator to interact with the library system.

---

## Implemented Features

- Add new books to the collection.
- Delete existing books.
- Update book details.
- Search for books by title (with option to extend to author).
- Borrow books (only if stock is available).
- Return books (cannot exceed initial stock).
- Check book availability before lending or returning.
- Data persistence using JSON format to maintain state between runs.

---

