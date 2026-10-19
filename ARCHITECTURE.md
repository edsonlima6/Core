# Architecture, Layers, and Configuration Specification

## 1. Executive Summary

This document registers the architectural blueprint, design patterns, layer boundaries, and configuration settings for the **Core / SkyNet** enterprise platform. 

The system is built on **.NET 10.0**, employing a **Clean / Layered Architecture** with elements of **Domain-Driven Design (DDD)**, **Event-Driven Architecture (EDA)**, **Transactional Outbox Pattern**, and a **Dual-ORM persistence strategy** (Entity Framework Core 10 for domain transactional operations and Dapper for high-performance data queries).

---

## 2. Architectural Blueprint

```
                      ┌───────────────────────────────────────────────┐
                      │             PRESENTATION / HOST               │
                      │  ┌─────────────────┐   ┌───────────────────┐  │
                      │  │  SkyNetApiCore  │   │ SkynetProductsApi │  │
                      │  │   (REST APIs)   │   │  (Blazor Server)  │  │
                      │  └────────┬────────┘   └────────┬──────────┘  │
                      │  ┌────────┴────────┐   ┌────────┴──────────┐  │
                      │  │ SkyNetOrderGrpc │   │ React Vite SPA    │  │
                      │  │     (gRPC)      │   │(skynet-ctrl-mgr)  │  │
                      │  └─────────────────┘   └───────────────────┘  │
                      └───────────────────────┬───────────────────────┘
                                              │
                      ┌───────────────────────▼───────────────────────┐
                      │               APPLICATION LAYER               │
                      │  - Handlers (UserHandler, CreateSupplier)     │
                      │  - Commands & DTOs                            │
                      │  - Domain Event Publisher & Handlers          │
                      │  - Global Exception Handling Middleware       │
                      └──────────────┬────────────────────────┬───────┘
                                     │                        │
             ┌───────────────────────▼───────┐                │
             │         DOMAIN LAYER          │                │
             │  - Entities (User, Supplier)  │                │
             │  - Domain Notifications       │                │
             │  - Repository Interfaces      │                │
             │  - Outbox Message Contract    │                │
             └───────────────▲───────────────┘                │
                             │                                │
             ┌───────────────┴────────────────────────────────▼───────┐
             │                 INFRASTRUCTURE LAYERS                  │
             │  ┌───────────────────────┐  ┌───────────────────────┐  │
             │  │      InfraCoreEF      │  │    InfraCoreDapper    │  │
             │  │ - ContextBD (EF Core) │  │ - Dapper Repositories │  │
             │  │ - Migrations & Maps   │  │ - Raw SQL & Session   │  │
             │  │ - EF Repositories     │  │ - Fast Query UoW      │  │
             │  └───────────────────────┘  └───────────────────────┘  │
             │  ┌──────────────────────────────────────────────────┐  │
             │  │ Infra.IoC (Dependency Injection & Service Setup) │  │
             │  └──────────────────────────────────────────────────┘  │
             └───────────────────────┬────────────────────────────────┘
                                     │
                      ┌──────────────▼────────────────────────────────┐
                      │    EXTERNAL SERVICES & BACKGROUND WORKERS     │
                      │  - SQL Server 2025 Evaluation (Linux/Docker)  │
                      │  - RabbitMQ 3 (OrderQueueWorker)              │
                      │  - Azure Service Bus (Console publisher/receiver)│
                      │  - Hangfire SQL Server (Scheduled Jobs)       │
                      └───────────────────────────────────────────────┘
```

---

## 3. Layer Breakdown and Responsibilities

### 3.1. Domain Layer (`Domain`)
* **Target Framework:** `net10.0` (also packaged as NuGet package `SkyNetRisen.Domain`).
* **Purpose:** Core enterprise business rules and domain model.
* **Key Components:**
  * **Entities:** `EntityBase` (base entity with `Id`, `GuidId`, `CreatedON`, `IsValid()`), `User`, `Supplier`, `OutboxMessage`, `Email`.
  * **Specifications & Notifications:** `DomainNotification`, `Notification`, `ExcptionBD` – handles domain validation messages without throwing costly runtime exceptions.
  * **Validations:** Fluent validators and business rules (`AlergiaValidator`, `CargoValidator`, `GrupoValidator`).
  * **Repository Interfaces:** `IUserRepository`, `ISupplierRepository`, `IOutboxMessageRepository`, `IRepositoryBase`, `IUnitOfWorkCore`.

### 3.2. Application Layer (`Application`)
* **Target Framework:** `net10.0`.
* **Purpose:** Application orchestration, use case handlers, commands, DTO transformations, and pipeline middleware.
* **Key Components:**
  * **Handlers & Commands:**
    * `UserHandler` (implements `IUserHandler`): Orchestrates user creation, transactional persistence, and Outbox event creation.
    * `CreateSupplierHander` (implements `IDomainEventHandler<CreateSupplierCommand>`): Validates supplier domain rules and persists records.
  * **DTOs & ViewModels:** `CreateUserDto`, `UserDto`.
  * **Domain Events & Dispatcher:** `IDomainEvent`, `IDomainEventHandler<T>`, `IDomainEventPublisher`, `DomainEventPublisher` (custom in-process mediator).
  * **Middleware:** `GlobalExceptionMiddleware` mapping runtime exceptions (`ArgumentException`, `KeyNotFoundException`, `UnauthorizedAccessException`) to RFC 7807 `ProblemDetails`.

### 3.3. Infrastructure Layers
The infrastructure is split into specialized concerns:

#### A. `InfraCoreEF` (Command / Transactional Persistence)
* **Technology:** Entity Framework Core 10 (`Microsoft.EntityFrameworkCore.SqlServer`).
* **Components:**
  * `ContextBD`: Main EF `DbContext` supporting `DbSet<User>`, `DbSet<Supplier>`, `DbSet<OutboxMessage>`, `DbSet<Blog>`, `DbSet<Post>`.
  * Fluent Mappings: `UserMap`, `SupplierMap`, `OutboxMessagesMap`, `BlogMap` (`IEntityTypeConfiguration<T>`).
  * Unit of Work: `UnitOfWorkEF` wrapping `IDbContextTransaction` for atomic commits across entities and outbox messages.
  * Repositories: `UserRepository`, `SupplierRepository`, `OutboxMessageRepository`.
  * EF Core Migrations: Automated relational schema versioning.

#### B. `InfraCoreDapper` (Query / High-Performance Read Persistence)
* **Technology:** Dapper 2.1.79 & Dapper.Contrib 2.0.78.
* **Components:**
  * `DalSession` & `UnitOfWork`: Manages direct `SqlConnection` and `SqlTransaction` boundaries.
  * `RepositoryBase`: Generic CRUD operations and fast query execution via Dapper extensions.

#### C. `Infra.IoC` (Cross-Cutting Inversion of Control)
* **Purpose:** Centralized dependency injection container configuration.
* **Extension Method:** `IServiceCollection.AddConfigureServices(string connStrg)`
  * Registers `ContextBD` with SQL Server retry-on-failure resilience.
  * Registers Scoped Repositories (`IUserRepository`, `ISupplierRepository`, `IOutboxMessageRepository`).
  * Registers Transient Dapper `IRepositoryBase`.
  * Auto-discovers and registers domain event handlers (`AddDomainEventHandlers`).
  * Registers handlers (`IUserHandler -> UserHandler`).

### 3.4. Host & Presentation Surfaces

| Host Project | Type | Role |
| :--- | :--- | :--- |
| **`SkyNetApiCore`** | ASP.NET Core Web API | Main REST gateway with Swagger UI, RabbitMQ worker, and SPA proxy. |
| **`SkynetProductsApi`** | Blazor Web App + API | Interactive Server Components interface for product catalog operations alongside API endpoints. |
| **`SkyNetOrderGrpc`** | gRPC Service | High-throughput RPC endpoint for microservices order communications (`greet.proto`). |
| **`IntegrationCoreConsole`** | Console Application | Standalone host for the transactional outbox publisher and Azure Service Bus topic subscription receiver. |
| **`SPA/skynet-control-manager`**| React + Vite SPA | Single Page Application dashboard built with TypeScript, Bootstrap, and Vite. |

---

## 4. Messaging & Background Processing Patterns

### 4.1. Transactional Outbox Pattern
* **Problem Solved:** Guarantees reliable publishing of events without distributed two-phase commits.
* **Flow:**
  1. A transaction is initiated via `UnitOfWorkEF.BeginTransactionAsync()`.
  2. The entity change (`User`) and the event payload (`OutboxMessage`) are written within the same database transaction.
  3. The transaction commits atomically.
  4. `IntegrationCoreConsole` hosts `OutboxPublisherWorker` (BackgroundService), which periodically queries `OutboxMessages` where `ProcessedAt == null`, publishes messages to the **Azure Service Bus** topic (`product-events`), and marks them processed.
  5. `ServiceBusMessageReceiverWorker` in `IntegrationCoreConsole` listens on the configured topic subscription, passes each message to an integration handler, and completes it on success or abandons it on handler failure.

### 4.2. RabbitMQ Message Consumer
* **Worker:** `OrderQueueWorker` (BackgroundService in `SkyNetApiCore`).
* **Connection:** Uses `RabbitMQ.Client` 7.2.1 asynchronous API (`CreateConnectionAsync`, `CreateChannelAsync`, `AsyncEventingBasicConsumer`).
* **Handling:** Configured with manual ACK (`BasicAckAsync`), requeue on transient failures (`BasicNackAsync`), and reject without requeue on serialization errors (`BasicRejectAsync`).

### 4.3. Hangfire Scheduled Jobs
* Configured in `SkyNetApiCore/Startup.cs` using `Hangfire.SqlServer` for background jobs and dashboard management.

---

## 5. Configuration & Settings Inventory

### 5.1. Central Package Management (`Directory.Packages.props`)
All NuGet dependency versions are centrally managed across the solution:
* **.NET Runtime:** `net10.0`
* **EF Core:** `10.0.8` (Design, SqlServer, Tools)
* **Dapper / Dapper.Contrib:** `2.1.79` / `2.0.78`
* **Azure Service Bus:** `7.21.0`
* **RabbitMQ Client:** `7.2.1`
* **Hangfire:** `1.8.23`
* **Grpc.AspNetCore:** `2.64.0`
* **Swashbuckle:** `10.2.1`

### 5.2. Connection Strings

| Key | Default Target | Purpose |
| :--- | :--- | :--- |
| `connectionStringWin` | `Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SkyNetApiCore;Integrated Security=True;` | Local Windows development with LocalDB |
| `connectionStringLinux` | `Server=localhost,1433;Database=SkyNetApiCore;User Id=sa;Password=I10easttoLA;Encrypt=false;TrustServerCertificate=True;` | Containerized SQL Server (Linux/Docker) |
| `SqliteConnectionString` | `Data Source=Db/SkyNet.db` | Alternative SQLite data store |

### 5.3. Messaging Configuration (`appsettings.json`)

```json
{
  "RabbitMQ": {
    "HostName": "localhost",
    "Port": 5672,
    "UserName": "guest",
    "Password": "guest",
    "VirtualHost": "/",
    "QueueName": "order.queue",
    "PrefetchCount": 1
  },
  "AzureServiceBus": {
    "FullyQualifiedNamespace": "your-namespace.servicebus.windows.net",
    "ConnectionString": "",
    "TopicName": "product-events",
    "SubscriptionName": "integration-core-console"
  },
  "OutboxPublisher": {
    "Enabled": false,
    "BatchSize": 10,
    "PollIntervalSeconds": 5
  },
  "OutboxReceiver": {
    "Enabled": false
  }
}
```

### 5.4. Docker & Container Topology (`docker-compose.yml`)

1. **`sql2025evaluation`**:
   * Image: `mcr.microsoft.com/mssql/server:2025-latest`
   * Port: `1433:1433`
   * Healthcheck: Executes `sqlcmd` periodically before dependent services start.
2. **`rabbitmq`**:
   * Image: `rabbitmq:3-management`
   * Ports: `5672:5672` (AMQP), `15672:15672` (Management Dashboard).
3. **`skynetapicore`**:
   * Build Context: `.`, Dockerfile: `SkyNetApiCore/Dockerfile`.
   * Port: `5000:80`.
   * Depends On: `sql2025evaluation` (healthy), `rabbitmq` (started).

---

## 6. Code Verification Findings & Recommendations

### 6.1. Identified Architectural Deficiencies

1. **Inverted Dependency in Application Layer:**
   * *Finding:* `Application/Application.csproj` directly references `InfraCoreEF/InfraCoreEF.csproj`. Furthermore, `UserHandler.cs` constructor injects `InfraCoreEF.Db.IUnitOfWork`.
   * *Impact:* Violates Clean Architecture / Dependency Inversion Principle. The Application layer should only depend on abstractions defined in `Domain`, not on concrete Infrastructure assemblies.
   * *Remediation:* Move `IUnitOfWork` into `Domain.Interfaces.Repositories` and remove the `InfraCoreEF` project reference from `Application.csproj`.

2. **Domain Layer Coupled to Database Vendor:**
   * *Finding:* `Domain/Domain.csproj` directly references `Microsoft.Data.SqlClient` and `Dapper.Contrib`. `IUnitOfWorkCore.cs` exposes `SqlTransaction` and `SqlConnection`.
   * *Impact:* Domain layer loses persistence ignorance; cannot swap or mock storage without referencing vendor-specific ADO.NET packages.
   * *Remediation:* Abstract database transactions and connections using generic interfaces (or `DbTransaction` / `DbConnection` from `System.Data.Common`), removing `Microsoft.Data.SqlClient` from `Domain`.

3. **Operating System Connection Selection Bug:**
   * *Finding:* In `SkyNetApiCore/Startup.cs`:
     ```csharp
     private string GetConnBasedToOperatingSystem()
     {
         PlatformID OS = Environment.OSVersion.Platform;
         if (OS == PlatformID.Unix)
             return Configuration.GetConnectionString("connectionStringLinux");

         return Configuration.GetConnectionString("connectionStringLinux"); // Should be connectionStringWin
     }
     ```
   * *Impact:* Windows machines trying to run locally against LocalDB will default to Linux container connection string unless overridden.
   * *Remediation:* Return `connectionStringWin` for non-Unix environments.

4. **Async / Sync Anti-Pattern in Handlers:**
   * *Finding:* In `CreateSupplierHander.cs`:
     ```csharp
     await supplierRepository.InsertAsync(supplier);
     supplierRepository.SaveChanges();
     ```
   * *Impact:* Calling synchronous `SaveChanges()` immediately after an async call causes thread pool blocking.
   * *Remediation:* Use `await supplierRepository.SaveChangesAsync()` and enlist within the Unit of Work.

5. **Security & Credential Management:**
   * *Finding:* Hardcoded SQL Server passwords (`I10easttoLA`) are present in `appsettings.json`, `ContextBD.cs` comments, and `docker-compose.yml`.
   * *Impact:* High vulnerability if repositories are made public or shared.
   * *Remediation:* Externalize secrets to environment variables, .NET User Secrets (`dotnet user-secrets`), or Azure Key Vault / Kubernetes Secrets.

6. **Transitive Dependency Vulnerabilities:**
   * *Finding:* Build warnings reported `NU1903` and `NU1902` on package `System.Security.Cryptography.Pkcs` 9.0.13.
   * *Remediation:* Update `Directory.Packages.props` to override or pin `System.Security.Cryptography.Pkcs` to `>= 9.0.14` or latest patched release.
