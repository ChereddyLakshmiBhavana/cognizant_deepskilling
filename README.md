# Cognizant Deepskilling

This repository contains C#/.NET practice exercises organized by week.

## Repository Structure

- week1-112
- week2-CalcLibraryExercise1
- week2-CognizantDN5.Moq.Exercise2
- week2-MagicFilesExercise3
- week2-PlayerManager.Tests

## Tech Stack

- .NET 8
- NUnit
- Moq

## Prerequisites

- .NET SDK 8.0 or later

Check your SDK:

```powershell
dotnet --version
```

## Build And Test

From the repository root, run each solution:

```powershell
dotnet test .\week2-CalcLibraryExercise1\CalcLibraryExercise1.sln
dotnet test .\week2-CognizantDN5.Moq.Exercise2\CognizantDN5.Moq.Exercise2.sln
dotnet test .\week2-MagicFilesExercise3\MagicFilesSolution.sln
```

## CI

GitHub Actions is configured to automatically restore, build, and test all discovered `.sln` files on pushes and pull requests to `main`.
