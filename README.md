# 📌 Clean Architecture .NET 8 API

## 📚 Overview
The **Clean Architecture .NET 8 API** is a structured and well-organized example of implementing Clean Architecture using **.NET Core 8**. This project serves as a learning reference for developers who want to understand and implement Clean Architecture using best practices and modern development patterns. 🚀

This repository demonstrates:

👉 **Separation of Concerns (SoC) through Clean Architecture** 🏰  
👉 **Implementation of Code First with Migrations** 🛂  
👉 **Usage of Repository Pattern and Unit of Work** 🔄  
👉 **Automated Testing with xUnit** 🧪  
👉 **Authentication and Authorization with JWT** 🔑   

## 🏰 Project Structure
```
clean-architecture-dotnet.Api
 ├── Config              # Configuration files, such as AutoMapper settings
 │   ├── MappingConfig   # Mapping profiles for AutoMapper
 ├── Controllers         # API controllers handling HTTP requests
 │   ├── V1              # Versioned API controllers
 ├── Middlewares         # Custom middleware components
 ├── Properties          # Metadata and project properties

clean-architecture-dotnet.Application
 ├── Mappings           # AutoMapper configuration for domain-to-view model mappings
 ├── Models             # Application-level data models
 │   ├── Http          # HTTP request/response models
 ├── Services           # Business logic and service layer
 │   ├── Login         # Authentication and authorization logic
 │   │   ├── Interfaces # Interfaces for login services
 │   ├── Products      # Product-related business logic
 │   │   ├── Interfaces # Interfaces for product services
 │   ├── Sales         # Sales-related business logic
 │   │   ├── Interfaces # Interfaces for sales services
 │   ├── Users         # User-related business logic
 │   │   ├── Interfaces # Interfaces for user services
 ├── ViewModels         # View models for API responses
 │   ├── Products      # Product-related view models
 │   ├── Sales         # Sales-related view models
 │   ├── Users         # User-related view models

clean-architecture-dotnet.Domain
 ├── Entities           # Core domain entities
 │   ├── Base          # Base classes for domain entities
 │   ├── Products      # Product entity definitions
 │   ├── Sales         # Sales entity definitions
 │   ├── Users         # User entity definitions
 ├── Enums              # Enumeration types for the domain layer

clean-architecture-dotnet.Infrastructure
 ├── Authentication      # Authentication implementation (JWT, token management)
 ├── Context            # Database context configuration (Entity Framework Core)
 ├── EntitiesConfiguration # Database table configurations (EF Core Fluent API)
 │   ├── Products      # Product table configurations
 │   ├── Sales         # Sales table configurations
 │   ├── Users         # User table configurations
 ├── Repositories       # Data access layer
 │   ├── Products      # Product repository implementations
 │   │   ├── Interfaces # Repository interfaces
 │   ├── Sales         # Sales repository implementations
 │   │   ├── Interfaces # Repository interfaces
 │   ├── Users         # User repository implementations
 │   │   ├── Interfaces # Repository interfaces

clean-architecture-dotnet.Tests
 ├── Application       # Application layer testing
 │   ├── Products      # Product tests implementations
 │   ├── Sales         # Sales tests implementations
 │   ├── Users         # User tests implementations
```

## 🎼 Screenshots
<p align="center">
  <img src="https://github.com/user-attachments/assets/eec7416c-dc82-4a9f-8a8f-c1cb6439b8a4" alt="Screenshot 1">
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/ac84c606-b79e-49fb-a632-01cb51b55d6d" alt="Architecture Diagram">
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/53ace5f6-274a-4d5e-b38f-e57d689db2f7" alt="Screenshot 2">
</p>

## 🚀 Getting Started

### 📝 Prerequisites
Make sure you have the following installed:
- [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Postman](https://www.postman.com/) (optional, for API testing)

### 🔧 Installation
```bash
# Clone the repository
git clone https://github.com/omatheusribeiro/clean-architecture-template-dotnet.git
cd clean-architecture-template-dotnet
```

### ⚙️ Configuration
Before running the application, configure the **database connection string** in:
- `appsettings.json`
- `appsettings.Development.json`

Example:
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=localhost\\SQLEXPRESS;Initial Catalog=clean-architecture-dotnet;Integrated Security=True;TrustServerCertificate=True"
}
```

### ▶️ Running the Application
```bash
# Start the API
dotnet run --project clean-architecture-dotnet.Api
```
The application will automatically check if the database and tables exist. If not, they will be created upon execution.

## 🔑 Authentication & Initial Token Usage
To generate an authentication token, use the following credentials in the **login endpoint**:
- **Email:** `usertest@test.com.br`

## 🛠️ Features & Modules
This application includes:

👉 **User Registration (With Address & Contact Info)** 👤  
👉 **Product Management (With Product Types)** 🛂  
👉 **Sales Registration (With Business Rules Applied)** 💰  

## 🛠️ Technologies Used
- **.NET Core 8** 🚀
- **Entity Framework Core (Code First + Migrations)** 🏰
- **SQL Server** 📂
- **AutoMapper** 🔄
- **xUnit (Unit Testing)** 🧪
- **JWT Authentication** 🔑
- **Repository & Service Layer Pattern** 📚

## 📄 License
This project is licensed under the GPL-2.0 License.

