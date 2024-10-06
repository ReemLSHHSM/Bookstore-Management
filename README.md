# Bookstore Management System

## Overview
The **Bookstore Management System** is a web application built using ASP.NET Core and Entity Framework Core. The purpose of this project is to provide functionality to manage books in a bookstore. Users can view all books, add new books, edit existing book details, view book details, and delete books from the inventory.

## Features
- **Create Books**: Add new books with details like Title, Author, Genre, and Price.
- **View Books**: Display a list of all the books in the bookstore.
- **Edit Books**: Modify existing book details.
- **Delete Books**: Remove books from the inventory.
- **View Book Details**: See detailed information about a specific book.

## Technologies Used
- **ASP.NET Core MVC**: For creating the web application.
- **Entity Framework Core**: For interacting with the database (CRUD operations).
- **Microsoft SQL Server**: The database used for storing book data.

## Project Structure
- **Controllers**: Handles requests, processes data from the database, and returns views.
  - `BookController`: Manages all book-related actions like adding, editing, deleting, and viewing books.
  
- **Models**: Represents the data structure.
  - `Book`: Contains properties like `Id`, `Title`, `Author`, `Genre`, and `Price`.

- **Views**: Displays the user interface for interacting with the system.
  - **Create**: A form to add a new book.
  - **Edit**: A form to edit an existing book.
  - **Details**: Displays details of a specific book.
  - **Index**: Shows all books in the inventory.
  - **Delete**: Confirms the deletion of a book.

