namespace Web.Models.Users;

public class UserProfile
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }
}
