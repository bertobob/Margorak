
# Margorak

Margorak is a work-in-progress browser RPG built with ASP.NET Core, Entity Framework Core, SQLite, and Angular.
| World Map  | Character and Inventory |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/82c5ff2a-32f3-4f47-96f6-15503017163e" alt="Character and inventory view" width="400"> | <img src="https://github.com/user-attachments/assets/b2c908cd-3d3d-4881-85e0-a0901ac58cac" alt="World map view" width="400"> |



## Features

- Tile-based map exploration and movement
- Character creation, saving, and loading
- Inventory with item quantities and requirements
- Equipment management and aggregated stats
- Teleporter and shop interactions
- Buying and selling items
- Persistent character position, gold, inventory, and equipment

## Tech Stack

- Backend: .NET 8, ASP.NET Core, Entity Framework Core, SQLite
- Frontend: Angular, TypeScript, Angular Signals, RxJS
- Tests: MSTest and Vitest

## Architecture

The application uses a layered structure:

Angular UI → API Controllers → Application Services → Repositories and Unit of Work → Entity Framework Core / SQLite

DTOs define the API boundary between frontend and backend. Services contain gameplay workflows, while repositories hide persistence details.

The frontend uses Angular Signals for shared game state and dedicated handlers for different map interaction types.

## Project Scope

Margorak is currently designed as a local single-player prototype.

The API does not implement user accounts, authentication, or character ownership.
Character IDs are therefore treated as local game state rather than protected
user data.

The application is intended to run locally with a local SQLite database and
should not be exposed as a public production service in its current state.
Authentication and authorization would be required before supporting multiple
users or a public deployment.

## Project Structure

    backend/
      Margorak.Api/
      Margorak.Api.Tests/

    frontend/
      src/app/
        core/
        features/
        shared/

## Development

AI-assisted tools were used during development, primarily for CSS styling,
HTML templates, code review, and refactoring. Architecture, feature design,
integration, and final implementation decisions were made and validated by
the project author.

## Run Locally

### Backend

    cd backend
    dotnet restore
    dotnet run --project Margorak.Api

### Frontend

    cd frontend
    npm install
    npm start

The frontend is available at `http://localhost:4200`.

## Planned Features

- Combat system
- Experience and level progression
- Loot and consumable items
- Additional maps and interactions
- Expanded automated tests

## Status

Margorak is under active development.


