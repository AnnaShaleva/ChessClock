# ChessClock

Simple Alice Skill for timetracking in board games like chess, monopoly and etc.
The API resives JSon POST queries from Yandex.Dialogs and is able to:
- host several game sessions
- manage players during the game
- track the playing time and moves time for each player

The solution has three-tier architecture:

| Project | Description | Tools |
| ----- | ----------- | -----|
| [ChessClock](https://github.com/AnnaShaleva/ChessClock/tree/master/ChessClock) | API for handling queries and responces generation | `.NET Core IoC container`, `Automapper`, `Swagger API` |
| [ChessClock.BLL](https://github.com/AnnaShaleva/ChessClock/tree/master/ChessClock.BLL) | Represents services and rulles for managing entityes (e.g. Player, Move, Session) | `DI technique` |
| [ChessClock.DAL](https://github.com/AnnaShaleva/ChessClock/tree/master/ChessClock.DAL) | Provides CRUD operations for entities | `LINQ`, `Entity Framework`, `PostgreSQL` |
| [ChessClock.Kernel](https://github.com/AnnaShaleva/ChessClock/tree/master/ChessClock.Kernel) | Describes general DTOs and interfaces for interaction between layers |  
| [ChessClock.UnitTests](https://github.com/AnnaShaleva/ChessClock/tree/master/ChessClock.UnitTests) | Contains unit tests for solution | `NUnit` |

## Usage

To build the solution:

1. Clone the repository
```
https://github.com/AnnaShaleva/ChessClock
```
2. Add the connection string to your PostgreSQL db into `appsettings.json`

3. Set `ChessClock.DAL` as default project for NuGET Package Manager console

3. Use `Update-Database` to apply migrations

4. Build and run the solution

On the [AliceDialoges documentation page](https://tech.yandex.ru/dialogs/alice/doc/protocol-docpage/) you can find the details about the protocol of the service.
