namespace Web.Models.Users;

public class ConnectedProvider
{
    public string ProviderName { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public bool IsConnected { get; set; }
}
