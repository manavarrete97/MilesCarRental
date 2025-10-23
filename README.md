🚗 MilesCarRental API

API modular y escalable para la consulta de disponibilidad de vehículos en MilesCarRental, implementada con una arquitectura limpia (Clean Architecture), CQRS, y consumo de un servicio externo de disponibilidad.

🧱 Arquitectura del Proyecto

La solución está organizada en 4 capas principales:

MilesCarRental.sln
│
├── MilesCarRental.Api             → Capa de presentación (Controllers, Endpoints)
├── MilesCarRental.Application     → Lógica de negocio y casos de uso (CQRS + MediatR)
├── MilesCarRental.Domain          → Entidades y modelos de dominio
└── MilesCarRental.Infrastructure  → Persistencia, InMemory, Repositorios, Data Access

🧩 Diagrama lógico
┌──────────────────────────────┐
│        MilesCarRental.Api    │
│   (Controllers, Endpoints)   │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│   MilesCarRental.Application │
│  (CQRS, Handlers, Services)  │
│      - IAvailabilityService  │
│      - IVehicleReadRepository│
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│   MilesCarRental.Infrastructure │
│ (Repositorios, HttpClient, DB)  │
│   - AvailabilityService         │
│   - VehicleReadRepository       │
│   - InMemoryVehicleReadRepo     │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│       MilesCarRental.Domain  │
│ (Entidades y DTOs de dominio)│
│   - Vehicles, Inventory, etc │
└──────────────────────────────┘

⚙️ Tecnologías Utilizadas

.NET 8 / ASP.NET Core Web API

C# 12

Entity Framework Core (InMemory)

MediatR (CQRS)

HttpClientFactory

Dependency Injection

Clean Architecture Pattern

🚀 Funcionalidades Principales
🔍 1. Consulta de Disponibilidad

Endpoint REST que recibe un token de búsqueda (quickSearch) en base64 y retorna la disponibilidad de vehículos, consultando la API externa de MilesCarRental.

Endpoint:

GET /api/availability?quickSearch=ZW5lcmdpemVlLTE3NjExNzY5OTUuNTcyNS0yMTI1


Ejemplo de flujo:

AvailabilityController recibe el token quickSearch.

Construye un Rootobject (Request de dominio).

Envía la solicitud al servicio externo mediante AvailabilityService.

Se deserializa la respuesta (Response.Rootobject).

Devuelve el resultado en formato JSON al cliente.

🧰 Estructura de Capas y Archivos Clave
🗂 MilesCarRental.Api

Controllers/

AvailabilityController.cs → Controlador base para disponibilidad de vehículos.

🧠 MilesCarRental.Application

Interfaces/

IAvailabilityService.cs → Define contrato del servicio externo.

IVehicleReadRepository.cs → Define contrato del repositorio de lectura de vehículos.

Services/

AvailabilityService.cs → Implementación concreta que llama a la API externa.

Availability/Queries/GetAvailability/

GetAvailabilityHandler.cs

GetAvailabilityQuery.cs

DependencyInjection.cs

Registra MediatR, HttpClient, y dependencias del módulo.

🧩 MilesCarRental.Domain

Vehicles/

Entidades de dominio (Vehicle, Inventory, etc.)

Availability/

Request/ → DTOs para construir el cuerpo de la solicitud.

Response/ → DTOs para mapear la respuesta del servicio externo.

🧱 MilesCarRental.Infrastructure

Repositories/

VehicleReadRepository.cs → Acceso a base de datos (EF Core o InMemory).

InMemory/

InMemoryDataStore.cs

InMemoryVehicleReadRepository.cs

Persistence/

AppDbContext.cs → Contexto EF Core.

DbSeeder.cs → Sembrado inicial de datos.

DependencyInjection.cs → Registro de servicios de infraestructura.

🧩 Ejemplo de Request / Response
Request
{
  "SearchKey": "ZW5lcmdpemVlLTE3NjExNzY5OTUuNTcyNS0yMTI1",
  "idSession": "b82b5d2b-1c2f-4e7f-8c2b-6fbb89a9d3a0",
  "Pagination": {
    "numberItemPerPage": 20,
    "numberPage": 1,
    "totalItems": 0,
    "totalPage": 0
  },
  "UrlDiscount": []
}

Response (simplificado)
{
  "status": "success",
  "data": {
    "vehicles": [
      {
        "brand": "Toyota",
        "model": "Corolla",
        "category": "Sedán",
        "price": 85.50,
        "currency": "USD"
      }
    ]
  }
}

🧩 Ejemplo de Registro de Dependencias
// Application
services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
services.AddHttpClient<IAvailabilityService, AvailabilityService>(client =>
{
    client.BaseAddress = new Uri("https://api.milescarrental.com/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// Infrastructure
services.AddSingleton<InMemoryDataStore>();
services.AddScoped<IVehicleReadRepository, InMemoryVehicleReadRepository>();

🧪 Ejecución Local
1️⃣ Restaurar dependencias
dotnet restore

2️⃣ Compilar el proyecto
dotnet build

3️⃣ Ejecutar la API
dotnet run --project MilesCarRental.Api

4️⃣ Probar en Swagger

Abre en el navegador:

https://localhost:5001/swagger

🧩 Ejemplo de Flujo CQRS
sequenceDiagram
    participant Client
    participant Controller
    participant Handler
    participant Service
    participant API

    Client->>Controller: GET /api/availability?quickSearch=...
    Controller->>Handler: Send(GetAvailabilityQuery)
    Handler->>Service: GetAvailabilityAsync(request)
    Service->>API: POST /availability
    API-->>Service: JSON response
    Service-->>Handler: Rootobject
    Handler-->>Controller: Rootobject
    Controller-->>Client: 200 OK (response)

