# AGENTS.md

This file documents the current migration assumptions and working conventions
for this repository so work can continue cleanly on another machine.

**Primary Goal**

Modernize the repository from old Visual Studio / Mono-era `.NET Framework`
projects to current SDK-style `.NET` projects that build with the `dotnet` CLI
on macOS.

**Required Tooling**

- `.NET SDK 10.x`
- network access for `dotnet restore` when package restore is needed

Optional:

- `git`
- VS Code, Rider, or Visual Studio

Notes:

- `Mono` is no longer the preferred toolchain for migrated projects.
- a standalone `nuget` CLI is not required; use `dotnet restore`.

**Build System Decision**

Do not add per-project `Makefile`s.

Use the native `.NET` build stack:

- SDK-style `.csproj`
- top-level solution
- `Directory.Build.props`
- `Directory.Packages.props`
- `dotnet build`
- `dotnet test`

If a convenience wrapper is ever added later, it should be a thin wrapper over
the native `dotnet` commands, not a parallel build system.

**Current Modern Entry Points**

- modern solution: `examples-modern-cli.sln`
- shared build settings: `Directory.Build.props`
- shared package versions: `Directory.Packages.props`

**Migration Order**

1. Convert simple standalone console examples first.
2. Convert object-oriented examples next.
3. Convert file I/O examples after that.
4. Convert test-bearing examples into separate `*.Tests` projects.
5. Leave intentional assignment stubs for a separate pass.

**Project Conventions**

For migrated projects:

- target `net10.0`
- use SDK-style `.csproj`
- keep `GenerateAssemblyInfo` disabled because the repo still carries historical
  `Properties/AssemblyInfo.cs` files
- keep `Deterministic` disabled for now because many legacy `AssemblyInfo.cs`
  files use wildcard versions such as `1.0.*`

If and when the repo is cleaned up further, those two compatibility settings can
be revisited.

**Testing Conventions**

- keep example executables and unit tests in separate projects
- use sibling test projects such as `ProjectName.Tests`
- use NUnit unless there is a deliberate repo-wide decision to switch
- run tests with `dotnet test`

Current example:

- app: `cmdline_to_file/cmdline_to_file.csproj`
- tests: `cmdline_to_file.Tests/cmdline_to_file.Tests.csproj`

**When Converting a Project**

1. Replace the old legacy `.csproj` with an SDK-style project.
2. Preserve the original source code structure unless a small compatibility fix
   is needed.
3. Add the project to `examples-modern-cli.sln`.
4. Run `dotnet restore` on the project or solution.
5. Run `dotnet build`.
6. If the project has tests, move them into a separate test project and run
   `dotnet test`.

**Batching Guidance**

Do not convert the whole repo in one pass.

Preferred batch size:

- around 15 to 25 projects at a time

This keeps verification manageable and makes it easier to isolate edge cases.

**What to Defer**

Do not mix these into the simple-console batches unless necessary:

- projects with `ProjectReference` dependencies on other still-legacy examples
- object-oriented examples with reusable types
- file I/O examples that may need data-file handling updates
- `*_stub` projects
- older embedded-test projects

**README Expectations**

The README should describe the repo in its current transitional state:

- required tools
- how to build the migrated solution
- how to run a migrated example
- how to run a migrated test project
- the fact that not all legacy projects are converted yet

**Important Current Files**

- `README.md`
- `AGENTS.md`
- `examples-modern-cli.sln`
- `Directory.Build.props`
- `Directory.Packages.props`

**Immediate Next Step**

Continue converting the remaining simple standalone console examples in batches,
while skipping examples that still depend on unmigrated support projects.
