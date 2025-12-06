# 🏢 LeaveFlow - Corporate Attendance & Leave Management System

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)
![Angular](https://img.shields.io/badge/Angular-18+-DD0031?style=flat&logo=angular)
![TypeScript](https://img.shields.io/badge/TypeScript-3178C6?style=flat&logo=typescript)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoft-sql-server)

**LeaveFlow** is a modern, Full-Stack corporate web application designed to manage internal HR processes, specifically leave requests and organizational structure.

The project includes a .NET-based REST API and its corresponding Angular frontend client.

---

## Features

### Backend (.NET API)
* **API Architecture:** RESTful services, Clean Architecture principles.
* **Data Management:** Repository Pattern and Unit of Work for clean data access.
* **Database:** Database-First approach with EF Core, running in a Docker container.

### Frontend (Angular Client)
* **Modern UI:** Component-based architecture (Standalone Components).
* **Reactive Data Management:** Using RxJS and `Async Pipe` for real-time data display.
* **Structure:** Separated Service layer for API communication.
* **Display:** Dynamic tables and data lists.

---

## Technologies

| :--- | :--- |
| **Backend** | .NET 9, ASP.NET Core Web API, C# |
| **Frontend** | Angular v18, TypeScript, HTML5, CSS |
| **Database** | Microsoft SQL Server 2022 (Docker) |
| **ORM** | Entity Framework Core |
| **Tools** | Swagger (OpenAPI), Docker, Git |

---

## 📂 Project Structure

```text
LeaveFlow/             (Root Directory)
├── LeaveFlowAPI/      (Backend Project - .NET)
│   ├── Controllers/
│   ├── Repositories/
│   └── ...
├── LeaveFlow-Client/  (Frontend Project - Angular)
│   ├── src/app/
│   └── ...
└── README.md