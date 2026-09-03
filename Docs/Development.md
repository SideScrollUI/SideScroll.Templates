# Development

## Build

```bash
dotnet build SideScroll.Templates.csproj
```

---

## Install Locally

```bash
dotnet new install <path-to-SideScroll.Templates>
```

### Reinstalling

```bash
dotnet new install <path-to-SideScroll.Templates> --force
```

---

## Test Project

```bash
dotnet new sidescroll.app -o MyApp
```

### Run project

```bash
cd MyApp
dotnet run
```

## Test Solution

```bash
dotnet new sidescroll.sln -o MyApp
```

### Run solution

```bash
cd MyApp
dotnet run --project Programs\<MyApp>.Desktop\<MyApp>.Desktop.csproj
```

---

## 🧹 Uninstalling

```bash
dotnet new uninstall <path-to-SideScroll.Templates>
```

---

## Publish

The [Publish to NuGet](../.github/workflows/publish-nuget.yml) workflow builds, packs, and pushes the template package to [nuget.org](https://www.nuget.org/packages/SideScroll.Templates).

Before publishing, it installs the packed package and creates and builds a project from each template, since a template package packs successfully whether or not the templates inside it work. The generated projects resolve `SideScrollVersion` and `AvaloniaVersion` from nuget.org, so the SideScroll release the templates target has to be published first.

Releasing is a version bump:

- Update `<PackageVersion>` in [SideScroll.Templates.csproj](../SideScroll.Templates.csproj), along with the `SideScrollVersion` defaults in each template
- Commit and push to `main`

A `v<version>` tag is the record of what's been released, so a version without one is a new release. The workflow publishes it and then tags the commit it published, which keeps later pushes from publishing the same version twice. Pushes made while the current version is already tagged stop after the version check, without building.

The first push to `main` after the bump is what releases, whether or not that push is the bump commit itself.

Running the workflow manually from the Actions tab builds, packs, and runs the template checks without publishing, uploading the package as a build artifact to check before committing to a release. Checking **Push the package to nuget.org** publishes from a manual run, which is also how to retry a release that failed partway through.

### Setup

Publishing uses [Trusted Publishing](https://learn.microsoft.com/en-us/nuget/nuget-org/trusted-publishing), so there's no API key to store or rotate. The workflow requests a GitHub OIDC token, and nuget.org exchanges it for a temporary key that expires after an hour.

On nuget.org, under your username → **Trusted Publishing**, add a policy:

| Field | Value |
| --- | --- |
| Repository Owner | `SideScrollUI` |
| Repository | `SideScroll.Templates` |
| Workflow File | `publish-nuget.yml` |
| Environment | *(leave empty)* |

The workflow passes the `sidescrollui` profile name to `NuGet/login`, which has to match the policy's package owner.

Renaming the workflow file breaks the policy, since it's matched by file name.
