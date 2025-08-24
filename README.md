# SideScroll .NET Templates

This repository contains the `.NET` project templates for building new [SideScroll](https://github.com/SideScrollUI/SideScroll) applications

> 📦 For information about the SideScroll framework itself, visit the [main repo](https://github.com/SideScrollUI/SideScroll)

---

## 🚀 Installing

To install the templates:

```bash
dotnet new install SideScroll.Templates
```

After installing, you can list the available templates:

```bash
dotnet new list SideScroll
```

You should see something like this:

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

If you want to create a new Solution with the app split into a Library and Program app:

```bash
dotnet new sidescroll.sln -o MyApp
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

### Reinstalling

```bash
dotnet new install <path-to-SideScroll.Templates> --force
```

### Test by Creating a Project

```bash
dotnet new sidescroll.app -o MyApp
```

### Run the project

```bash
cd MyApp
dotnet run
```

---

## 🧹 Uninstalling the Templates

```bash
dotnet new uninstall SideScroll.Templates
```
