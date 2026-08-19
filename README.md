# 📖 PhoneBook API - Backend (.NET 8)

REST API developed in C# with .NET 8 and PostgreSQL, designed under a clean layered architecture (separation of responsibilities via DTOs, Controllers, and Service Pattern) for efficient contact management.

---

## 🚀 Enlaces en Producción (Demo en Vivo)
* **Frontend (Vercel):** [Ver Aplicación en Vivo](https://phonebook-frontend-amber.vercel.app)
* **Backend API (Render):** [Documentación Swagger / API](https://agendabackend-p9qp.onrender.com/swagger/index.html)
> ⚠️ **Note on Deployment (Render Free Tier):**
> The backend service is hosted on Render's free tier. If the server has been inactive, the initial request may take 30 to 40 seconds to spin up. If the application takes a brief moment to respond on the first load, please allow a few seconds for the server to wake from sleep mode.

---

## 📌 Project Overview & Functionality

**PhoneBook** is a web-based contact management application backend developed as part of a technical competency test. It provides a complete RESTful solution to store, search, filter, and manage different types of contacts with distinct attributes.

### Core Features:
* **Multi-Type Contact Management:** Supports **Person**, **Public Organization**, and **Private Organization** contacts.
* **Dynamic & Custom Fields:** Handles standard information (Name, Phone, Comments) alongside specialized fields unique to each contact type (e.g., Company Name, Tax ID, Position).
* **Interactive Filtering Support:** Endpoints ready to filter the contact list by contact types in real-time.
* **Full CRUD Operations:** Comprehensive endpoints to Create, Read, Update, and Delete contacts.

---

## 🏗️ Architecture & Technologies Used

### Backend (.NET)
* **.NET 8 (ASP.NET Core Web API):** Main framework for building robust, high-performance web services.
* **Entity Framework Core (ORM):** Object-relational mapping for data persistence and management.
* **PostgreSQL:** Relational database for secure contact storage (Cloud database hosted on Neon).
* **Swagger / OpenAPI:** Tool for interactive API documentation and endpoint testing.

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
git clone https://github.com/Bernalyos/phoneBook.git
cd phoneBook/AgendaBackend
```

### 2. Configure the Database
* Create a database in your local PostgreSQL with the name **`PhoneBook`** (or your preferred name).
* Open the `appsettings.json` file and configure your connection string by replacing `tu_contraseña_aqui` with your local PostgreSQL password:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=PhoneBook;Username=postgres;Password=tu_contraseña_aqui"
  }
}
```

### 3. Run and Start the Backend
Restore dependencies and start the server using the run commands in your terminal:
```bash
dotnet restore
dotnet run
```
*(You can also use `dotnet watch run` if you prefer the server to automatically restart upon any code changes).*

### 4. Interactive Documentation (Swagger)
Once the server is running locally, open the following link in your browser to interact with the API and test the CRUD endpoints:

👉 **[Swagger UI - Local API](http://localhost:5117/swagger/index.html)** *(or check the exact HTTP/HTTPS port displayed in your console upon startup)*.
