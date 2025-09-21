# TODO App

A web application for task management, built with ASP.NET Core 8.0 using Clean Architecture principles.

## 🚀 Features

- **User Registration & Authentication** - Secure login system using ASP.NET Core Identity
- **Task Management** - Create, edit, view, and delete notes
- **Personalization** - Each user sees only their own tasks
- **Modern Interface** - Responsive design with Bootstrap

## 🏗️ Architecture

The project is built following Clean Architecture principles with four main layers:

### TODO_APP.Core
- **Data Models**: `User`, `Note`
- **Request DTOs**: `LoginRequest`, `RegisterRequest`
- Base entities and contracts

### TODO_APP.Data
- **Entity Framework Core** with PostgreSQL
- **Repositories**: `INoteRepository`, `IUserRepository`
- **Unit of Work** pattern
- **Migrations** for database schema management

### TODO_APP.Service
- **Business Logic** and services
- **DTOs**: `CreateNoteDto`, `UpdateNoteDto`, `LoginDto`, `RegisterDto`
- **AutoMapper** for object mapping
- **Services**: `AuthService`, `NoteService`

### TODO_APP.Web
- **ASP.NET Core MVC** web application
- **Controllers**: `AuthController`, `NoteController`, `HomeController`
- **Views** with Razor Pages
- **Bootstrap** for styling

## 🛠️ Technologies

- **.NET 8.0**
- **ASP.NET Core MVC**
- **Entity Framework Core 9.0.7**
- **PostgreSQL** (database)
- **ASP.NET Core Identity** (authentication)
- **AutoMapper 12.0.1**
- **Bootstrap** (UI framework)

## 📋 Requirements

- .NET 8.0 SDK
- PostgreSQL 12+
- Visual Studio 2022 or VS Code

## ⚙️ Installation & Setup

### 1. Clone the repository
```bash
git clone <repository-url>
cd TODO_APP
```

### 2. Database setup
1. Install PostgreSQL
2. Create a database named `TodoDB`
3. Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=TodoDB;Username=your_username;Password=your_password;"
  }
}
```

### 3. Apply migrations
```bash
cd TODO_APP.Web
dotnet ef database update
```

### 4. Run the application
```bash
dotnet run
```

## 📁 Project Structure

```
TODO_APP/
├── TODO_APP.Core/           # Models and contracts
│   ├── Model/
│   │   ├── User.cs
│   │   ├── Note.cs
│   │   └── Requests/
│   └── TODO_APP.Core.csproj
├── TODO_APP.Data/           # Data access layer
│   ├── Repos/
│   │   ├── Interfaces/
│   │   ├── NoteRepository.cs
│   │   └── UserRepository.cs
│   ├── TodoDBContext.cs
│   ├── UnitOfWork.cs
│   └── Migrations/
├── TODO_APP.Service/        # Business logic
│   ├── DTO/
│   ├── Interfaces/
│   ├── Services/
│   ├── Mappings/
│   └── TODO_APP.Service.csproj
├── TODO_APP.Web/           # Web application
│   ├── Controllers/
│   ├── Views/
│   ├── wwwroot/
│   ├── Program.cs
│   └── appsettings.json
└── TODO_APP.sln
```

## 🔐 Security

- **ASP.NET Core Identity** for user management
- **Password hashing** using built-in mechanisms
- **Data validation** at all levels
- **CSRF protection**
- **Authorization** - users see only their own tasks

## 🎯 Key Features

### User Management
- User registration
- User login
- User logout
- Profile viewing

### Task Management
- **Create** new notes
- **View** task list
- **Edit** existing tasks
- **Delete** tasks
- **Detailed view** of tasks

## 📝 License

This project is distributed under the MIT License. See the `LICENSE` file for details.

