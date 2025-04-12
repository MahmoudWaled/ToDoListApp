# ToDoList API

A RESTful API for managing a To-Do List, built with **.NET Core 8**. Supports CRUD operations and color-coding for tasks using Hex codes.

## Features
- Create, read, update, and delete tasks.
- Add Hex color codes to tasks (e.g., `#FF0000`).
- Filter tasks by color.
- Uses SQL Server with Entity Framework Core.
- API documentation via Swagger.

## Tech Stack
- .NET Core 8
- SQL Server
- Swagger
- AutoMapper

## Endpoints

| Method | Endpoint                        | Description                          |
|--------|---------------------------------|--------------------------------------|
| GET    | `/api/Goal`                    | Retrieves all goals.                |
| POST   | `/api/Goal`                    | Creates a new goal.                |
| GET    | `/api/Goal/{id}`              | Retrieves a goal by ID.            |
| PUT    | `/api/Goal/{id}`              | Updates a goal by ID.              |
| DELETE | `/api/Goal/{id}`              | Deletes a goal by ID.              |
| GET    | `/api/Goal/color/{color}`     | Retrieves goals by color (Hex code). |
| GET    | `/api/Goal/dueDate/{dueDate}` | Retrieves goals by due date.       |
| GET    | `/api/Goal/completed`         | Retrieves all completed goals.     |
| GET    | `/api/Goal/pending`           | Retrieves all pending goals.       |


## Thanks.
