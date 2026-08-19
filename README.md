# 📖 PhoneBook API - Backend (.NET 8) & Full-Stack Overview

REST API developed in C# with .NET 8 and PostgreSQL, designed under a clean layered architecture (separation of responsibilities via DTOs, Controllers, and Service Pattern) for efficient contact management.

---

## 📌 Project Overview & Functionality

**PhoneBook** is a web-based contact management application developed as part of a technical competency test. It provides a complete solution to store, search, filter, and manage different types of contacts with distinct attributes.

### Core Features:
* **Multi-Type Contact Management:** Supports **Person**, **Public Organization**, and **Private Organization** contacts.
* **Dynamic & Custom Fields:** Displays standard information (Name, Phone, Comments) alongside specialized fields unique to each contact type (e.g., Company Name, Tax ID, Position).
* **Interactive Filtering:** Allows users to filter the contact list by any combination of contact types in real-time.
* **Full CRUD Operations:** Comprehensive endpoints to Create, Read, Update, and Delete contacts.
* 
## 🏗️ Architecture & Technologies Used

### Backend (.NET)
* **.NET 8 (ASP.NET Core Web API):** Main framework for building robust, high-performance web services.
* **Entity Framework Core (ORM):** Object-relational mapping for data persistence and management.
* **PostgreSQL:** Relational database for secure contact storage.
* **Swagger / OpenAPI:** Tool for interactive API documentation and endpoint testing.

### Frontend (Angular)
* **Important Repository Note:** The source code for the client-side (Frontend) developed in **Angular** is hosted on the **`AgendaFrontend`** branch of this same repository. Make sure to switch branches if you want to review the graphical interface.

---

## 🗂️ Project Structure (Layered Architecture)

```text
phoneBook/
│
└── AgendaBackend/
    ├── Controllers/         # REST API Controllers (HTTP Endpoints)
    ├── Models/              # Data models and database entities
    ├── DTOs/                # Data Transfer Objects
    ├── Services/            # Business logic and services
    ├── Data/                # Entity Framework Core context and PostgreSQL connection
    ├── Properties/          # Startup configuration (launchSettings.json)
    ├── appsettings.json     # Application configuration and connection string
    └── Program.cs           # Application entry point and dependency injection setup
```

---

## 📋 Prerequisites

Make sure you have the following installed in your local environment:
* [.NET 8 SDK](https://dotnet.microsoft.com/)
* [PostgreSQL](https://www.postgresql.org/) running locally.

---

## ⚙️ Configuration & Execution Instructions

### 1. Clone the Repository
Open your terminal and run the following commands:
```bash
git clone [https://github.com/Bernalyos/phoneBook.git](https://github.com/Bernalyos/phoneBook.git)
cd phoneBook/AgendaBackend
```

### 2. Configure the Database
* Create a database in your local PostgreSQL with the name **`PhoneBook`**.
* Open the `appsettings.json` file and configure your own connection string by replacing `tu_contraseña_aqui` with your local PostgreSQL password:
  ```json
  "DefaultConnection": "Host=localhost;Port=5432;Database=PhoneBook;Username=postgres;Password=tu_contraseña_aqui"
  ```

### 3. Run and Start the Backend
Restore dependencies and start the server using the run command:
```bash
dotnet restore
dotnet run
```
*(You can also use `dotnet watch run` if you prefer the server to automatically restart upon any code changes).*

### 4. Interactive Documentation (Swagger)
Once the server is running, open the following link in your browser to interact with the live API and test the CRUD endpoints:

👉 **[Swagger UI - API Documentation](http://localhost:5117/swagger/index.html)** *(or check the exact HTTP/HTTPS port displayed in your console upon startup)*.

---

## 💻 How to View the Frontend?
If you wish to evaluate the user interface in Angular:
1. Switch to the frontend branch in your terminal:
   ```bash
   git checkout AgendaFrontend
   ```
2. Install dependencies and run the client project:
   ```bash
   cd AgendaFrontend
   npm install
   ng serve
   ```
3. Open `http://localhost:4200` in your web browser.
