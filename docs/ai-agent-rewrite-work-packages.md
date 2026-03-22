# AI-Agent Rewrite Work Packages
## MMOGardenTracker — Structured Rewrite Plan

**Version:** 1.0 (Draft)  
**Date:** 2026-03-22  
**Status:** Ready for agent assignment

This document breaks the MMOGardenTracker rewrite into discrete, AI-agent-friendly work packages. Each work package has a clear input, a concrete deliverable, and an acceptance criterion that can be verified without ambiguity.

---

## Phases Overview

| Phase | Name | Goal |
|---|---|---|
| 1 | Discovery | Extract full understanding of the current system |
| 2 | Product Definition | Finalise PRD and architecture decisions |
| 3 | Foundation | Scaffold the rewritten solution with build, test, and CI pipelines |
| 4 | Core Features | Implement all functional requirements from the PRD |
| 5 | Hardening | Testing, security, observability, and performance |
| 6 | Cutover | Migration, parallel running, and production deployment |

---

## Phase 1 — Discovery

### WP-1.1: Repository Audit

**Input:** Current repository at `craigspaterson/MMOGardenTracker`  
**Task:** Work through the legacy system discovery checklist (`docs/legacy-system-discovery-checklist.md`) and produce a completed checklist with findings filled in for every item.  
**Deliverable:** A completed `docs/discovery-findings.md` document.  
**Acceptance:** Every checklist item is answered with a concrete finding, "N/A", or a documented assumption.

---

### WP-1.2: API Surface Extraction

**Input:** Repository source code; Postman collection in `postman/`  
**Task:** Extract all existing API endpoints, HTTP methods, request/response shapes, and status codes. Produce a structured endpoint catalogue.  
**Deliverable:** `docs/existing-api-catalogue.md` with one entry per endpoint.  
**Acceptance:** Every controller action in `WebService/GT.Web.Api/Controllers/` is represented.

---

### WP-1.3: Database Schema Extraction

**Input:** EF Core `DbContext`, entity classes, and migrations in `Domain/GT.Domain/`  
**Task:** Reverse-engineer the current database schema and document every table, column, data type, primary key, foreign key, and index.  
**Deliverable:** `docs/existing-schema.md` with an entity-relationship summary.  
**Acceptance:** Schema matches what EF Core migrations would produce at the current HEAD.

---

### WP-1.4: Angular Feature Audit

**Input:** `Website/src/` directory  
**Task:** List every Angular module, component, service, and route. Map each UI feature to its API dependency.  
**Deliverable:** `docs/existing-frontend-features.md`  
**Acceptance:** All modules and components in `app/` are listed with their primary responsibility and API calls.

---

## Phase 2 — Product Definition

### WP-2.1: PRD Finalisation

**Input:** `docs/prd-mmogardentracker-rewrite.md`, `docs/discovery-findings.md`, `docs/existing-api-catalogue.md`  
**Task:** Update the PRD to resolve all open questions identified during discovery. Add, remove, or refine requirements based on actual system behaviour.  
**Deliverable:** Updated `docs/prd-mmogardentracker-rewrite.md` with all open questions resolved.  
**Acceptance:** No open questions remain marked `[ ]`; all functional requirements are traceable to a discovered feature or a deliberate decision to add/remove.

---

### WP-2.2: Architecture Decisions Finalisation

**Input:** `docs/architecture-mmogardentracker-rewrite.md`, PRD, discovery findings  
**Task:** Resolve all items listed in Section 14 ("Decisions to Finalize") of the architecture document. Record the decision and rationale for each.  
**Deliverable:** Updated `docs/architecture-mmogardentracker-rewrite.md` with all decision items resolved.  
**Acceptance:** No decision item remains unresolved; each has a decision and a one-sentence rationale.

---

## Phase 3 — Foundation

### WP-3.1: Backend Solution Scaffold

**Input:** Architecture document (finalised)  
**Task:** Create a new .NET 8 solution with the following projects: `Domain`, `Application`, `Infrastructure`, `Api`, and corresponding test projects. Configure the project structure, package references, and inter-project dependencies as specified in the architecture document.  
**Deliverable:** A compiling, empty solution with all projects referencing each other correctly.  
**Acceptance:** `dotnet build` succeeds with zero errors and zero warnings; `dotnet test` finds and runs (zero) tests.

---

### WP-3.2: Database and EF Core Setup

**Input:** WP-3.1 output; target schema from `docs/existing-schema.md` (or redesigned schema per PRD)  
**Task:** Implement the `DbContext`, all entity configurations, and create an initial EF Core migration. Configure both SQL Server and PostgreSQL providers, switchable via environment variable.  
**Deliverable:** Runnable migration that creates the target schema. `docker-compose up` starts a database and `dotnet ef database update` applies the migration.  
**Acceptance:** Migration applies cleanly; all tables exist with correct columns and constraints.

---

### WP-3.3: CI/CD Pipeline

**Input:** GitHub Actions; architecture document (deployment strategy)  
**Task:** Create GitHub Actions workflows for: (a) backend build and test, (b) frontend build and test, (c) Docker image build and push.  
**Deliverable:** `.github/workflows/backend.yml`, `.github/workflows/frontend.yml`, `.github/workflows/docker.yml`  
**Acceptance:** All three workflows pass on the `main` branch; a failing test causes the pipeline to fail.

---

### WP-3.4: Docker Compose Local Environment

**Input:** Architecture document  
**Task:** Create a `docker-compose.yml` that starts the API, a SQL Server container, and the Angular dev server. Create a `Dockerfile` for the API.  
**Deliverable:** `docker-compose.yml`, `Dockerfile` at the repository root.  
**Acceptance:** `docker-compose up` starts all services; the API health check endpoint returns 200; the Angular app loads in a browser.

---

### WP-3.5: Frontend Scaffold

**Input:** Architecture document; PRD UX requirements  
**Task:** Create a new Angular 21 workspace with the folder structure specified in the architecture document. Configure routing, HTTP client, and environment files. Remove all legacy tooling (Protractor, Karma if replaced by Jest).  
**Deliverable:** A compiling Angular application with placeholder routes for all feature areas.  
**Acceptance:** `ng build` succeeds; `ng serve` starts and the app loads in a browser with no console errors.

---

## Phase 4 — Core Features

### WP-4.1: Authentication — Backend

**Input:** PRD FR-AUTH-01 to FR-AUTH-04; architecture auth section  
**Task:** Implement user registration and login endpoints using ASP.NET Core Identity and JWT Bearer. Include input validation (FluentValidation) and tests.  
**Deliverable:** `/api/v1/auth/register` and `/api/v1/auth/login` endpoints; unit and integration tests.  
**Acceptance:** Registration creates a user; login returns a valid JWT; protected endpoints return 401 without a token; unit test coverage ≥ 80 % for the auth use cases.

---

### WP-4.2: Authentication — Frontend

**Input:** WP-4.1 API; PRD UX requirements  
**Task:** Implement Angular registration and login forms. Store the JWT in memory (not localStorage). Add an HTTP interceptor to attach the token to all API requests. Add a route guard for authenticated routes.  
**Deliverable:** Working login and registration flows; authenticated routes redirect unauthenticated users to login.  
**Acceptance:** A user can register, log in, and access protected pages; logging out clears the token and redirects to login.

---

### WP-4.3: Gardens — Backend

**Input:** PRD FR-GARDEN-01 to FR-GARDEN-04; architecture data model  
**Task:** Implement the `Garden` entity, repository, application use cases (CQRS commands and queries), and API controller. Include soft delete and user-scoping. Include tests.  
**Deliverable:** CRUD endpoints for gardens; unit and integration tests.  
**Acceptance:** All CRUD operations work; a user cannot access another user's gardens (returns 404); soft delete sets `DeletedAt`; tests pass.

---

### WP-4.4: Plots — Backend

**Input:** PRD FR-PLOT-01 to FR-PLOT-05; architecture data model  
**Task:** Implement the `Plot` entity, repository, application use cases, and API controller nested under gardens. Include status transitions and validation. Include tests.  
**Deliverable:** CRUD endpoints for plots; unit and integration tests.  
**Acceptance:** Status transitions are enforced (cannot set `Harvested` without a harvest record); tests pass.

---

### WP-4.5: Harvests — Backend

**Input:** PRD FR-HARVEST-01 to FR-HARVEST-03; architecture data model  
**Task:** Implement the `Harvest` entity, repository, application use cases, and API controller. Recording a harvest must update the associated plot status to `Harvested`. Include tests.  
**Deliverable:** Harvest creation and list endpoints; unit and integration tests.  
**Acceptance:** Creating a harvest sets the plot status; tests pass.

---

### WP-4.6: Schedule View — Backend

**Input:** PRD FR-SCHEDULE-01  
**Task:** Implement a query that returns plots with status `Planted` or `ReadyToHarvest` for the authenticated user, sorted by `ExpectedHarvestAt` ascending.  
**Deliverable:** `GET /api/v1/schedule` endpoint; unit and integration tests.  
**Acceptance:** Response is sorted correctly; only the current user's plots are returned; tests pass.

---

### WP-4.7: Gardens, Plots, and Harvests — Frontend

**Input:** WP-4.3, WP-4.4, WP-4.5, WP-4.6 APIs; PRD UX requirements  
**Task:** Implement Angular feature modules for gardens, plots, and harvests. Include list views, detail views, and forms. Display inline validation errors. Implement the schedule view on the dashboard.  
**Deliverable:** All primary UI flows working end-to-end against the rewritten API.  
**Acceptance:** A user can complete the full workflow (register → create garden → add plots → record harvest → view schedule) without errors.

---

## Phase 5 — Hardening

### WP-5.1: Integration Test Suite

**Input:** All Phase 4 backend work packages  
**Task:** Write integration tests for all API endpoints using `WebApplicationFactory` and Testcontainers. Cover success paths, validation errors, authorisation failures, and not-found cases.  
**Deliverable:** `MMOGardenTracker.Integration.Tests` project with tests for every controller action.  
**Acceptance:** All tests pass in CI; coverage for the API layer ≥ 80 %.

---

### WP-5.2: Frontend Unit and e2e Tests

**Input:** All Phase 4 frontend work packages  
**Task:** Write Jest unit tests for all Angular services and key components. Write Playwright e2e tests for the primary user flows (register, login, create garden, add plot, record harvest, view schedule).  
**Deliverable:** Jest tests alongside components/services; Playwright tests in `e2e/`.  
**Acceptance:** All unit tests pass; all Playwright flows pass in CI.

---

### WP-5.3: Security Review

**Input:** Completed codebase  
**Task:** Run `dotnet list package --vulnerable` and `npm audit`. Resolve all high and critical advisories. Review JWT configuration (expiry, signing key strength, HTTPS enforcement). Verify CORS is restricted. Verify no secrets are committed.  
**Deliverable:** Security review findings document; all high/critical advisories resolved.  
**Acceptance:** `dotnet list package --vulnerable --highest-severity` shows no high or critical; `npm audit --audit-level=high` exits with 0.

---

### WP-5.4: Observability Setup

**Input:** Architecture observability section  
**Task:** Configure Serilog with JSON console output and a correlation-ID middleware. Add a `/health` endpoint with database connectivity check. Document how to view logs locally.  
**Deliverable:** Working health endpoint; all requests logged with correlation ID; `README.md` section on observability.  
**Acceptance:** `GET /health` returns 200 when the database is reachable and 503 when it is not; log entries include `CorrelationId`.

---

### WP-5.5: Performance Baseline

**Input:** Completed API  
**Task:** Run a basic load test against the schedule and garden list endpoints using `k6` or `dotnet-load-test`. Document p50, p95, and p99 response times.  
**Deliverable:** `docs/performance-baseline.md` with results.  
**Acceptance:** p95 response time for list endpoints is under 500 ms at a load of 10 concurrent users.

---

## Phase 6 — Cutover

### WP-6.1: Data Migration Script

**Input:** `docs/existing-schema.md`; target schema  
**Task:** Write a one-time SQL or C# migration script that maps data from the old schema to the new schema. Include a dry-run mode that reports what would be changed without modifying data.  
**Deliverable:** Migration script in `scripts/migrate-data.sql` or `scripts/MigrateData.cs`.  
**Acceptance:** Dry-run reports all rows to be migrated; full run migrates data with no constraint violations.

---

### WP-6.2: Parallel Validation

**Input:** Old and new applications running in staging  
**Task:** Execute the Postman collection from `postman/` against both the old and new APIs and compare responses for all documented endpoints.  
**Deliverable:** Comparison report documenting any differences.  
**Acceptance:** All responses are functionally equivalent or differences are documented and accepted as intentional changes.

---

### WP-6.3: Production Deployment and Cutover

**Input:** All previous phases complete; deployment platform confirmed  
**Task:** Deploy the rewritten application to production. Execute the data migration script. Switch DNS or load-balancer routing to the new application.  
**Deliverable:** Production application running on the rewritten stack.  
**Acceptance:** All primary user flows work in production; health check returns 200; error rate is within acceptable thresholds for 24 hours post-cutover.

---

## Suggested AI-Agent Assignment Model

| Work Package | Suggested Agent Role |
|---|---|
| WP-1.x Discovery | **Explorer agent** — reads code, produces structured documentation |
| WP-2.x Definitions | **Analyst agent** — reasons over discovery findings, resolves open questions |
| WP-3.x Foundation | **Scaffolding agent** — generates boilerplate, configures tooling |
| WP-4.x Features | **Coder agent** — implements features against spec, writes tests in parallel |
| WP-5.x Hardening | **QA/security agent** — writes tests, runs scans, documents findings |
| WP-6.x Cutover | **DevOps agent** — executes migration and deployment steps |

Each work package should be treated as a single atomic unit of work: one agent, one PR, one review cycle.

---

## Recommended Next Step

Before any code is written, complete **Phase 1 — Discovery** in full. The quality of every subsequent work package depends on the accuracy of the discovery findings. Specifically:

1. Run WP-1.1 (Repository Audit) using the `docs/legacy-system-discovery-checklist.md`.
2. Run WP-1.2, WP-1.3, and WP-1.4 in parallel once WP-1.1 is complete.
3. Only after all four discovery work packages are done should an agent begin WP-2.1 (PRD Finalisation).

This sequencing ensures that the rewrite is grounded in the actual behaviour of the existing system and that no requirements are accidentally lost or invented.
