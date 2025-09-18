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
SideScroll .NET App       sidescroll.app  [C#]      Desktop/Xaml/SideScroll/Avalonia/Windows/Linux/macOS
SideScroll .NET Solution  sidescroll.sln  [C#]      Desktop/Xaml/SideScroll/Avalonia/Windows/Linux/macOS
```

---

## 🛠 Creating a Project

To create a new SideScroll app Project from the template:

```bash
dotnet new sidescroll.app -o MyApp
```

---

### Run the project

```bash
cd MyApp
dotnet run
```

---

## 🛠 Creating a Solution

If you want to create a new Solution with the app split into a Library and Program app:

```bash
dotnet new sidescroll.sln -o MyApp
```

---

### Run the solution

```bash
cd MyApp
dotnet run --project Programs\<MyApp>.Desktop\<MyApp>.Desktop.csproj
```

## 🧹 Uninstalling the Templates

```bash
dotnet new uninstall SideScroll.Templates
```

## Template Development

* [Development](Docs/Development.md)
