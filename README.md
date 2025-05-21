📚 Book Management API

This is a simple Book Management RESTful API built with ASP.NET Core and Entity Framework Core. It allows users to perform basic CRUD operations on a collection of books. The API is ideal for learning and demonstrating backend development using modern .NET practices.

🚀 Features
📘 Add, update, delete, and retrieve books

🔍 Search for books by ID

💾 Data persistence using Entity Framework Core

📂 Organized structure using MVC and Repository patterns

🧪 Minimal API support for lightweight endpoint creation

🛠️ Technologies Used
ASP.NET Core Web API

Entity Framework Core

C#

SQL Server (or local DB of your choice)

Swagger (for API testing and documentation)

BookManagementAPI:
 Controllers
- V1:BooksController.cs
-V2: BooksController.cs

Data: Books.csv
DTO:
  - V1:
    - LinkDTO.cs
    - RestDTO.cs
  - V2:
     - LinkDTO.cs
    - RestDTO.cs
  - BookDTO.cs
Models: 
  - Book.cs
  - AppDbContext.cs
  - Book_Domains.cs
  - Book_Mechanics.cs
  - Domain.cs
  - Mechanic.cs
Program.cs
appsettings.json

🧑‍💻 Getting Started
Prerequisites
.NET 8 SDK

SQL Server or LocalDB

Setup
1. Clone the repository:
git clone https://github.com/Ga6i/BookManagementAPI.git
cd BookManagementAPI

2. Configure the database connection string in appsettings.json.

3. Run EF Core migrations (if not already created):
dotnet ef migrations add InitialCreate
dotnet ef database update

4. Run the application:
dotnet run

5. Open in browser:

Visit https://localhost:5001/swagger to test endpoints via Swagger UI.

📌 Example Endpoints
GET /api/books — Retrieve all books

GET /api/books/{id} — Retrieve a specific book

POST /api/books — Add a new book

PUT /api/books/{id} — Update an existing book

DELETE /api/books/{id} — Delete a book

🧪 Testing
Swagger is pre-configured for easy endpoint testing. Use tools like Postman or curl for additional testing.

🧾 License
This project is licensed under the MIT License.
