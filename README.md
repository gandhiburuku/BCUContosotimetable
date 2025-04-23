# 🧪 BCUContosotimetable End-to-End Tests

This project contains automated UI and API tests using:

- ✅ [Microsoft.Playwright](https://playwright.dev/dotnet)
- 🧪 [NUnit](https://nunit.org/)
- 🧬 [Reqnroll](https://reqnroll.net/) (SpecFlow-compatible BDD)
- 🧰 [Microsoft.Extensions.DependencyInjection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- 🌐 .NET 8

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Node.js (for Playwright installation)](https://nodejs.org/) — required once for browser installation

### One-Time Setup

1. Install Playwright browsers (Chromium, Firefox, WebKit):

```
 npx playwright install
```
## 🛠 Tech Versions

| Tool/Lib                    | Version     |
|-----------------------------|-------------|
| .NET SDK                    | 8.0.x       |
| Microsoft.Playwright        | 1.51.0      |
| NUnit                       | 3.13.3      |
| Reqnroll                    | 2.4.0       |
| Reqnroll DependencyInjection| 2.4.0       |

## 📁 Project Structure
```
BCUContosotimetable.csproj
├── Features/
│   └── UpdateStudentName.feature
├── Pages/
│   └── StudentDetailsPage.cs
├── StepDefinitions/
│   └── UpdateStudentNameStepDefinitions.cs
├── Support/
│   ├── Hooks.cs
│   └── PlaywrightService.cs
├── Startup.cs
└── README.md
```
## 📄 Test Scenario

The below test scenario got automated
```
Feature: Update Student Name
 
  As an admin or teacher
  I want to update a student's name via the API
  So that the new name is reflected in the web-frontend system

  Scenario: Successfully update the name of an existing student
    Given a student exists with ID '<Student Id>'
    When I send a PUT request to update their name to '<Student Name>'
    Then the API should return a successful response
    And the response body should contain the updated name '<Student Name>'
    When I open the student details page for student with ID '1' in the web application
    Then the student name should be displayed as '<Student Name>'
Examples: 
| Student Id | Student Name |
| 1          | Test Name    |

```

## ✅ Running Tests
```
 dotnet test
```