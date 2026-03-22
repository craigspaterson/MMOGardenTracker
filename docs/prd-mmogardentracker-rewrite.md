# Product Requirements Document
## MMOGardenTracker — Rewrite

**Version:** 1.0 (Draft)  
**Date:** 2026-03-22  
**Status:** Draft for review

---

## 1. Overview

MMOGardenTracker is a full-stack web application that helps players of massively multiplayer online (MMO) games track in-game gardening activities — planting schedules, crop yields, harvests, and resource management. The current implementation uses an ASP.NET Core Web API backend (.NET 6), an Angular frontend, Entity Framework Core with SQL Server, and Serilog for structured logging.

The rewrite aims to modernise the entire stack, establish a clean architecture baseline, and produce a maintainable, testable application that can be extended with AI-assisted development.

---

## 2. Problem Statement

The current codebase has accumulated technical debt across several dimensions:

- **Backend:** Targets .NET 6 (out of support), uses mixed EF Core versions, and retains deprecated dependency registrations (e.g. `AutoMapper.Extensions.Microsoft.DependencyInjection`).
- **Frontend:** The Angular application was generated with Angular CLI 6 and contains inconsistent package versions, legacy tooling (Protractor), and outdated build configuration.
- **No containerisation:** The application has no Docker or container configuration, making environment parity difficult.
- **Limited test coverage:** Unit tests exist but coverage is uneven; no integration or contract tests are present.
- **Unclear domain model:** The boundary between domain logic, data access, and HTTP concerns is not consistently enforced.

These issues make the system difficult to upgrade, extend, and confidently deploy.

---

## 3. Goals

1. Deliver a fully functional MMOGardenTracker application on a modern, supported technology stack.
2. Apply clean architecture principles to create clear separation between domain, application, infrastructure, and presentation layers.
3. Achieve high unit-test and integration-test coverage to support ongoing AI-assisted development.
4. Provide an OpenAPI-documented REST API that accurately reflects the domain.
5. Support containerised deployment from day one.
6. Establish a frontend on a currently supported Angular version with a coherent, upgradeable dependency tree.

---

## 4. Non-Goals

- Migrating to a different backend language (the rewrite remains .NET / C#).
- Building a mobile application.
- Adding game-integration APIs or live data ingestion pipelines (deferred to a later release).
- Designing for multi-tenancy or enterprise-scale load (initial target is personal/small-group use).

---

## 5. Target Users

| Persona | Description |
|---|---|
| **Casual farmer** | An MMO player who wants a simple way to log what they have planted and when to harvest. |
| **Hardcore tracker** | A player who manages multiple gardens across multiple characters and needs detailed yield data and scheduling. |
| **Guild officer** | A player coordinating multiple members' gardening contributions to a shared goal. |

---

## 6. User Needs

- **Track gardens:** Create and manage multiple named gardens associated with a game character or account.
- **Manage plots:** Within a garden, track individual plots with planted crop, planting date, expected harvest date, and status.
- **Record harvests:** Log completed harvests against a plot, capturing yield quantity and actual harvest date.
- **View schedules:** See upcoming harvest deadlines sorted by date so nothing is missed.
- **Review history:** Access a historical view of all past plantings and harvests per garden.
- **Simple authentication:** Register and log in to keep personal data private.

---

## 7. Functional Requirements

### 7.1 Authentication and Authorisation

- FR-AUTH-01: Users must be able to register with an email address and password.
- FR-AUTH-02: Users must be able to log in and receive a JWT token for subsequent requests.
- FR-AUTH-03: All garden, plot, and harvest data must be scoped to the authenticated user.
- FR-AUTH-04: Unauthenticated requests to protected endpoints must return HTTP 401.

### 7.2 Gardens

- FR-GARDEN-01: A user can create a garden with a name and optional description.
- FR-GARDEN-02: A user can list all their gardens.
- FR-GARDEN-03: A user can update a garden's name and description.
- FR-GARDEN-04: A user can delete a garden; all associated plots and harvests are also deleted.

### 7.3 Plots

- FR-PLOT-01: A user can create a plot within a garden, specifying crop name, planting date, and expected harvest date.
- FR-PLOT-02: A user can list all plots within a garden.
- FR-PLOT-03: A user can update a plot's crop, dates, or status.
- FR-PLOT-04: A user can delete a plot.
- FR-PLOT-05: Plot status values are: `Empty`, `Planted`, `ReadyToHarvest`, `Harvested`.

### 7.4 Harvests

- FR-HARVEST-01: A user can record a harvest against a plot, capturing yield quantity and actual harvest date.
- FR-HARVEST-02: Recording a harvest automatically sets the associated plot status to `Harvested`.
- FR-HARVEST-03: A user can list all harvests for a given garden.

### 7.5 Schedule View

- FR-SCHEDULE-01: A user can retrieve a list of plots with status `Planted` or `ReadyToHarvest`, sorted by expected harvest date ascending.

---

## 8. Non-Functional Requirements

| ID | Category | Requirement |
|---|---|---|
| NFR-01 | Performance | API responses for list endpoints must return within 500 ms at p95 under expected load. |
| NFR-02 | Security | All passwords must be hashed using ASP.NET Core Identity's default PBKDF2 algorithm. |
| NFR-03 | Security | JWT tokens must expire after a configurable duration (default 1 hour). |
| NFR-04 | Observability | All requests must be logged with a correlation ID using Serilog structured logging. |
| NFR-05 | Reliability | The API must return meaningful error responses (RFC 7807 problem details) for all 4xx and 5xx responses. |
| NFR-06 | Maintainability | Unit test coverage for domain and application layers must be ≥ 80 %. |
| NFR-07 | Portability | The application must be runnable via Docker Compose for local development. |
| NFR-08 | Accessibility | The Angular frontend must meet WCAG 2.1 Level AA for all primary user flows. |

---

## 9. Data Requirements

- DR-01: User accounts must store email (unique), hashed password, and created-at timestamp.
- DR-02: Gardens must store name, optional description, owner user ID, and created/updated timestamps.
- DR-03: Plots must store garden ID, crop name, planting date, expected harvest date, status, and created/updated timestamps.
- DR-04: Harvests must store plot ID, yield quantity, actual harvest date, and created timestamp.
- DR-05: All entities must use GUID primary keys.
- DR-06: Soft delete must be implemented for Gardens and Plots (logical deletion with `DeletedAt` timestamp).

---

## 10. API Requirements

- API-01: The API must conform to REST conventions and be versioned under `/api/v1/`.
- API-02: All endpoints must be documented with OpenAPI 3.x via Swashbuckle.
- API-03: Request and response bodies must use JSON (camelCase property names).
- API-04: Validation errors must return HTTP 422 with a structured error body.
- API-05: The API must support CORS for the Angular SPA origin in development and production configurations.

---

## 11. UX Requirements

- UX-01: The Angular SPA must display a dashboard showing upcoming harvests and a summary of active gardens.
- UX-02: All forms must show inline validation feedback before submission.
- UX-03: The application must be responsive and usable on tablet and desktop viewports.
- UX-04: Navigation must be consistent across all pages with a top-level nav bar.
- UX-05: Loading states must be indicated with a spinner or skeleton UI element.

---

## 12. Success Metrics

| Metric | Target |
|---|---|
| Feature parity with existing application | 100 % of documented features implemented |
| Unit test coverage (domain + application) | ≥ 80 % |
| API response time (p95) | < 500 ms |
| Build and test pipeline duration | < 10 minutes |
| Zero critical or high security advisories | Verified by dependency scanning |

---

## 13. Open Questions

- [ ] Should the rewrite support multiple game titles explicitly, or remain game-agnostic?
- [ ] Is there an existing user base whose data must be migrated from the current database?
- [ ] Should the Angular frontend be replaced with a different framework (e.g. Blazor), or is Angular the confirmed target?
- [ ] Is PostgreSQL the preferred database for the rewrite, or does SQL Server remain?
- [ ] Should authentication be handled internally (ASP.NET Core Identity) or via an external provider (e.g. Auth0, Entra ID)?
- [ ] Is a mobile-responsive web app sufficient, or is a PWA capability required?

---

## 14. Release Scope Proposal

### Phase 1 — Foundation (Rewrite MVP)
- Authentication (register, login, JWT)
- Gardens CRUD
- Plots CRUD with status management
- Harvests recording
- Schedule view
- OpenAPI documentation
- Docker Compose for local development

### Phase 2 — Quality and Polish
- Integration tests for all API endpoints
- Angular e2e tests with Playwright
- WCAG 2.1 AA audit and fixes
- CI/CD pipeline with automated tests and deployment

### Phase 3 — Extensions (Post-rewrite)
- Game-specific templates for common crop types
- Guild/shared garden view
- Notifications for upcoming harvests
- Data export (CSV/JSON)
