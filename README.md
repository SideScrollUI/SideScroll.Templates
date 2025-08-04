# SideScroll .NET Templates

This repository contains the official `.NET` project templates for building new [SideScroll](https://github.com/SideScrollUI/SideScroll) applications.

> 📦 For information about the SideScroll framework itself, visit the [main repo](https://github.com/SideScrollUI/SideScroll).

---

## 🚀 Installation

To install the templates:

```bash
dotnet new install SideScroll.Templates
```

After installation, you can list available templates:

```bash
dotnet new list
```

Expected output:

```
Template Name         Short Name      Language  Tags
-------------------  --------------  --------  ---------------------------------------------
SideScroll .NET App  sidescroll.app  [C#]      Desktop/Xaml/SideScroll/Avalonia/Windows/macOS/Linux
```

---

## 🛠 Creating a Project

To create a new SideScroll app from the template:

```bash
dotnet new sidescroll.app -o MyApp
```

---

## 🧱 Developing the Templates

### Build

```bash
dotnet build SideScroll.Templates.csproj
```

### Install Locally

```bash
dotnet new install <path-to-SideScroll.Templates>
```

### Reinstall (Force Refresh)

```bash
dotnet new install <path-to-SideScroll.Templates> --force
```

### Test by Creating a Project

```bash
dotnet new sidescroll.app -o MyApp
```

---

## 🧹 Uninstalling the Templates

```bash
dotnet new uninstall SideScroll.Templates
```

---

Let me know if you want to add versioning, CI build instructions, or publish-to-NuGet steps.
