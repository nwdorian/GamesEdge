using Domain.Core.Results;

namespace Domain.Games;

public static class GameErrors
{
    public static Error NameAlreadyExists(string name) =>
        Error.Conflict($"{nameof(Game)}.{nameof(NameAlreadyExists)}", $"Game with the name {name} already exists.");
}
