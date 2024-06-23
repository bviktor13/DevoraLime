# HeroBattle

HeroBattle is a .NET-based solution where N heroes (archers, horsemen, and swordsmen) battle in an arena according to specific rules. The project includes a Web API that allows for the creation of arena, and the retrieval of battle history.

## Overview

In HeroBattle, each hero has a unique identifier and health. Heroes follow specific rules for attacking and defending against each other:
- **Archer**:
  - Attacks a Horseman: 40% chance to kill, 60% chance to be blocked.
  - Attacks a Swordsman: Swordsman dies.
  - Attacks another Archer: Defender dies.
- **Swordsman**:
  - Attacks a Horseman: No effect.
  - Attacks another Swordsman: Defender dies.
  - Attacks an Archer: Archer dies.
- **Horseman**:
  - Attacks a Horseman: Defender dies.
  - Attacks a Swordsman: Horseman dies.
  - Attacks an Archer: Archer dies.

The battle is round-based, with a random attacker and defender each round. Non-participating heroes rest and regain 10 health points, up to their maximum health.

## Features
- Round-based battle system
- Hero resting and health management
- Battle history tracking

## Technologies
- .NET Core
- Entity Framework Core
- FluentValidation
- Mapster

### Prerequisites
- .NET Core SDK
- SQL Server (or another supported database)
- Visual Studio (recommended)

### Installation
- Clone the repository
- Use the following command to restore the dependencies: dotnet restore
- In Package Manager Console, use the following command to restore/create DB: Update-Database
- Execute the following command to run the application: dotnet run
