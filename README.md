
A modern, full-stack blog application built with ASP.NET Core and Blazor Server.

## 🚀 Features

- Modern, responsive server-side UI with Blazor Server
- SQLite database for data persistence
- Azure App Service hosting

## 🛠️ Tech Stack

### Backend

- ASP.NET Core 8.0
- Entity Framework Core
- SQLite

### Frontend

- Blazor Server
- HTML5/CSS3
- JavaScript/TypeScript

### Database

- SQLite (Lightweight, serverless database)

### Hosting

- Azure App Service

## 📋 Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or Visual Studio Code
- Git

## 🚀 Getting Started

1. Clone the repository

```bash
git clone https://github.com/JunqiaoDuan/MyBlog.git
```

2. Navigate to the project directory

```bash
cd MyBlog
```

3. Restore dependencies

```bash
dotnet restore
```

4. Initialize database

```
-- add migrations (don't need run)
dotnet ef migrations add InitialCreate  --project .\MyBlog.Infrastructure  --startup-project .\MyBlog.Web
dotnet ef migrations add SeedInitialData --project .\MyBlog.Infrastructure  --startup-project .\MyBlog.Web

-- need run
dotnet ef database update --project .\MyBlog.Infrastructure  --startup-project .\MyBlog.Web
```

5. Run the application

```bash
dotnet run
```

## 🔧 Configuration

The application uses the following configuration files:
- `appsettings.json` - Main configuration file
- `appsettings.Development.json` - Development-specific settings

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/JunqiaoDuan/MyBlog/blob/main/LICENSE) file for details.

## 👥 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
