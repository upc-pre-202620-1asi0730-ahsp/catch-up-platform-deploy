# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and this project intends to adhere to [Semantic Versioning](https://semver.org/spec/v2.0.0.html) once versioned releases are tagged.

## [1.1.0] - 2026-10-16

### Added

- Favorite sources REST API under `/api/v1/favorite-sources`: create, get by id, and list or look up by `newsApiKey` (and optionally `sourceId`).
- `409 Conflict` response when creating a duplicate `newsApiKey` + `sourceId` favorite, backed by a unique database index.
- Localization (`en`, `en-US`, `es`, `es-PE`) for error responses, validation messages, and API descriptions, selected through the request culture.
- Localized validation messages and a localized `400 Bad Request` `ProblemDetails` response for invalid input.
- Localized OpenAPI operation, response, and schema descriptions.
- Value objects `NewsApiKey` and `SourceId` with validation rules.
- `NewsApiKey.MaskedForLogging()` (instance and static) to keep API keys out of logs.
- `Result<TValue, TError>` pattern for expected operation outcomes.
- Automatic `CreatedAt` / `UpdatedAt` audit timestamps through a custom EF Core interceptor.
- Initial EF Core migration for the `favorite_sources` table; migrations are applied on startup.
- Scalar API reference at `/scalar` and the OpenAPI document at `/openapi/v1.json`.
- Docker, AWS App Runner (`apprunner.yaml`), and `global.json` build and deployment configuration.
- Documentation: README, class diagram, technical user stories, architecture decision records (`docs/adrs.md`), and MIT license.

### Changed

- Upgraded to .NET 10 and C# 14, and updated dependencies (including Entity Framework Core).
- Replaced the external audit package with an in-house interceptor.
- Replaced Swashbuckle (Swagger UI) with the built-in ASP.NET Core OpenAPI support and Scalar.
- Centralized unexpected-error handling through `ProblemDetails` and the exception handler.
- Domain, repositories, queries, commands, and the controller now use value objects instead of raw strings.
- Async repository, unit of work, service, and controller methods accept a `CancellationToken`.
- Reorganized the code into bounded contexts (`News`, `Shared`) with layered folders and assemblers under `Interfaces/REST/Transform`.
- `Program.cs` request localization now runs before OpenAPI so generated documentation follows the request culture.
- The Scalar and OpenAPI endpoints are served in every environment, as Swagger UI was before.

### Fixed

- Requests with an empty `sourceId` query parameter are rejected instead of being treated as a filter.
- Requested cancellation is now propagated instead of being swallowed.

### Removed

- Swashbuckle packages and `Swagger*` annotations and filters.

### Security

- News API keys are masked in all log statements of the favorite source command service and controller.
