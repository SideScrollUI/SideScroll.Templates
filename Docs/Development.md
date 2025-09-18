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
