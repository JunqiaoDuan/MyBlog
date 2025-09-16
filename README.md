
A modern, full-stack blog application built with **ASP.NET Core**, **Blazor**, and **SQL Server**.

[🌐 View Live](https://www.drinduan.com)

---

## 🚀 Features

- Modern, responsive UI with Blazor Server
- Support for both SQL Server and SQLite databases
- AI integration (OpenAI, Gemini)
- PDF CV generator
- Azure App Service hosting
- Azure Key Vault, Azure Storage, and Azure Function integration
- Domain-Driven Design (DDD) concepts
- Repository and Specification patterns

---

## 🏗️ Architecture

- Clean separation of concerns with DDD and repository patterns
- Modular service and data access layers
- Extensible for future features and integrations

---

## 🛠️ Tech Stack

### Backend

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **SQL Server** / **SQLite** (configurable)
- **Azure App Service**

### Frontend

- **Blazor Server**
- **MudBlazor**
- **HTML5/CSS3**
- **JavaScript/TypeScript**

### Database

- Supports both **SQL Server** and **SQLite**

---

## ✨ Highlights

- AI model integration (OpenAI, Gemini)
- Azure ecosystem integration (App Service, Key Vault, Storage, Functions)
- Domain-Driven Design (DDD)
- Repository and Specification patterns
- PDF generator for CV/resume creation

---

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 or Visual Studio Code
- Git

---

## 🚀 Getting Started

1. **Clone the repository**
   
```shell
    git clone https://github.com/JunqiaoDuan/MyBlog.git
    cd MyBlog
    
```

2. **Restore dependencies**
   
```shell
    dotnet restore
    
```

3. **Initialize the database**
   
```shell
    # (Optional) Add migrations if needed
    dotnet ef migrations add InitialCreate --project .\MyBlog.Infrastructure --startup-project .\MyBlog.Web
    dotnet ef migrations add SeedInitialData --project .\MyBlog.Infrastructure --startup-project .\MyBlog.Web

    # Apply migrations
    dotnet ef database update --project .\MyBlog.Infrastructure --startup-project .\MyBlog.Web
    
```

4. **Run the application**
   
```shell
    dotnet run
    
```

---

## 🔧 Configuration

- `appsettings.json` — Main configuration file
- `appsettings.Development.json` — Development-specific settings

---

## 📝 License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/JunqiaoDuan/MyBlog/blob/main/LICENSE) file for details.

---

## 👥 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

---

