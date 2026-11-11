using Microsoft.AspNetCore.Authentication;

namespace Web.Models.Users.Extensions;

public static class ExternalProviderExtensions
{
    private const string FallbackIcon = "bi-box-arrow-in-right";

    public static string BootstrapIcon(string providerName) =>
        providerName switch
        {
            "Google" => "bi-google",
            "Facebook" => "bi-facebook",
            "GitHub" => "bi-github",
            "Microsoft" => "bi-microsoft",
            "Discord" => "bi-discord",
            _ => FallbackIcon,
        };

    public static string BootstrapIcon(this AuthenticationScheme scheme) => BootstrapIcon(scheme.Name);

    public static string BootstrapIcon(this ConnectedProvider provider) => BootstrapIcon(provider.ProviderName);
}
