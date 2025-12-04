# 🏢 LeaveFlowAPI - Vállalati Jelenlét és Szabadságkezelő Rendszer

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat&logo=microsoft-sql-server)
![EF Core](https://img.shields.io/badge/EF%20Core-Database%20First-512BD4)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-85EA2D?style=flat&logo=swagger)

A **LeaveFlowAPI** egy modern, .NET alapú RESTful API, amelyet közép- és nagyvállalatok belső HR folyamatainak, különösen a szabadságkérelmek és a szervezeti felépítés (Részlegek, Menedzserek) kezelésére terveztem.

---

## 🚀 Funkciók

* **👥 Alkalmazottak Kezelése (CRUD):** Teljes körű adminisztráció, beleértve a részleghez rendelést.
* **🏢 Részleg-hierarchia:** Részlegek kezelése, menedzserek hozzárendelése és az adott részleghez tartozó dolgozók listázása.
* **📅 Szabadságkezelés:**
    * Kérelmek benyújtása validációval.
    * Státuszok kezelése (Függőben, Elfogadva, Elutasítva).
* **📄 Dokumentáció:** Automatikusan generált, interaktív Swagger UI XML kommentekkel.

---

## 🏗️ Technológiai Stack és Architektúra

A rendszer a **Repository Design Pattern**-t követi a felelősségi körök szétválasztása érdekében:

* **Backend:** ASP.NET Core Web API (.NET 9)
* **Adatbázis:** Microsoft SQL Server 2022 (Docker konténerben futtatva)
* **ORM:** Entity Framework Core (Database First megközelítés)
* **Architektúra:**
    * **Controllers:** Csak a HTTP kéréseket kezelik, nincs bennük üzleti logika.
    * **Repositories:** Az adatbázis-műveletek kiszervezve (Interface alapú megközelítés a tesztelhetőségért).
    * **Models:** SQL táblákból generált entitások.