Introductory C# Examples
========================

This repository contains a large collection of small C# teaching examples. The
repo is currently being migrated from older Visual Studio / Mono-era project
files to modern SDK-style `.NET` projects.

At the moment, the recommended build path is the modern one:

- use the `dotnet` CLI
- use SDK-style `.csproj` files
- use the top-level modern solution
- use `dotnet build` and `dotnet test`

The old `examples.sln` is still present for historical reference during the
migration, but it is not the recommended build entry point on macOS.

**Assumptions**

You should have the following tools installed:

- `.NET SDK 10.x`
- network access for `dotnet restore` when NuGet packages are needed

Optional tools:

- `git`
- an editor or IDE such as VS Code, Rider, or Visual Studio

You do not need a separate `nuget` CLI for normal work in this repo.
`dotnet restore` handles NuGet package restore.

You do not need `Mono` for the migrated projects.

**Repository Status**

The modern solution is currently:

- [examples-modern-cli.sln](/Volumes/Work/introcs-csharp-examples/examples-modern-cli.sln:1)

Shared modern build configuration lives in:

- [Directory.Build.props](/Volumes/Work/introcs-csharp-examples/Directory.Build.props:1)
- [Directory.Packages.props](/Volumes/Work/introcs-csharp-examples/Directory.Packages.props:1)

Only part of the repo has been migrated so far. Migrated examples build with
the current `.NET` SDK on macOS. Legacy examples will be converted in batches.

**Build**

Restore and build the migrated solution:

```bash
dotnet restore examples-modern-cli.sln
dotnet build examples-modern-cli.sln --no-restore
```

Example output:

```text
  addition1 -> /Volumes/Work/introcs-csharp-examples/addition1/bin/Debug/net10.0/addition1.dll
  contact1 -> /Volumes/Work/introcs-csharp-examples/contact1/bin/Debug/net10.0/contact1.dll
  cmdline_to_file -> /Volumes/Work/introcs-csharp-examples/cmdline_to_file/bin/Debug/net10.0/cmdline_to_file.dll
  cmdline_to_file.Tests -> /Volumes/Work/introcs-csharp-examples/cmdline_to_file.Tests/bin/Debug/net10.0/cmdline_to_file.Tests.dll
  ...

Build succeeded.
    0 Warning(s)
    0 Error(s)
```

You can also restore and build a single migrated example directly:

```bash
dotnet restore addition1/addition1.csproj
dotnet build addition1/addition1.csproj --no-restore
```

**Run Examples Without Unit Tests**

For a migrated console example, use `dotnet run --project`.

Example:

```bash
dotnet run --project addition1/addition1.csproj
```

If the example expects console input, provide it interactively. Verified sample
session:

```text
The sum of 2 and 3 is 5.
The sum of 12345 and 53579 is 65924.
Enter an integer: 7
Enter another integer: 8
The sum of 7 and 8 is 15.
```

Another example with no interactive input:

```bash
dotnet run --project contact1/contact1.csproj
```

Verified output:

```text
Marie's full name: Marie Ortiz
Her phone number: 773-508-7890
Her email: mortiz2@luc.edu

Full contact info for Otto:
Name:  Otto Heinz
Phone: 773-508-9999
Email: oheinz@luc.edu
```

**Run Examples With Unit Tests**

Examples that have unit tests should use a separate test project named
`ProjectName.Tests` where practical.

Current NUnit example:

- app project: [cmdline_to_file/cmdline_to_file.csproj](/Volumes/Work/introcs-csharp-examples/cmdline_to_file/cmdline_to_file.csproj:1)
- test project: [cmdline_to_file.Tests/cmdline_to_file.Tests.csproj](/Volumes/Work/introcs-csharp-examples/cmdline_to_file.Tests/cmdline_to_file.Tests.csproj:1)

Run the tests with:

```bash
dotnet restore cmdline_to_file.Tests/cmdline_to_file.Tests.csproj
dotnet test cmdline_to_file.Tests/cmdline_to_file.Tests.csproj --no-restore
```

Verified output:

```text
  cmdline_to_file -> /Volumes/Work/introcs-csharp-examples/cmdline_to_file/bin/Debug/net10.0/cmdline_to_file.dll
  cmdline_to_file.Tests -> /Volumes/Work/introcs-csharp-examples/cmdline_to_file.Tests/bin/Debug/net10.0/cmdline_to_file.Tests.dll
Test run for /Volumes/Work/introcs-csharp-examples/cmdline_to_file.Tests/bin/Debug/net10.0/cmdline_to_file.Tests.dll (.NETCoreApp,Version=v10.0)
A total of 1 test files matched the specified pattern.
Usage: cmdline_to_file <output-file> <contents>

Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 4 ms - cmdline_to_file.Tests.dll (net10.0)
```

**Migration Conventions**

The repo is being migrated in this order:

1. Simple standalone console examples.
2. Object-oriented examples.
3. File I/O examples.
4. Test-bearing examples with separate `*.Tests` projects.
5. Intentional assignment stubs in a separate pass.

General conventions for migrated projects:

- use SDK-style `.csproj`
- use the shared root props/package files
- do not introduce `Makefile`-based builds
- prefer `dotnet restore`, `dotnet build`, and `dotnet test`
- keep tests in dedicated test projects instead of compiling test code into the
  example executable

**Legacy Projects**

Many projects in the repo are still legacy `.NET Framework` / Mono-era
projects. Those are in the process of being converted. Until a project has been
modernized, assume that:

- it may not build with the current macOS `.NET` SDK
- it may still depend on the historical project structure
- it may still contain intentional teaching scaffolding or incomplete stub code

For migration details and repo conventions, see
[AGENTS.md](/Volumes/Work/introcs-csharp-examples/AGENTS.md:1).
