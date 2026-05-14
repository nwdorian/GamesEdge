namespace Infrastructure.Users;

public static class UserFaker
{
    public static readonly Guid AdminId = new("c700d049-e44d-4dad-8e53-eee0186c7cbd");
    public static readonly string AdminEmail = "admin@movieboom.com";

    public static User CreateAdminUser()
    {
        return new()
        {
            Id = AdminId,
            UserName = AdminEmail,
            Email = AdminEmail,
            EmailConfirmed = true,
        };
    }
}
