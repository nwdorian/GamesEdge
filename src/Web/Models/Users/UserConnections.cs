namespace Web.Models.Users;

public class UserConnections
{
    public IReadOnlyList<ConnectedProvider> Providers { get; set; } = [];
}
