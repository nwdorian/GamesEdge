namespace Infrastructure.Users;

public static class UserFaker
{
    public static readonly Guid AdminId = new("c700d049-e44d-4dad-8e53-eee0186c7cbd");
    public static readonly Guid StaffId = new("b7ae4954-2a24-4b7d-9e53-534a03ddde25");
    public static readonly string AdminEmail = "admin@movieboom.com";
    public static readonly string StaffEmail = "staff@movieboom.com";

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

    public static User CreateStaffUser()
    {
        return new()
        {
            Id = StaffId,
            UserName = StaffEmail,
            Email = StaffEmail,
            EmailConfirmed = true,
        };
    }
}
