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

Run it from the Actions tab, selecting the tag to release from the ref dropdown:

- Update `<PackageVersion>` in [SideScroll.Templates.csproj](../SideScroll.Templates.csproj) and commit it
- `git tag v0.24`
- `git push origin v0.24`
- Run the workflow against `v0.24` with **Push the package to nuget.org** checked

Leaving that box unchecked packs the package and uploads it as a build artifact without publishing, which is a way to verify a release before committing to it. The tag has to match `<PackageVersion>` or the workflow fails before publishing anything.

The automatic `v*` tag trigger is commented out in the workflow until a manual run has verified the setup end to end.

### Setup

Publishing uses [Trusted Publishing](https://learn.microsoft.com/en-us/nuget/nuget-org/trusted-publishing), so there's no API key to store or rotate. The workflow requests a GitHub OIDC token, and nuget.org exchanges it for a temporary key that expires after an hour.

On nuget.org, under your username → **Trusted Publishing**, add a policy:

| Field | Value |
| --- | --- |
| Repository Owner | `SideScrollUI` |
| Repository | `SideScroll.Templates` |
| Workflow File | `publish-nuget.yml` |
| Environment | *(leave empty)* |

Then add a `NUGET_USER` repository secret (Settings → Secrets and variables → Actions) holding the nuget.org profile name that owns the policy — not the account's email address.

Renaming the workflow file breaks the policy, since it's matched by file name.
