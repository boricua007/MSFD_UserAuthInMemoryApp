# MSFD User Auth In-Memory App

## Overview

This ASP.NET Core MVC application demonstrates a basic user authentication workflow
using ASP.NET Core Identity with an in-memory database. The project focuses on
core account functionality, including user registration, login, and verification
of stored users during runtime.

## Technologies Used

- .NET 10.0
- ASP.NET Core MVC
- ASP.NET Core Identity
- Entity Framework Core InMemory
- C#

## Getting Started

1. **Clone the repository**

	```bash
	git clone <MSFD_UserAuthInMemoryApp>
	cd MSFD_UserAuthInMemoryApp
	```

2. **Restore packages**

	```bash
	dotnet restore
	```

3. **Run the application**

	```bash
	dotnet run
	```

4. **Access the application**

	Open your browser and navigate to:

	- `http://localhost:5167/Account/Register`
	- `http://localhost:5167/Account/Login`
	- `http://localhost:5167/Account/Users`

## Project Structure

```text
MSFD_UserAuthInMemoryApp/
|
|- Controllers/
|  |- AccountController.cs
|  |- HomeController.cs
|
|- Models/
|  |- ApplicationDbContext.cs
|  |- RegisterViewModel.cs
|  |- LoginViewModel.cs
|  |- ErrorViewModel.cs
|
|- Views/
|  |- Account/
|  |  |- Register.cshtml
|  |  |- Login.cshtml
|  |  |- Users.cshtml
|  |- Home/
|  |- Shared/
|
|- wwwroot/
|  |- css/site.css
|- Program.cs
|- appsettings.json
|- MSFD_UserAuthInMemoryApp.csproj
```

## Data Models

### RegisterViewModel

- Email (required)
- Password (required, minimum length)
- ConfirmPassword (must match Password)

### LoginViewModel

- Email (required)
- Password (required)
- RememberMe (boolean)

## Key Features

### 1. MVC Account Flow

Implements account routes and actions for registration and login using MVC
controllers and Razor views.

### 2. ASP.NET Core Identity Integration

Uses `UserManager` and `SignInManager` for secure user creation and sign-in.

### 3. In-Memory User Storage

Stores identity data in memory for demonstration/testing without a persistent
database.

### 4. Styled Razor UI

Includes professional-styled Register, Login, and Users pages with consistent
form and table design.

## Usage

The application supports:

- Registering a new user from `/Account/Register`
- Logging in from `/Account/Login`
- Viewing stored users from `/Account/Users`

Verification endpoint:

- `GET /Account/UsersJson` - returns registered users as JSON for quick checks

## Key Concepts Demonstrated

- ASP.NET Core MVC patterns
- ASP.NET Core Identity fundamentals
- Model validation with Data Annotations
- In-memory data provider behavior
- Razor view and form binding

## About

.NET 10 MVC authentication demo built for the Microsoft Back-End Development course as part of the Full-Stack Certification track. This project demonstrates foundational Identity-based auth flows in a simple in-memory setup that is easy to run, test, and extend.
