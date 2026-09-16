# Senior Engineer Code Review Checklist

## Logic & Correctness
- [ ] Does the code actually do what it's supposed to do?
- [ ] Are there any obvious edge cases not handled?
- [ ] Is error handling robust? (e.g., catching specific exceptions, proper logging)
- [ ] Are there potential race conditions or concurrency issues?

## Architecture & Design
- [ ] Does the change align with the project's architectural patterns (e.g., Clean Architecture, DDD)?
- [ ] Is there proper separation of concerns?
- [ ] Are dependencies handled correctly (DI)?
- [ ] Is the code DRY (Don't Repeat Yourself)?
- [ ] Is it KISS (Keep It Simple, Stupid)?
- [ ] Does it follow SOLID principles?

## Security
- [ ] Is user input validated/sanitized?
- [ ] Are there any potential injection vulnerabilities (SQL, NoSQL, command)?
- [ ] Are secrets or sensitive data leaked?
- [ ] Is authentication/authorization handled correctly?

## Performance
- [ ] Are there any obvious performance bottlenecks (e.g., N+1 queries, inefficient loops)?
- [ ] Is memory usage reasonable?
- [ ] Are resources (DB connections, file handles) properly disposed?

## Readability & Maintainability
- [ ] Are names descriptive and consistent?
- [ ] Is the code easy to understand without excessive comments?
- [ ] Are comments helpful and up-to-date?
- [ ] Is the code formatted according to project standards?

## Testing
- [ ] Are there sufficient unit/integration tests?
- [ ] Do the tests cover edge cases and error paths?
- [ ] Is the code coverage adequate for the change?
