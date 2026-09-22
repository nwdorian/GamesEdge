using Web.Models.Admin.Items;

namespace Web.Models.Admin;

public class AdminIndex
{
    public IList<StaffItem> Staff { get; set; } = [];
}
