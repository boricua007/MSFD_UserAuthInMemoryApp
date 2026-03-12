# MSFD User Auth In-Memory App

## Overview

This ASP.NET Core MVC application demonstrates a basic user authentication workflow using ASP.NET Core Identity with an in-memory database. The project focuses on core account functionality, including user registration, login, and verification of stored users during runtime.

## Features

✅ ASP.NET Core Identity for secure authentication
✅ In-memory database for fast, demo-friendly persistence
✅ Roles & Claims management for fine-grained authorization
✅ Protected endpoints in RouteController (role/claim-based access)
✅ MVC architecture with controllers, models, and views
✅ Bootstrap styling for responsive UI

## Authorization Patterns

| Pattern        | Description                        | Technology         | Benefits                |
|---------------|------------------------------------|--------------------|-------------------------|
| Role-Based     | Restrict access by user role        | Identity Roles     | Simple, scalable        |
| Claims-Based   | Restrict access by user claim       | Identity Claims    | Fine-grained control    |
| Policy-Based   | Combine roles/claims for endpoints  | AuthorizationPolicy| Flexible, maintainable  |

## RouteController Endpoints

| Endpoint                        | Method | Authorization                | Description                                 |
|----------------------------------|--------|------------------------------|---------------------------------------------|
| /route/employee-records          | GET    | HR role                      | Retrieve all employee records               |
| /route/employee-records          | POST   | ManageEmployeeRecords claim  | Add a new employee record                   |
| /route/employee-records/{id}     | DELETE | ManageEmployeeRecords claim  | Delete an employee record by ID             |


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
|  |- AccountController.cs	# User registration, login, user list
|  |- HomeController.cs		# Home and privacy pages
|  |- RouteController.cs	# Role/claim-protected endpoints
|
|- Models/
|  |- ApplicationDbContext.cs	# EF Core in-memory context
|  |- RegisterViewModel.cs		# Registration form model
|  |- LoginViewModel.cs			# Login form model
|  |- ErrorViewModel.cs			# Error handling model
|
|- Views/
|  |- Account/
|  |  |- Register.cshtml	# Register, Login, Users views
|  |  |- Login.cshtml
|  |  |- Users.cshtml
|  |- Home/
|  |- Shared/
|
|- wwwroot/
|  |- css/site.css
|- Program.c				# App entry point, DI, role/claim seeding
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

- ASP.NET Core MVC Architecture: Clean separation of controllers, models, and views
- Identity Management: Secure user authentication and role/claim-based authorization
- Model Validation: Robust input validation using Data Annotations
- In-Memory Data Provider: Fast, demo-friendly persistence for development and testing
- Razor Views & Form Binding: Dynamic UI rendering and seamless form handling
- Protected Endpoints: Practical examples of role- and claim-based access control

## About

.NET 10 MVC authentication demo built for the Microsoft Back-End Development course as part of the Full-Stack Certification track. This project demonstrates foundational Identity-based auth flows in a simple in-memory setup that is easy to run, test, and extend.

## Author

**Daisy Viruet-Allen (boricua007)**  
GitHub: [https://github.com/boricua007](https://github.com/boricua007)

---

*This project is part of the Microsoft Full Stack Developer certification coursework.*