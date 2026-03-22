# Target Architecture Document
## MMOGardenTracker — Rewrite

**Version:** 1.0 (Draft)  
**Date:** 2026-03-22  
**Status:** Draft for review

---

## 1. Purpose

This document describes the proposed target architecture for the MMOGardenTracker rewrite. It is intended to guide AI-assisted and human development teams during implementation and to serve as the authoritative reference for architectural decisions.

---

## 2. Current-State Summary

| Dimension | Current State |
|---|---|
| Backend runtime | .NET 6 (out of support) |
| Backend framework | ASP.NET Core Web API with `Startup.cs` hosting pattern |
| ORM | Entity Framework Core 7 (version skew vs. .NET 6 target) |
| Database | SQL Server (active); PostgreSQL (partially wired, commented out) |
| Logging | Serilog 7 |
| API documentation | Swashbuckle 6.5 (OpenAPI 2/3) |
| Validation | FluentValidation 11 |
| Mapping | AutoMapper 12 (with deprecated DI extensions package) |
| Frontend runtime | Node.js + Angular CLI 6 era workspace |
| Frontend framework | Angular (version inconsistent; partially upgraded dependencies) |
| UI libraries | Bootstrap 4, ngx-bootstrap, Font Awesome |
| Testing (backend) | MSTest, Moq, FluentAssertions, AutoFixture |
| Testing (frontend) | Karma/Jasmine (unit), Protractor (e2e, deprecated) |
| Containerisation | None |
| CI/CD | `.github/` present; pipeline details to be confirmed |

**Key pain points:** version skew across packages, deprecated tooling, no containerisation, unclear layer boundaries, low integration test coverage.

---

## 3. Proposed Target Architecture

The rewrite adopts a **Clean Architecture** (also known as Ports and Adapters / Hexagonal Architecture) layering model, with a clear separation of concerns between:

```
┌─────────────────────────────────────────────────┐
│                  Presentation                   │
│  Angular SPA  │  ASP.NET Core Web API (REST)    │
└─────────────────────────────────────────────────┘
                        │
┌─────────────────────────────────────────────────┐
│                  Application                    │
│  Use cases, commands, queries, validators,      │
│  DTOs, interfaces (ports)                       │
└─────────────────────────────────────────────────┘
                        │
┌─────────────────────────────────────────────────┐
│                    Domain                       │
│  Entities, value objects, domain events,        │
│  business rules — no external dependencies      │
└─────────────────────────────────────────────────┘
                        │
┌─────────────────────────────────────────────────┐
│                Infrastructure                   │
│  EF Core DbContext, repositories, external      │
│  services, Identity, JWT, email adapters        │
└─────────────────────────────────────────────────┘
```

The **domain layer** has no dependencies on any framework or infrastructure package. The **application layer** depends only on the domain. The **infrastructure layer** implements interfaces defined in the application layer. The **presentation layer** (API controllers and Angular components) depends on the application layer.

---

## 4. Backend Architecture

### 4.1 Target Runtime

- **.NET 8** (LTS) as the initial rewrite target, with a clear path to .NET 10.
- Minimal hosting model (`Program.cs` only; no `Startup.cs`).
- Kestrel as the default web server; configurable for reverse-proxy behind NGINX or a cloud load balancer.

### 4.2 Project Structure

```
src/
  MMOGardenTracker.Domain/          # Entities, value objects, domain events
  MMOGardenTracker.Application/     # Use cases, interfaces, DTOs, validators
  MMOGardenTracker.Infrastructure/  # EF Core, Identity, JWT, repositories
  MMOGardenTracker.Api/             # ASP.NET Core Web API, controllers, middleware
tests/
  MMOGardenTracker.Domain.Tests/
  MMOGardenTracker.Application.Tests/
  MMOGardenTracker.Infrastructure.Tests/
  MMOGardenTracker.Api.Tests/
  MMOGardenTracker.Integration.Tests/
```

### 4.3 Key Backend Packages (Target)

| Package | Version target | Notes |
|---|---|---|
| `Microsoft.NET.Sdk.Web` | net8.0 | SDK project |
| `Microsoft.EntityFrameworkCore.SqlServer` | 8.x | Primary provider |
| `Npgsql.EntityFrameworkCore.PostgreSQL` | 8.x | Alternative/optional |
| `Microsoft.AspNetCore.Identity.EntityFrameworkCore` | 8.x | Authentication |
| `Microsoft.AspNetCore.Authentication.JwtBearer` | 8.x | JWT |
| `Swashbuckle.AspNetCore` | 6.x current | OpenAPI docs |
| `Serilog.AspNetCore` | 8.x | Structured logging |
| `FluentValidation.AspNetCore` | 11.x current | Request validation |
| `AutoMapper` | 13.x | Remove deprecated DI extensions |
| `MediatR` | 12.x | CQRS command/query dispatch |

### 4.4 CQRS Pattern

The application layer uses **MediatR** for command/query separation:

- **Commands** mutate state (e.g. `CreateGardenCommand`, `RecordHarvestCommand`).
- **Queries** read state (e.g. `GetGardensByUserQuery`, `GetScheduleQuery`).
- API controllers are thin: they parse HTTP input, dispatch via MediatR, and return the result.

### 4.5 Authentication

- **ASP.NET Core Identity** manages user accounts and password hashing.
- **JWT Bearer** tokens are issued on login and validated on subsequent requests.
- Token claims include user ID and email; all data queries are filtered by the authenticated user ID.

---

## 5. Frontend Architecture

### 5.1 Target Runtime

- **Angular 21** (latest supported major at time of rewrite initiation).
- **Angular CLI** workspace with standalone components (no NgModules where avoidable).
- **TypeScript 5.x**.
- **Angular HttpClient** for API communication.

### 5.2 Project Structure

```
Website/
  src/
    app/
      core/           # Singleton services, interceptors, guards, auth
      shared/         # Shared components, pipes, directives
      features/
        auth/         # Login and registration pages
        dashboard/    # Overview and schedule view
        gardens/      # Garden list and detail
        plots/        # Plot management within a garden
        harvests/     # Harvest recording and history
    environments/     # environment.ts, environment.prod.ts
  angular.json
  tsconfig.json
```

### 5.3 Key Frontend Packages (Target)

| Package | Version target | Notes |
|---|---|---|
| `@angular/core` | 21.x | Core framework |
| `@angular/router` | 21.x | SPA routing |
| `@angular/forms` | 21.x | Reactive forms |
| `@angular/common/http` | 21.x | HTTP client |
| `rxjs` | 7.x | Reactive streams |
| `bootstrap` | 5.x | CSS framework (upgrade from 4) |
| `@ng-bootstrap/ng-bootstrap` | Latest compatible | Replace ngx-bootstrap |
| `@fortawesome/angular-fontawesome` | Latest compatible | Icons |
| `@playwright/test` | Latest | e2e testing (replace Protractor) |

### 5.4 State Management

For the initial rewrite, use **Angular services with RxJS `BehaviorSubject`** for local state. Introduce NgRx or Signals-based state only if complexity warrants it.

### 5.5 Testing (Frontend)

- **Unit tests:** Karma/Jasmine replaced by **Jest** (or Vitest) for faster, headless execution.
- **e2e tests:** Protractor replaced by **Playwright**.

---

## 6. Data Architecture

### 6.1 Database

- **SQL Server** remains the primary database for the rewrite (aligns with existing infrastructure).
- **PostgreSQL** support is maintained via Npgsql as a switchable provider using an environment variable.
- EF Core **code-first migrations** manage schema evolution.

### 6.2 Entity Model (Target)

```
User
  Id (GUID, PK)
  Email (unique)
  PasswordHash
  CreatedAt

Garden
  Id (GUID, PK)
  OwnerId (FK → User)
  Name
  Description (nullable)
  CreatedAt, UpdatedAt, DeletedAt (nullable, soft delete)

Plot
  Id (GUID, PK)
  GardenId (FK → Garden)
  CropName
  PlantedAt
  ExpectedHarvestAt
  Status (enum: Empty, Planted, ReadyToHarvest, Harvested)
  CreatedAt, UpdatedAt, DeletedAt (nullable, soft delete)

Harvest
  Id (GUID, PK)
  PlotId (FK → Plot)
  YieldQuantity (decimal)
  HarvestedAt
  CreatedAt
```

### 6.3 Data Access

- **Repository pattern** implemented in the infrastructure layer, with interfaces defined in the application layer.
- **Unit of Work** scoped per HTTP request via EF Core's `DbContext` lifetime.
- Global query filters applied for soft-deleted records.

---

## 7. API Design Principles

- RESTful resource-based URLs: `/api/v1/gardens/{gardenId}/plots/{plotId}/harvests`
- HTTP verbs used semantically: GET (read), POST (create), PUT (full update), PATCH (partial update), DELETE.
- All responses use **camelCase JSON**.
- Error responses conform to **RFC 7807 Problem Details** (`application/problem+json`).
- API versioning via URL path prefix (`/api/v1/`) using `Asp.Versioning`.
- All endpoints documented with **OpenAPI 3.x** via Swashbuckle with XML doc comments.

---

## 8. Security

- Passwords hashed with ASP.NET Core Identity's PBKDF2 implementation.
- JWT tokens signed with a configurable secret stored in environment variables or a secrets manager (not in `appsettings.json`).
- HTTPS enforced; HSTS configured in production.
- CORS restricted to known origins; wildcard CORS disabled in production.
- Input validated via FluentValidation before reaching the application layer.
- EF Core parameterised queries prevent SQL injection by default.
- Dependencies scanned for vulnerabilities in CI via `dotnet list package --vulnerable`.

---

## 9. Observability

- **Structured logging:** Serilog with `WriteTo.Console` (JSON in production) and optionally a remote sink (e.g. Seq, Application Insights).
- **Correlation IDs:** A middleware adds a `X-Correlation-Id` header to every request and includes it in all log entries.
- **Health checks:** `/health` endpoint using `Microsoft.Extensions.Diagnostics.HealthChecks` for database connectivity.
- **Metrics:** Basic request metrics via ASP.NET Core metrics middleware; extend with OpenTelemetry if required.

---

## 10. Testing Strategy

| Layer | Type | Tools | Target coverage |
|---|---|---|---|
| Domain | Unit | xUnit, FluentAssertions | ≥ 90 % |
| Application | Unit | xUnit, Moq/NSubstitute, FluentAssertions | ≥ 80 % |
| Infrastructure | Integration | xUnit, Testcontainers (SQL Server/Postgres) | Key data access paths |
| API | Integration | `WebApplicationFactory`, xUnit | All controller actions |
| Frontend | Unit | Jest | ≥ 70 % |
| Frontend | e2e | Playwright | Primary user flows |

---

## 11. Deployment Strategy

### 11.1 Local Development

- **Docker Compose** brings up the API, database (SQL Server or PostgreSQL), and Angular dev server.
- Single `docker-compose up` command for a fully functional local environment.

### 11.2 Production Deployment (Target)

- **API:** Containerised ASP.NET Core app published to a container registry and deployed to a container platform (Azure Container Apps, AWS ECS, or similar).
- **Frontend:** Angular build output deployed to a static hosting service (Azure Static Web Apps, S3 + CloudFront, or similar).
- **Database:** Managed SQL Server or PostgreSQL instance (Azure SQL, AWS RDS, or similar).
- **Migrations:** Run automatically on startup via `Database.MigrateAsync()` in a startup hook, or as a separate init container.

### 11.3 CI/CD Pipeline (GitHub Actions)

```
on: push to main / PR to main
jobs:
  backend-build-test:    dotnet restore → build → test → publish
  frontend-build-test:   npm ci → ng build → ng test
  docker-build:          Build and push container image
  deploy-staging:        Deploy to staging environment
  integration-test:      Run Playwright e2e against staging
  deploy-production:     Manual approval gate → deploy to production
```

---

## 12. Migration Strategy

### 12.1 Data Migration

- If an existing production database contains user data, write a one-time migration script that maps the old schema to the new entity model.
- Validate migrated data against domain invariants before cutover.

### 12.2 Parallel Running

- Run the rewritten application in a staging environment alongside the current application during validation.
- Compare API response parity for key endpoints using a test harness or Postman collection.

### 12.3 Cutover

- DNS/load-balancer cutover to the new application.
- Keep the old application in standby for one sprint before decommissioning.

---

## 13. Risks

| Risk | Likelihood | Impact | Mitigation |
|---|---|---|---|
| Feature parity gaps discovered late | Medium | High | Complete the discovery checklist before coding begins |
| EF Core migration conflicts | Low | Medium | Squash all existing migrations; start fresh from a clean baseline |
| Angular upgrade difficulty | High | Medium | Spike Angular upgrade separately before integrating into rewrite |
| JWT secret management in CI/CD | Medium | High | Use GitHub Secrets / cloud secrets manager; never commit secrets |
| Performance regression from CQRS overhead | Low | Low | Benchmark critical endpoints; optimise only if thresholds are breached |

---

## 14. Decisions to Finalize

- [ ] Confirm .NET 8 vs. .NET 10 as the rewrite target framework.
- [ ] Confirm SQL Server vs. PostgreSQL as the primary database provider.
- [ ] Confirm whether ASP.NET Core Identity is used for auth or an external IdP.
- [ ] Confirm Angular 21 as the frontend target or evaluate Blazor as an alternative.
- [ ] Confirm Jest vs. Karma as the Angular unit test runner.
- [ ] Confirm deployment platform (Azure, AWS, self-hosted).
- [ ] Confirm whether an OpenTelemetry collector is required from day one.
- [ ] Decide on the feature-flag strategy for phased rollout if applicable.
